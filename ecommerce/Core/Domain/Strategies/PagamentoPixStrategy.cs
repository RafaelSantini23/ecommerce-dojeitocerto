using ecommerce.Core.Domain.Model.Pedido;
using ecommerce.Core.Domain.Strategies.Interfaces;

namespace ecommerce.Core.Domain.Strategies
{
    public class PagamentoPixStrategy : IPagamentoStrategy
    {
        public bool ProcessarPagamento(Pedido pedido)
        {
            pedido.PrecoTotal *= 0.95m;
            return true;
        }
    }
}
