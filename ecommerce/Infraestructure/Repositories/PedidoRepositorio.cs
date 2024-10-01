using Dapper;
using ecommerce.Core.Domain.Enums;
using ecommerce.Core.Domain.Model.Pedido;
using ecommerce.Core.Queries;
using ecommerce.Core.Services.Interfaces;
using ecommerce.Infraestructure.DataContext;
using System.Data;

namespace ecommerce.Infraestructure.Repositories
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly SqlServerContext _context;

        public PedidoRepositorio(SqlServerContext context)
        {
            _context = context;
        }

        public async Task<Pedido> ObterPedidos()
        {
            using IDbConnection dbConnection = _context.CreateConnection();

            return await dbConnection.QueryFirstAsync<Pedido>(PedidoQueries.ObterPedidos);
        }

        public async Task<Pedido> ObterPedidoPorId(int id)
        {
            using IDbConnection dbConnection = _context.CreateConnection();
            var parametros = new DynamicParameters();

            parametros.Add("@PEDIDOID", id);

            return await dbConnection.QueryFirstAsync<Pedido>(PedidoQueries.ObterPedido, parametros);
        }

        public async Task<IEnumerable<Item>> ObterItens(int id)
        {
            using IDbConnection dbConnection = _context.CreateConnection();

            var parametros = new DynamicParameters();

            parametros.Add("@PEDIDOID", id);

            return await dbConnection.QueryAsync<Item>(PedidoQueries.ObterItens, parametros);
        }

        public async Task<int> CriarPedido(Pedido pedido)
        {
            using IDbConnection dbConnection = _context.CreateConnection();

            var parametros = new DynamicParameters();

            parametros.Add("@STATUS", EnumStatus.AguardandoProcesamento);
            parametros.Add("@PRECOTOTAL", pedido.PrecoTotal);


            return await dbConnection.QuerySingleAsync<int>(PedidoQueries.InserePedido, parametros);
        }

        public async Task<bool> CriarItem(int pedidoId, Item item)
        {
            using IDbConnection dbConnection = _context.CreateConnection();

            var parametros = new DynamicParameters();

            parametros.Add("@PEDIDOID", pedidoId);
            parametros.Add("@PRECO", item.Preco);
            parametros.Add("@QUANTIDADE", item.Quantidade);


            return await dbConnection.ExecuteAsync(PedidoQueries.InsereItem, parametros) > 1;
        }

        public async Task<bool> AtualizarStatusPedido(int id, EnumStatus status)
        {
            using IDbConnection dbConnection = _context.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@ID", id);
            parametros.Add("@STATUS", status);

            return await dbConnection.ExecuteAsync(PedidoQueries.AtualizarStatusPedido, parametros) > 0;
        }
    }
}
