using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongestionTaxCalculator.CongestionTaxCalculatorNetCore.Enums;

namespace CongestionTaxCalculatorNetCore.Entities
{
    public abstract class Vehicle
    {
        #region properties
        public VehicleType Type { get; protected set; }
        #endregion

        #region methods
        public abstract string GetVehicleType();

        public virtual bool IsToolFree()
        {
            return !(Type == VehicleType.None);
        }
        #endregion

    }
}