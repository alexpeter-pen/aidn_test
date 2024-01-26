using Aidn.NewsScore.Communication;
using Aidn.NewsScore.Configuration;

namespace Aidn.NewsScore.Interfaces
{
    public class ScoreResponseEvaluator: IScoreResponseEvaluator
    {
        private readonly MeasurementsConfig _config;

        public ScoreResponseEvaluator(MeasurementsConfig config)
        {
            _config = config;
        }

        public int Evaluate(RequestMeasurements measurements)
        {
            return measurements.Measurements.Sum(m =>
            
                _config.Quantities
                    .FirstOrDefault(q => q.MeasurementType == m.MeasurementType)?
                    .Ranges.FirstOrDefault(r => m.Value <= r.Range)?.Score ?? 0
            );
        }
    }
}
