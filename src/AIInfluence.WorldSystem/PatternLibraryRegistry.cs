using System.Collections.Generic;
using System.Linq;

namespace AIInfluence.WorldSystem;

public class PatternLibraryRegistry
{
    private readonly List<PatternLibrary> _libraries = new List<PatternLibrary>();

    public void Register(PatternLibrary library)
    {
        _libraries.Add(library);
    }

    public PatternLibrary GetByTemplateId(string templateId)
    {
        return _libraries.FirstOrDefault(l => l.TemplateId == templateId);
    }
}
