using ecommerce.Core.Domain.Model.Pedido;
using ecommerce.Core.Domain.Strategies.Interfaces;

namespace ecommerce.Core.Domain.Strategies
{
    public class PagamentoContext
    {
        private readonly IPagamentoStrategy _strategy;

        public PagamentoContext(IPagamentoStrategy strategy)
        {
            _strategy = strategy;
        }

        public bool ProcessarPagamento(Pedido pedido)
        {
            if (pedido == null)
                throw new ArgumentNullException(nameof(pedido), "O pedido não pode ser nulo.");

            return _strategy.ProcessarPagamento(pedido);
        }
    }
}