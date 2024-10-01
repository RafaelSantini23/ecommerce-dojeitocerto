using ecommerce.Application.Services.EstoqueService;
using ecommerce.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueServico;

        public EstoqueController(IEstoqueService estoqueServico)
        {
            _estoqueServico = estoqueServico;
        }

        [HttpPost("{id}/separar-pedido")]
        public async Task<IActionResult> SepararPedido(int id)
        {
            var pedidoSeparado = await _estoqueServico.SepararPedido(id);

            return pedidoSeparado ? Ok("Pedido separado com sucesso.") : BadRequest("Pedido não pode ser separado.");
        }

        [HttpDelete("{id}/cancelar")]
        public async Task<IActionResult> CancelarPedido(int id)
        {
            var pedidoCancelado = await _estoqueServico.CancelarPedido(id);

            return pedidoCancelado ? Ok("Pedido cancelado com sucesso.") : BadRequest("Pedido não pode ser cancelado.");
        }
    }
}
