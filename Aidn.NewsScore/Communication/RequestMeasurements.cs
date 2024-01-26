using System.Text.Json.Serialization;

namespace Aidn.NewsScore.Communication
{
    public enum MeasurementType
    {
        Unknown,
        Temp,
        Hr,
        Rr
    }

    public class RequestMeasurements
    {
        public List<Measurement> Measurements { get; set; } = [];
    }

    public class Measurement
    {
        [JsonIgnore]
        public MeasurementType MeasurementType => (MeasurementType)(Enum.TryParse(typeof(MeasurementType), Type, true, out object? type) ? type : MeasurementType.Unknown);
        public string Type { get; set; }
        public int Value { get; set; }
    }
}
