using BmiCalculator.Api.Models;

namespace BmiCalculator.Api.Services
{
    public interface IBmiCalculatorService
    {
        BmiResponseModel CalculateBmi(BmiRequestModel request);
    }

    public class BmiCalculatorService : IBmiCalculatorService
    {
        public BmiResponseModel CalculateBmi(BmiRequestModel request)
        {
            if (request.Height <= 0 || request.Weight <= 0)
            {
                throw new ArgumentException("Height or weight must be positive values.");
            }

            double heightInMeters = request.Height / 100;
            double bmi = request.Weight / (heightInMeters * heightInMeters);

            string category = bmi switch
            {
                < 18.5 => "Underweight",
                < 24.9 => "Normal weight",
                < 29.9 => "Overweight",
                _ => "Obesity",
            };

            return new BmiResponseModel
            {
                Bmi = Math.Round(bmi, 2),
                Category = category
            };
        }
    }
}