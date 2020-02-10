namespace TariffComparison.Business
{
    public abstract class Product
    {
        public abstract string Name { get; set; }
        public abstract decimal CostCalulation(double consumption);
    }
}