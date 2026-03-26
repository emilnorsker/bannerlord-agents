using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AIInfluence.WorldSystem;

[JsonConverter(typeof(StringEnumConverter))]
public enum PlotEffectType
{
    EmitPlotPoint,
    EmitSecret,
    PropagateKnowledge,
    AdvancePlotPhase,
    EmitDynamicEvent
}
