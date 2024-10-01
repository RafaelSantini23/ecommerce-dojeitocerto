using ecommerce.Core.Domain.Enums;
using ecommerce.Core.Services.Interfaces;
using ecommerce.Infraestructure.Repositories;

namespace ecommerce.Application.Services.EstoqueService
{
    public class EstoqueServico : IEstoqueService
    {
        private readonly IEstoqueRepositorio _estoqueRepositorio;
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public EstoqueServico(IEstoqueRepositorio estoqueRepositorio, IPedidoRepositorio pedidoRepositorio)
        {
            _estoqueRepositorio = estoqueRepositorio;
            _pedidoRepositorio = pedidoRepositorio;
        }

        public async Task<bool> SepararPedido(int id)
        {
            var pedido = await _pedidoRepositorio.ObterPedidoPorId(id);

            if (pedido.Status != EnumStatus.PagamentoConcluído)
                return false;

            var itens = await _pedidoRepositorio.ObterItens(pedido.Id);

            pedido.DefinirStatus(EnumStatus.SeparandoPedido);

            bool todosProdutosDisponiveis = itens.All(item => item.Quantidade > 0);

            if (todosProdutosDisponiveis)
            {
                pedido.DefinirStatus(EnumStatus.Concluido);
                await _estoqueRepositorio.AtualizarStatusPedidoEstoque(id, pedido.Status);
                return await _estoqueRepositorio.DiminuirEstoque(id);
            }
            
            pedido.DefinirStatus(EnumStatus.AguardandoEstoque);
            await _estoqueRepositorio.AtualizarStatusPedidoEstoque(id, pedido.Status);
            return false;
        }

        public async Task<bool> CancelarPedido(int id)
        {
            var pedido = await _pedidoRepositorio.ObterPedidoPorId(id);
            
            if(pedido.Status == EnumStatus.AguardandoEstoque)
            {
                return await _estoqueRepositorio.AtualizarStatusPedidoEstoque(id, EnumStatus.Cancelado);
            }

            return false;
        }
    }
}