using ecommerce.Application.DTO;
using ecommerce.Application.Services.PagamentoService;
using ecommerce.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoServico;

        public PagamentoController(IPagamentoService pagamentoServico)
        {
            _pagamentoServico = pagamentoServico;
        }

        [HttpPost("{id}/processar-pagamento")]
        public async Task<IActionResult> ProcessarPagamento(int id, PagamentoDTO pagamentoDTO)
        {
            var pagamentoEfetuado = await _pagamentoServico.ProcessarPagamento(id, pagamentoDTO.pagamentoComPix, pagamentoDTO.pagamentoParcelado);

            return pagamentoEfetuado ? Ok("Pagamento processado com sucesso.") : BadRequest("Erro ao efetuar pagamento");
        }

        [HttpDelete("{id}/cancelar")]
        public async Task<IActionResult> CancelarPagamento(int id)
        {
            var valorRetornado = await _pagamentoServico.CancelarPagamento(id);

            return valorRetornado > 0 ? Ok($"Pagamento cancelado com sucesso valor estornado: {valorRetornado}.") : BadRequest("Pagamento não pode ser cancelado.");
        }
    }
}
