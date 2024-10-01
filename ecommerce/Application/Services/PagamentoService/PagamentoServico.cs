using ecommerce.Core.Domain.Enums;
using ecommerce.Core.Domain.Strategies;
using ecommerce.Core.Domain.Strategies.Interfaces;
using ecommerce.Core.Services.Interfaces;
using ecommerce.Core.Utils;
using ecommerce.Infraestructure.Interfaces;
using ecommerce.Infraestructure.Repositories;

namespace ecommerce.Application.Services.PagamentoService
{
    public class PagamentoServico : IPagamentoService
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IPagamentoRepositorio _pagamentoRepositorio;


        public PagamentoServico(IPedidoRepositorio pedidoRepositorio, IPagamentoRepositorio pagamentoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _pagamentoRepositorio = pagamentoRepositorio;
        }

        public async Task<bool> ProcessarPagamento(int pedidoId, bool pagamentoComPix, bool pagamentoParcelado)
        {
            var pedido = await _pedidoRepositorio.ObterPedidoPorId(pedidoId);

            pedido.DefinirStatus(EnumStatus.ProcessandoPagamento);

            IPagamentoStrategy strategy = PagamentoStrategyFactory.CriarStrategy(pagamentoComPix, pagamentoParcelado);

            var contexto = new PagamentoContext(strategy);

            bool sucesso = await RetryPolicy.ExecuteAsync(
                () => Task.FromResult(contexto.ProcessarPagamento(pedido)),
                maxAttempts: 3,
                delay: TimeSpan.FromSeconds(2)
            );

            pedido.DefinirStatus(sucesso ? EnumStatus.PagamentoConcluído : EnumStatus.Cancelado);

            return await _pagamentoRepositorio.AtualizarStatusPedidoPagamento(pedidoId, pedido.Status);

        }

        public async Task<decimal> CancelarPagamento(int pedidoId)
        {
            var pedido = await _pedidoRepositorio.ObterPedidoPorId(pedidoId);

            if (pedido.Status > EnumStatus.PagamentoConcluído)
            {
                await _pagamentoRepositorio.AtualizarStatusPedidoPagamento(pedidoId, EnumStatus.Cancelado);
                return pedido.PrecoTotal;
            }

            return 0;

        }
    }
}
