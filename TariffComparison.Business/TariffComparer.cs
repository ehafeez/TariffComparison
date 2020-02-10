namespace TariffComparison.Business
{
    public abstract class TariffComparer
    {
        public abstract Product CreateBasicProduct();
        public abstract Product CreatePackageProduct();
    }
}