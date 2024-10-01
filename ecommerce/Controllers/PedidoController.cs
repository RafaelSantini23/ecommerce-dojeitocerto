using ecommerce.Application.DTO;
using ecommerce.Application.Services.PedidoService;
using ecommerce.Core.Domain.Model.Pedido;
using ecommerce.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoServico;

        public PedidoController(IPedidoService pedidoServico)
        {
            _pedidoServico = pedidoServico;
        }

        [HttpPost]
        public async Task<ActionResult> CancelarPedido(PedidoDto pedidoDto)
        {
            var pedidoCriado = await _pedidoServico.CriarPedido(pedidoDto);

            return pedidoCriado ? Ok("Pedido criado com sucesso.") : BadRequest("Erro ao criar pedido.");
        }

        [HttpGet]
        public async Task<ActionResult<Pedido>> ObterPedido()
        {
            var pedido = await _pedidoServico.ObterPedido();

            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        [HttpDelete("{id}/cancelar")]
        public async Task<ActionResult> CancelarPedido(int id)
        {
            var pedidoCancelado = await _pedidoServico.CancelarPedido(id);

            return pedidoCancelado ? Ok("Pedido cancelado com sucesso.") : BadRequest("Pedido não pode ser cancelado.");
        }

        
    }
}
