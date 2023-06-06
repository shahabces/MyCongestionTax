using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongestionTaxCalculator.CongestionTaxCalculatorNetCore;
using CongestionTaxCalculator.CongestionTaxCalculatorNetCore.Enums;

namespace CongestionTaxCalculatorNetCore.Entities
{
    public class Car : Vehicle
    {
        public Car(VehicleType vehicleType)
        {
            Type = vehicleType;
        }

        private Car() { }

        public override string GetVehicleType()
        {
            return AppConsts.Vehicles.Car;
        }
    }
}