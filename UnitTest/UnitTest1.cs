using TaskMVC.Entity;

namespace UnitTest
{
    public class UnitTest1
    {
        public class ProductService
        {
            private readonly double VAT;
          
            public ProductService(double vat) => VAT = vat;
            public double CalculateTotalPriceWithVat(Product product) => (product.Quantiy * product.Price) * (1 + VAT);
        }
        public class ProductServiceTests
        {
            [Fact]
            public void CalculateTotalPriceWithVAT_ShouldCalculateCorrectly()
            {
                // Arrange
                var productService = new ProductService(0.2); // Assuming 20% VAT
                var product = new Product { Quantiy = 5, Price = 10 };

                // Act
                var result = productService.CalculateTotalPriceWithVat(product);

                // Assert
                Assert.Equal(60, result);
            }
        }
    }
}