using Aidn.NewsScore.Communication;
using Aidn.NewsScore.Configuration;
using Aidn.NewsScore.Implementation;
using Aidn.NewsScore.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Test.Aidn.NewsScore
{
    [TestClass]
    public class TestValidator
    {
        ScoreRequestValidator valid;

        public TestValidator()
        {

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            MeasurementsConfig measureConfig = new();

            config.GetSection("MeasurementsConfig").Bind(measureConfig);

            valid = new ScoreRequestValidator(measureConfig);
        }

        [TestMethod]
        public void Test_incorrect_temperature()
        {
            Assert.IsFalse(valid.IsValid(new RequestMeasurements()
            {
                Measurements = [
                    new Measurement {
                        Type = "TEMP",
                        Value = 1
                } ]
            }));
        }

        [TestMethod]
        public void Test_incorrect_temperature_lower_edge()
        {
            Assert.IsFalse(valid.IsValid(new RequestMeasurements()
            {
                Measurements = [
                    new Measurement
                    {
                        Type = "TEMP",
                        Value = 31
                    }]
            }));
        }

        [TestMethod]
        public void Test_correct_temperature_lower_edge()
        {
            Assert.IsTrue(valid.IsValid(new RequestMeasurements()
            {
                Measurements = [
                    new Measurement
                    {
                        Type = "TEMP",
                        Value = 32
                    }]
            }));
        }

        [TestMethod]
        public void Test_correct_temperature_upper_edge()
        {
            Assert.IsTrue(valid.IsValid(new RequestMeasurements()
            {
                Measurements = [
                    new Measurement
                    {
                        Type = "TEMP",
                        Value = 42
                    }]
            }));
        }

        [TestMethod]
        public void Test_incorrect_temperature_upper_edge()
        {
            Assert.IsFalse(valid.IsValid(new RequestMeasurements()
            {
                Measurements = [
                    new Measurement
                    {
                        Type = "TEMP",
                        Value = 43
                    }]
            }));
        }




    }
}