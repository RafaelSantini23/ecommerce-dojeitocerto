namespace ecommerce.Core.Services.Interfaces
{
    public interface IEstoqueService
    {
        Task<bool> SepararPedido(int id);
        Task<bool> CancelarPedido(int id);
    }
}
