using System;

namespace CongestionTaxCalculator.CongestionTaxCalculatorNetCore.Specifications
{
    public class TollFreeDateSpecification : ITollFreeDateSpecification
    {
        public bool IsSatisfied(DateTime date)
        {
            return IsTollFreeDate(date);
        }

        private static bool IsTollFreeDate(DateTime date)
        {

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            if (IsWeekend(date)) return true;

            if (!IsInYear2013(date)) return true;

            if (IsInJuly(date)) return true;

            if (IsInPublicHoliday(date)) return true;

            if (IsDayBeforePublicHoliday(date)) return true;

            return false;
        }

        private static bool IsInYear2013(DateTime date)
        {
            return date.Year == 2013;
        }
        private static bool IsInPublicHoliday(DateTime date)
        {
            // todo: should complete later
            // better to throw new NotImplementedException();
            return false;
        }

        private static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek.Equals(DayOfWeek.Saturday) || date.DayOfWeek.Equals(DayOfWeek.Sunday);
        }

        private static bool IsDayBeforePublicHoliday(DateTime date)
        {
            // todo: should complete later
            // better to throw new NotImplementedException();
            return false;
        }

        private static bool IsInJuly(DateTime date)
        {
            return date.Month.Equals(7);
        }
    }
}