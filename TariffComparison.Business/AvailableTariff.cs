using System.Collections.Generic;

namespace TariffComparison.Business
{
    public class AvailableTariff : TariffComparer
    {
        public override Product CreateBasicProduct()
        {
            return new BasicProduct();
        }

        public override Product CreatePackageProduct()
        {
            return new PackageProduct();
        }

        public List<Product> GetAllTariffs()
        {
            return new List<Product> {CreateBasicProduct(), CreatePackageProduct()};
        }
    }
}