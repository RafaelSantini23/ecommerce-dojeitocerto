namespace ecommerce.Core.Queries
{
    public static class PedidoQueries
    {
        public static string InserePedido = $@"INSERT INTO PEDIDOS (Status, PrecoTotal, Data) 
                                                OUTPUT INSERTED.[Id] 
                                                values (@STATUS, @PRECOTOTAL, GETDATE())";

        public static string InsereItem   = $@"INSERT INTO ITENS (PedidoId, Preco, Quantidade) values (@PEDIDOID, @PRECO, @QUANTIDADE)";
        
        public static string ObterPedidos = $@"SELECT Id, Status, PrecoTotal, Data FROM PEDIDOS";

        public static string ObterPedido = $@"SELECT Id, Status, PrecoTotal, Data FROM PEDIDOS WHERE Id = @PEDIDOID";

        public static string ObterItens  = $@"SELECT Quantidade, Preco FROM Itens WHERE PedidoId = @PEDIDOID";

        public static string AtualizarStatusPedido = $@"UPDATE PEDIDOS SET STATUS = @STATUS WHERE ID = @PEDIDOID";

        public static string DiminuirEstoque = $@"UPDATE ITENS SET QUANTIDADE = 0 WHERE PEDIDOID = @PEDIDOID";

    }
}

