using System;
using System.Collections.Generic;
using System.Linq;

namespace AIInfluence.WorldSystem;

public class SecretResolver
{
    private readonly RuntimeSecretStore _runtimeStore;
    private readonly IReadOnlyList<CatalogSecret> _catalogSecrets;
    private readonly Action<string> _logError;

    public SecretResolver(
        RuntimeSecretStore runtimeStore,
        IReadOnlyList<CatalogSecret> catalogSecrets,
        Action<string> logError)
    {
        _runtimeStore = runtimeStore;
        _catalogSecrets = catalogSecrets;
        _logError = logError;
    }

    public ResolvedSecret Resolve(string secretId)
    {
        var runtime = _runtimeStore.GetById(secretId);
        if (runtime != null)
        {
            return new ResolvedSecret
            {
                Id = runtime.Id,
                Description = runtime.Description,
                AccessLevel = runtime.AccessLevel
            };
        }

        var catalog = _catalogSecrets.FirstOrDefault(c => c.Id == secretId);
        if (catalog != null)
        {
            return new ResolvedSecret
            {
                Id = catalog.Id,
                Description = catalog.Description,
                AccessLevel = catalog.AccessLevel
            };
        }

        _logError($"[WorldSystem] Secret id '{secretId}' not found in runtime store or catalog.");
        return null;
    }
}
