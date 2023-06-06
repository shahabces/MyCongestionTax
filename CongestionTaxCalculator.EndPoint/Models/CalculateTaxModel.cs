using CongestionTaxCalculator.CongestionTaxCalculatorNetCore;
using System.ComponentModel.DataAnnotations;

namespace CongestionTaxCalculator.EndPoint.Models
{
    public class CalculateTaxModel
    {
        [Required]
#pragma warning disable CS8618
        public string VehicleName { get; set; }


        [Required]
#pragma warning disable CS8618
        public string CityName { get; set; }

        [Required]
        public DateTime[] DateTimes { get; set; }
    }
}
