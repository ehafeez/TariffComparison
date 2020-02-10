using System;
namespace TariffComparison.Business
{
    public class BasicProduct : Product
    {
        public sealed override string Name { get; set; }

        public BasicProduct()
        {
            Name = "Basic Electricity Tariff";
        }

        public override decimal CostCalulation(double consumption)
        {
            if (consumption <= 0)
                return 0;

            const int perMonthUnit = 5;
            var annualCost = (perMonthUnit * 12) + (consumption * 0.22);
            return Convert.ToDecimal(annualCost);
        }
    }
}