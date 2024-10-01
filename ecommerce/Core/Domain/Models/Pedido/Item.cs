namespace ecommerce.Core.Domain.Model.Pedido
{
    public class Item
    {
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        protected Item() { }
        public Item(int quantidade, decimal preco)
        {
            Quantidade = quantidade;
            Preco = CalculaQuantidadePreco(preco);
        }

        public decimal CalculaQuantidadePreco(decimal precoItem)
        {
            var preco = precoItem * Quantidade;
            decimal desconto = 0;

            if (Quantidade > 10 && Quantidade <= 20)
            {
                desconto = preco * (10m / 100);
            }
            else if (Quantidade > 20)
            {
                desconto = preco * (20m / 100);
            }

            return preco - desconto;
        }
    }
}
