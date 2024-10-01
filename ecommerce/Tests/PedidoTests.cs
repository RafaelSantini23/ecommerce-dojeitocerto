using ecommerce.Core.Domain.Enums;
using ecommerce.Core.Domain.Model.Pedido;
using Xunit;

public class PedidoTests
{
    [Fact]
    public void CalculaPrecoTotalPedido_CalculaCorretamente()
    {
        // Arrange
        var itens = new List<Item>
        {
            new Item(1, 100m),
            new Item(2, 50m)
        };
        var pedido = new Pedido(itens, new DateTime(2023, 10, 1));
        // Act
        var total = pedido.CalculaPrecoTotalPedido();

        // Assert
        Assert.Equal(200m, total);
    }

    [Fact]
    public void CalculaPrecoTotalPedido_AplicarDescontoSazonal()
    {
        // Arrange
        var itens = new List<Item>
        {
            new Item(1, 200m)
        };

        var pedido = new Pedido(itens, new DateTime(2023, 11, 1));

        // Act
        var total = pedido.CalculaPrecoTotalPedido();

        // Assert
        Assert.Equal(140m, total);
    }

    [Fact]
    public void DefinirStatus_DefineStatusCorretamente()
    {
        // Arrange
        var pedido = new Pedido(new List<Item>(), DateTime.Now);

        // Act
        pedido.DefinirStatus(EnumStatus.PagamentoConcluído);

        // Assert
        Assert.Equal(EnumStatus.PagamentoConcluído, pedido.Status);
    }
}