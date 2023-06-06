using CongestionTaxCalculator.CongestionTaxCalculatorNetCore.Entities;
using CongestionTaxCalculator.CongestionTaxCalculatorNetCore.Enums;
using CongestionTaxCalculator.CongestionTaxCalculatorNetCore.Services;
using CongestionTaxCalculator.EndPoint.Models;
using CongestionTaxCalculatorNetCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CongestionTaxCalculator.EndPoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CongestionTaxCalculatorController : ControllerBase
    {
        private readonly CongestionTaxCalculatorService _congestionTaxCalculatorService;
        private readonly IConfiguration _configuration;

        public CongestionTaxCalculatorController(CongestionTaxCalculatorService congestionTaxCalculatorService,
            IConfiguration configuration)
        {
            _congestionTaxCalculatorService = congestionTaxCalculatorService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult CalculateTax([FromQuery] CalculateTaxModel calculateTaxModel)
        {
            // There are some comments on the code that should be completed at the right time. You can find them by searching the word "todo".

            var cities = _configuration.GetSection("CityTaxRuleConfig").Get<List<City>>();

            var city = cities.FirstOrDefault(c => c.Name.ToLower().Equals(calculateTaxModel.CityName.ToLower())) ?? 
                throw new ArgumentOutOfRangeException(nameof(calculateTaxModel.CityName), "Invalid city name");
            
            Vehicle vehicle = calculateTaxModel.VehicleName.ToLower() switch
            {
                "car" => new Car(VehicleType.None),
                "motorcycle" => new Motorcycle(VehicleType.None),
                "bus" => new Bus(VehicleType.None),
                "tractor" => new Tractor(VehicleType.None),
                _ => throw new ArgumentOutOfRangeException(nameof(calculateTaxModel.VehicleName), "Invalid vehicle name"),
            };

            var taxSum = _congestionTaxCalculatorService.GetTax(city, vehicle, calculateTaxModel.DateTimes);

            return Ok(taxSum);
        }
    }
}