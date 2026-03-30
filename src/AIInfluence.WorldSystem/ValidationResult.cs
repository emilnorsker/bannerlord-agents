using System.Collections.Generic;

namespace AIInfluence.WorldSystem;

public class ValidationResult
{
    public bool Valid { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
}
