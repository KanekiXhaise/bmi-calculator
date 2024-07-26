using BmiCalculator.Api.Services;
using BmiCalculator.Api.Models;
using FluentAssertions;

namespace BmiCalculatorApi.Tests;

public class BmiTest
{
    private readonly BmiCalculatorService _bmiCalculatorService;

    public BmiTest()
    {
        _bmiCalculatorService = new BmiCalculatorService();
    }

    [Fact]
    public void CalculateBmi_ShouldReturnCorrectResult()
    {
        // Arrange
        var request = new BmiRequestModel { Height = 170, Weight = 70 };

        // Act
        var response = _bmiCalculatorService.CalculateBmi(request);

        // Assert
        response.Bmi.Should().BeApproximately(24.22, 0.01);
        response.Category.Should().Be("Normal weight");
    }

    [Fact]
    public void CalculateBmi_ShouldThrowArgumentException_ForInvalidInput()
    {
        // Arrange
        var request = new BmiRequestModel { Height = -170, Weight = 70 };

        // Act
        var response = () => _bmiCalculatorService.CalculateBmi(request);

        // Assert
        response.Should().Throw<ArgumentException>().WithMessage("Height or weight must be positive values.");
    }
}