using ecommerce.Core.Domain.Enums;

namespace ecommerce.Core.Services.Interfaces
{
    public interface IEstoqueRepositorio
    {
        Task<bool> AtualizarStatusPedidoEstoque(int id, EnumStatus status);
        Task<bool> DiminuirEstoque(int id);
    }
}
