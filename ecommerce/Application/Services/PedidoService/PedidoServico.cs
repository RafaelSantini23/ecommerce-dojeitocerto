using ecommerce.Application.DTO;
using ecommerce.Core.Domain.Enums;
using ecommerce.Core.Domain.Model.Pedido;
using ecommerce.Core.Services.Interfaces;
using ecommerce.Infraestructure.Repositories;

namespace ecommerce.Application.Services.PedidoService
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidoService(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        public async Task<Pedido> ObterPedido()
        {
            var pedido = await _pedidoRepositorio.ObterPedidos();

            var itens = await _pedidoRepositorio.ObterItens(pedido.Id);

            pedido.DefinirItens(itens);

            return pedido;
        }

        public async Task<bool> CriarPedido(PedidoDto pedidoDto)
        {
            var pedido = new Pedido(pedidoDto.Itens.Select(item => new Item(item.Quantidade, item.Preco)), DateTime.Now);

            var pedidoId = await _pedidoRepositorio.CriarPedido(pedido);

            foreach (var itemDto in pedidoDto.Itens)
            {
                var item = new Item(itemDto.Quantidade, itemDto.Preco);
                await _pedidoRepositorio.CriarItem(pedidoId, item);
            }

            return true;

        }

        public async Task<bool> CancelarPedido(int pedidoId)
        {
            var pedido = await _pedidoRepositorio.ObterPedidoPorId(pedidoId);

            if (pedido.Status == EnumStatus.AguardandoProcesamento)
            {
                return await _pedidoRepositorio.AtualizarStatusPedido(pedidoId, EnumStatus.Cancelado);
            }

            return false;

        }
    }
}
