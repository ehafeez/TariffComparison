using System;

namespace TariffComparison.Business
{
    public class PackageProduct : Product
    {
        public sealed override string Name { get; set; }

        public PackageProduct()
        {
            Name = "Packaged Tariff";
        }

        public override decimal CostCalulation(double consumption)
        {
            if (consumption <= 0)
                return 0;

            decimal minimumCost = 800;
            var diff = consumption - 4000;
            if (diff < 0)
                return minimumCost;

            return minimumCost + Convert.ToDecimal(diff * 0.30);
        }
    }
}