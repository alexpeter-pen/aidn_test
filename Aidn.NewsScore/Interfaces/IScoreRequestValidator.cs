using Aidn.NewsScore.Communication;

namespace Aidn.NewsScore.Interfaces
{
    public interface IScoreRequestValidator
    {
        bool IsValid(RequestMeasurements measurements);
    }
}
