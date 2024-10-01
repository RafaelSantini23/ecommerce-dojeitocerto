using ecommerce.Core.Domain.Enums;

namespace ecommerce.Infraestructure.Interfaces
{
    public interface IPagamentoRepositorio
    {
        Task<bool> AtualizarStatusPedidoPagamento(int id, EnumStatus status);
    }
}
