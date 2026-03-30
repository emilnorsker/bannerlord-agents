using System.Collections.Generic;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class SecretResolverTests
{
    [Test]
    public void RuntimeOnly_ReturnsRuntimeText()
    {
        var runtimeStore = new RuntimeSecretStore();
        runtimeStore.Add(new RuntimeSecretRecord
        {
            Id = "runtime_only",
            Description = "runtime description",
            AccessLevel = "secret"
        });
        var catalog = new List<CatalogSecret>();
        var errors = new List<string>();
        var resolver = new SecretResolver(runtimeStore, catalog, e => errors.Add(e));

        var result = resolver.Resolve("runtime_only");

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Description, Is.EqualTo("runtime description"));
        Assert.That(result.AccessLevel, Is.EqualTo("secret"));
        Assert.That(errors, Is.Empty);
    }

    [Test]
    public void CatalogOnly_ReturnsCatalogText()
    {
        var runtimeStore = new RuntimeSecretStore();
        var catalog = new List<CatalogSecret>
        {
            new CatalogSecret
            {
                Id = "catalog_only",
                Description = "catalog description",
                AccessLevel = "public"
            }
        };
        var errors = new List<string>();
        var resolver = new SecretResolver(runtimeStore, catalog, e => errors.Add(e));

        var result = resolver.Resolve("catalog_only");

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Description, Is.EqualTo("catalog description"));
        Assert.That(errors, Is.Empty);
    }

    [Test]
    public void BothExist_RuntimeWins()
    {
        var runtimeStore = new RuntimeSecretStore();
        runtimeStore.Add(new RuntimeSecretRecord
        {
            Id = "shared_id",
            Description = "runtime wins",
            AccessLevel = "secret"
        });
        var catalog = new List<CatalogSecret>
        {
            new CatalogSecret
            {
                Id = "shared_id",
                Description = "catalog loses",
                AccessLevel = "public"
            }
        };
        var errors = new List<string>();
        var resolver = new SecretResolver(runtimeStore, catalog, e => errors.Add(e));

        var result = resolver.Resolve("shared_id");

        Assert.That(result.Description, Is.EqualTo("runtime wins"));
        Assert.That(errors, Is.Empty);
    }

    [Test]
    public void UnknownId_LogsErrorAndReturnsNull()
    {
        var runtimeStore = new RuntimeSecretStore();
        var catalog = new List<CatalogSecret>();
        var errors = new List<string>();
        var resolver = new SecretResolver(runtimeStore, catalog, e => errors.Add(e));

        var result = resolver.Resolve("unknown_id");

        Assert.That(result, Is.Null);
        Assert.That(errors, Has.Count.EqualTo(1));
        Assert.That(errors[0], Does.Contain("unknown_id"));
    }
}
