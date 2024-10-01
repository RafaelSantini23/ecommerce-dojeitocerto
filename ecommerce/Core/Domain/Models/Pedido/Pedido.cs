using ecommerce.Core.Domain.Enums;

namespace ecommerce.Core.Domain.Model.Pedido
{
    public class Pedido
    {
        public int Id { get; set; }
        public IEnumerable<Item> Itens { get; set; }
        public EnumStatus Status { get; set; }
        public decimal PrecoTotal { get; set; }
        public DateTime Data { get; set; }

        protected Pedido() { }

        public Pedido(IEnumerable<Item> itens, DateTime data)
        {
            Itens = itens;
            PrecoTotal = CalculaPrecoTotalPedido();
            Data = data;
        }

        public decimal CalculaPrecoTotalPedido()
        {
            PrecoTotal = 0;

            foreach (var item in Itens)
            {
                PrecoTotal += item.Preco;
            }

            CalculaDescontoSazonal();

            return PrecoTotal;
        }

        public void CalculaDescontoSazonal()
        {
            var mesesDesconto = new Dictionary<int, decimal>()
            {
                { (int)EnumMesDesconto.Dezembro, 20m },
                { (int)EnumMesDesconto.Novembro, 30m },
                { (int)EnumMesDesconto.Agosto, 10m },
                { (int)EnumMesDesconto.Junho, 10m },
                { (int)EnumMesDesconto.Marco, 15m },
                { (int)EnumMesDesconto.Janeiro, 15m },
            };

            var descontoMes = mesesDesconto.TryGetValue(Data.Month, out decimal desconto);

            var valorDescontoTotal = desconto / 100 * PrecoTotal;

            PrecoTotal = PrecoTotal - valorDescontoTotal;
        }

        public void DefinirStatus(EnumStatus status)
        {
            Status = status;
        }

        public void DefinirItens(IEnumerable<Item> itens)
        {
            Itens = itens;
        }

    }
}
