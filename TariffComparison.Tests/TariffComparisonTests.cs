using Microsoft.AspNetCore.Mvc;
using TariffComparison.Api.Controllers;
using TariffComparison.Business;
using Xunit;

namespace TariffComparison.Tests
{
    public class TariffComparisonTests
    {
        [Fact]
        public void Get_Package_Tariff_With_6000_Kw()
        {
            var packageProduct = new PackageProduct();
            var cost = packageProduct.CostCalulation(6000);

            Assert.Equal(1400, cost);
        }

        [Fact]
        public void Get_Basic_Tariff_With_6000_Kw()
        {
            var basicProduct = new BasicProduct();
            var cost = basicProduct.CostCalulation(6000);
            Assert.Equal(1380, cost);
        }

        [Fact]
        public void Get_Package_Tariff_With_Negitive_Kw()
        {
            var packageProduct = new PackageProduct();
            var cost = packageProduct.CostCalulation(-1);
            Assert.Equal(0, cost);
        }

        [Fact]
        public void Get_Basic_Tariff_With_Negitive_Kw()
        {
            var basicProduct = new BasicProduct();
            var cost = basicProduct.CostCalulation(-40);
            Assert.Equal(0, cost);
        }

        [Fact]
        public void Get_Basic_Tariff_With_Double_Value_Kw()
        {
            var basicProduct = new BasicProduct();
            var cost = basicProduct.CostCalulation(1400.60);
            Assert.Equal(368.132m, cost);
        }

        [Fact]
        public void Get_Package_Tariff_With_Minimum_Kw()
        {
            var packageProduct = new PackageProduct();
            var cost = packageProduct.CostCalulation(1000);
            Assert.Equal(800, cost);
        }

        [Fact]
        public void Get_Package_Tariff_With_Wrong_Kw()
        {
            var packageProduct = new PackageProduct();
            var cost = packageProduct.CostCalulation(12);
            Assert.Equal(800, cost);
        }

        [Fact]
        public void Get_All_Tariffs()
        {
            var tariffs = new AvailableTariff();
            var allTariffs = tariffs.GetAllTariffs();

            Assert.Equal(2, allTariffs.Count);
            Assert.NotEmpty(allTariffs);
        }

        [Fact]
        public void Get_Basic_Product_Tariff()
        {
            var tariffs = new AvailableTariff();
            var basicProduct = tariffs.CreateBasicProduct();
            Assert.IsType<BasicProduct>(basicProduct);
        }

        [Fact]
        public void Get_Package_Product_Tariff()
        {
            var tariffs = new AvailableTariff();
            var packageProduct = tariffs.CreatePackageProduct();
            Assert.IsType<PackageProduct>(packageProduct);
        }

        [Fact]
        public void Get_Tariff_Api_With_OK_Result()
        {
            var controller = new TariffController();
            var tariffs = controller.Get(3500);
            Assert.IsType<OkObjectResult>(tariffs);
        }

        [Fact]
        public void Get_Tariff_Api_With_Max_Value_Result()
        {
            var controller = new TariffController();
            var tariffs = controller.Get(10000000000000011102);
            Assert.IsType<OkObjectResult>(tariffs);
        }
    }
}