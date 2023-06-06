using CongestionTaxCalculator.CongestionTaxCalculatorNetCore;
using CongestionTaxCalculator.CongestionTaxCalculatorNetCore.Enums;

namespace CongestionTaxCalculatorNetCore.Entities
{
    public class Tractor : Vehicle
    {
        public Tractor(VehicleType vehicleType)
        {
            Type = vehicleType;
        }

        private Tractor() { }

        public override string GetVehicleType()
        {
            return AppConsts.Vehicles.Tractor;
        }
    }
}