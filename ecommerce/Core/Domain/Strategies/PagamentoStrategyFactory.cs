using ecommerce.Core.Domain.Strategies.Interfaces;

namespace ecommerce.Core.Domain.Strategies
{
    public static class PagamentoStrategyFactory
    {
        public static IPagamentoStrategy CriarStrategy(bool pagamentoComPix, bool pagamentoParcelado)
        {
            if (pagamentoComPix)
                return new PagamentoPixStrategy();
            else if (pagamentoParcelado)
                return new PagamentoCartaoStrategy();
            else
                throw new Exception("Método de pagamento inválido.");
        }
    }
}