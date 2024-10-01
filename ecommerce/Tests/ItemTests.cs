using System;
using ecommerce.Core.Domain.Model.Pedido;
using Xunit;

public class ItemTests
{
    [Fact]
    public void CalculaQuantidadePreco_SemDesconto()
    {
        // Arrange
        var item = new Item(5, 20m); 

        // Act
        var preco = item.CalculaQuantidadePreco(20m);

        // Assert
        Assert.Equal(100m, preco); 
    }

    [Fact]
    public void CalculaQuantidadePreco_ComDescontoDe10Porcento()
    {
        // Arrange
        var item = new Item(15, 20m); 

        // Act
        var preco = item.CalculaQuantidadePreco(20m);

        // Assert
        Assert.Equal(270m, preco);
    }

    [Fact]
    public void CalculaQuantidadePreco_ComDescontoDe20Porcento()
    {
        // Arrange
        var item = new Item(25, 20m); 

        // Act
        var preco = item.CalculaQuantidadePreco(20m);

        // Assert
        Assert.Equal(400m, preco); 
    }
}
