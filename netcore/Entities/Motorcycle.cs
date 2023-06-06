using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongestionTaxCalculator.CongestionTaxCalculatorNetCore;
using CongestionTaxCalculator.CongestionTaxCalculatorNetCore.Enums;

namespace CongestionTaxCalculatorNetCore.Entities
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(VehicleType vehicleType)
        {
            Type = vehicleType;
        }

        private Motorcycle() { }

        public override string GetVehicleType()
        {
            return AppConsts.Vehicles.Motorcycle;
        }

        public override bool IsToolFree()
        {
            return true;
        }
    }
}