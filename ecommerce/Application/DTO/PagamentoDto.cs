namespace ecommerce.Application.DTO
{
    public record PagamentoDTO(
        bool pagamentoComPix,
        bool pagamentoParcelado
    );
}
