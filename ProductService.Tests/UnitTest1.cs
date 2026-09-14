using ProductService.DTOs;

namespace ProductService.Tests;

public class ProductDtoTests
{
    [Test]
    public void CreateProductDto_ProductName_Should_Be_Assigned()
    {
        var dto = new CreateProductDto
        {
            ProductName = "Laptop"
        };

        Assert.That(dto.ProductName, Is.EqualTo("Laptop"));
    }

    [Test]
    public void CreateProductDto_Price_Should_Be_Assigned()
    {
        var dto = new CreateProductDto
        {
            Price = 50000
        };

        Assert.That(dto.Price, Is.EqualTo(50000));
    }

    [Test]
    public void UpdateProductDto_ProductName_Should_Be_Assigned()
    {
        var dto = new UpdateProductDto
        {
            ProductName = "Mobile"
        };

        Assert.That(dto.ProductName, Is.EqualTo("Mobile"));
    }

    [Test]
    public void UpdateProductDto_Quantity_Should_Be_Assigned()
    {
        var dto = new UpdateProductDto
        {
            Quantity = 10
        };

        Assert.That(dto.Quantity, Is.EqualTo(10));
    }
}
