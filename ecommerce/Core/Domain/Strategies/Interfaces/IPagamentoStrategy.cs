using ecommerce.Core.Domain.Model.Pedido;

namespace ecommerce.Core.Domain.Strategies.Interfaces
{
    public interface IPagamentoStrategy
    {
        bool ProcessarPagamento(Pedido pedido);
    }
}
