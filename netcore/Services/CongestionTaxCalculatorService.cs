using System;
using CongestionTaxCalculator.CongestionTaxCalculatorNetCore.Entities;
using CongestionTaxCalculator.CongestionTaxCalculatorNetCore.Specifications;
using CongestionTaxCalculatorNetCore.Entities;

namespace CongestionTaxCalculator.CongestionTaxCalculatorNetCore.Services
{
    public class CongestionTaxCalculatorService
    {
        private readonly ITollFreeDateSpecification _tollFreeDateSpecification;

        public CongestionTaxCalculatorService(ITollFreeDateSpecification tollFreeDateSpecification)
        {
            _tollFreeDateSpecification = tollFreeDateSpecification;
        }

        public int GetTax(City city, Vehicle vehicle, DateTime[] dates)
        {
            // sort dateTime values
            Array.Sort(dates);

            // todo: should check logic
            DateTime intervalStart = dates[0];
            int totalFee = 0;
            foreach (DateTime date in dates)
            {
                int nextFee = GetTollFee(city, date, vehicle);
                int tempFee = GetTollFee(city, intervalStart, vehicle);

                long diffInMillies = date.Millisecond - intervalStart.Millisecond;
                long minutes = diffInMillies / 1000 / 60;

                if (minutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                }
            }

            if (totalFee > 60) totalFee = 60;

            return totalFee;
        }

        private int GetTollFee(City city, DateTime date, Vehicle vehicle)
        {
            if (_tollFreeDateSpecification.IsSatisfied(date) || vehicle.IsToolFree()) return 0;

            return city.GetTaxForTimespan(new TimeSpan(date.Hour, date.Minute, date.Second));
        }
    }
}