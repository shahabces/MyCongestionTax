using System;
using System.Collections.Generic;

namespace CongestionTaxCalculator.CongestionTaxCalculatorNetCore.Entities
{
    public class City
    {
        public string Name { get; set; }
        public List<TimespanAmountCongestionTax> TimespanAmountCongestionTaxes { get; set; } = new List<TimespanAmountCongestionTax>();

        public int GetTaxForTimespan(TimeSpan timeSpan)
        {
            foreach (var timespanAmountCongestionTax in TimespanAmountCongestionTaxes)
            {
                if (timeSpan >= timespanAmountCongestionTax.From && timeSpan <= timespanAmountCongestionTax.To)
                    return timespanAmountCongestionTax.Amount;
            }

            return 0;
        }
    }

    public class TimespanAmountCongestionTax
    {
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
        public int Amount { get; set; }
    }
}
