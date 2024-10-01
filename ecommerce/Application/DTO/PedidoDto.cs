namespace ecommerce.Application.DTO
{
    public record PedidoDto(
        IEnumerable<ItemDto> Itens
    );
}
