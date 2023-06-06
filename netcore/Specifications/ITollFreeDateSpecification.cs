using System;

namespace CongestionTaxCalculator.CongestionTaxCalculatorNetCore.Specifications
{
    public interface ITollFreeDateSpecification
    {
        bool IsSatisfied(DateTime date);
    }
}