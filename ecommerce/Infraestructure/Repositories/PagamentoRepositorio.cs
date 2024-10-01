using Dapper;
using ecommerce.Core.Domain.Enums;
using ecommerce.Core.Queries;
using ecommerce.Infraestructure.DataContext;
using ecommerce.Infraestructure.Interfaces;
using System.Data;

namespace ecommerce.Infraestructure.Repositories
{
    public class PagamentoRepositorio : IPagamentoRepositorio
    {
        private readonly SqlServerContext _context;

        public PagamentoRepositorio(SqlServerContext context)
        {
            _context = context;
        }

        public async Task<bool> AtualizarStatusPedidoPagamento(int id, EnumStatus status)
        {
            using IDbConnection dbConnection = _context.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@PEDIDOID", id);
            parametros.Add("@STATUS", status);

            return await dbConnection.ExecuteAsync(PedidoQueries.AtualizarStatusPedido, parametros) > 0;
        }
    }
}
