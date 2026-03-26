using System;
using System.Collections.Generic;

namespace AIInfluence.WorldSystem;

public class PlotScheduler
{
    private readonly IntrigueStore _store;
    private readonly EventDiary _diary;
    private readonly Dictionary<string, PlotTemplate> _templates;
    private readonly Action<string> _log;
    private int _correlationCounter;

    public PlotScheduler(
        IntrigueStore store,
        EventDiary diary,
        Dictionary<string, PlotTemplate> templates,
        Action<string> log = null)
    {
        _store = store;
        _diary = diary;
        _templates = templates;
        _log = log ?? (_ => { });
    }

    public void OnTrigger(string trigger)
    {
        foreach (var plot in _store.GetAllPlots())
        {
            if (plot.Status != PlotStatus.Active)
                continue;

            if (!_templates.TryGetValue(plot.TemplateId, out var template))
                continue;

            var correlationId = $"corr={++_correlationCounter}";
            var executor = new StepExecutor(_store, _diary);

            foreach (var step in template.Steps)
            {
                if (!step.Triggers.Contains(trigger))
                    continue;

                _log($"[WorldSystem] {correlationId} trigger={trigger} plot={plot.Id} step={step.StepId}");
                var result = executor.Execute(step, plot.Id, correlationId);

                if (result.Success)
                    _log($"[WorldSystem] {correlationId} step={step.StepId} executed successfully");
                else
                    _log($"[WorldSystem] {correlationId} step={step.StepId} skipped: {result.Reason}");
            }

            EvaluateEpisodes(template, plot, correlationId);
        }
    }

    private void EvaluateEpisodes(PlotTemplate template, PlotInstance plot, string correlationId)
    {
        var diaryEntries = _diary.GetAll();
        foreach (var episode in template.Episodes)
        {
            var evalResult = episode.Evaluate(diaryEntries);
            if (!evalResult.Fired)
                continue;

            _log($"[WorldSystem] {correlationId} episode={episode.EpisodeId} fired pattern={evalResult.MatchedPatternId} on plot={plot.Id}");

            foreach (var literal in evalResult.Resolution.RStateLiterals)
            {
                if (!plot.CompletedStepIds.Contains(literal))
                    plot.CompletedStepIds.Add(literal);
            }
        }
    }
}
