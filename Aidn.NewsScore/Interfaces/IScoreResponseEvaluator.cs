using Aidn.NewsScore.Communication;

namespace Aidn.NewsScore.Interfaces
{
    public interface IScoreResponseEvaluator
    {
        int Evaluate(RequestMeasurements measurements);
    }
}
