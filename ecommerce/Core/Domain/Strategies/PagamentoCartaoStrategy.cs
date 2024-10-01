using ecommerce.Core.Domain.Model.Pedido;
using ecommerce.Core.Domain.Strategies.Interfaces;

namespace ecommerce.Core.Domain.Strategies
{
    public class PagamentoCartaoStrategy : IPagamentoStrategy
    {
        public bool ProcessarPagamento(Pedido pedido)
        {
            return true;
        }
    }
}
