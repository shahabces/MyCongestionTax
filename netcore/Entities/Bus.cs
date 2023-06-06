using CongestionTaxCalculator.CongestionTaxCalculatorNetCore;
using CongestionTaxCalculator.CongestionTaxCalculatorNetCore.Enums;
using System.Security.Principal;

namespace CongestionTaxCalculatorNetCore.Entities
{
    public class Bus : Vehicle
    {
        public Bus(VehicleType vehicleType)
        {
            Type = vehicleType;
        }

        private Bus() { }

        public override string GetVehicleType()
        {
            return AppConsts.Vehicles.Bus;
        }

        public override bool IsToolFree()
        {
            return true;
        }
    }
}