using Aidn.NewsScore.Communication;
using System.Text.Json.Serialization;

namespace Aidn.NewsScore.Configuration
{
    public class MeasurementsConfig
    {
        public List<MeasurementConfig> Quantities { get; set; }
    }

    public class MeasurementConfig
    {
        [JsonIgnore]
        public MeasurementType MeasurementType => (MeasurementType)(Enum.Parse(typeof(MeasurementType), Type, true));
        public string Type { get; set; }
        public List<RangeConfig> Ranges { get; set; }
    }

    public class RangeConfig
    {
        public int Range { get; set; }
        public int Score { get; set; }
    }
}
