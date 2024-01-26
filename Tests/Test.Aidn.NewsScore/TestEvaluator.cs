using Aidn.NewsScore.Communication;
using Aidn.NewsScore.Configuration;
using Aidn.NewsScore.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Test.Aidn.NewsScore
{
    [TestClass]
    public class TestEvaluator
    {
        ScoreResponseEvaluator eval;
        public TestEvaluator() {

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            MeasurementsConfig measureConfig = new();

            config.GetSection("MeasurementsConfig").Bind(measureConfig);

            eval = new ScoreResponseEvaluator(measureConfig);
        }

        [TestMethod]
        public void Test_lower_score()
        {
            Assert.AreEqual(eval.Evaluate(new RequestMeasurements()
            {
                Measurements = [
                    new Measurement
                    {
                        Type = "TEMP",
                        Value = 32
                    }]
            }), 3);
        }

        [TestMethod]
        public void Test_middle_score()
        {
            Assert.AreEqual(eval.Evaluate(new RequestMeasurements()
            {
                Measurements = [
                    new Measurement {
                        Type = "TEMP",
                        Value = 36
                } ]
            }), 1);
        }
        
        [TestMethod]
        public void Test_upper_score()
        {
            Assert.AreEqual(eval.Evaluate(new RequestMeasurements()
            {
                Measurements = [
                    new Measurement
                    {
                        Type = "TEMP",
                        Value = 42
                    }]
            }), 2);
        }
    }
}