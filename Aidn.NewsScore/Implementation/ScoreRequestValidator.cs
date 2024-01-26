using Aidn.NewsScore.Communication;
using Aidn.NewsScore.Configuration;
using Aidn.NewsScore.Interfaces;

namespace Aidn.NewsScore.Implementation
{
    public class ScoreRequestValidator: IScoreRequestValidator
    {
        private readonly MeasurementsConfig _config;

        public ScoreRequestValidator(MeasurementsConfig config) {
            _config = config;
        }

        public bool IsValid(RequestMeasurements measurements)
        {
            var validateMinMax = _config.Quantities
                .Select(q => new { q.MeasurementType, Min = q.Ranges.Select(r => r.Range).Min(), Max = q.Ranges.Select(r => r.Range).Max() });

            return measurements.Measurements.All(m => 
                m.MeasurementType != MeasurementType.Unknown &&
                m.Value > validateMinMax.Single(v => v.MeasurementType == m.MeasurementType).Min &&
                m.Value <= validateMinMax.Single(v => v.MeasurementType == m.MeasurementType).Max);
        }
    }
}
