using Dapper;
using ecommerce.Core.Domain.Enums;
using ecommerce.Core.Queries;
using ecommerce.Core.Services.Interfaces;
using ecommerce.Infraestructure.DataContext;
using ecommerce.Infraestructure.Interfaces;
using System.Data;

namespace ecommerce.Infraestructure.Repositories
{
    public class EstoqueRepositorio : IEstoqueRepositorio
    {
        private readonly SqlServerContext _context;

        public EstoqueRepositorio(SqlServerContext context)
        {
            _context = context;
        }

        public async Task<bool> AtualizarStatusPedidoEstoque(int id, EnumStatus status)
        {
            using IDbConnection dbConnection = _context.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@PEDIDOID", id);
            parametros.Add("@STATUS", status);

            return await dbConnection.ExecuteAsync(PedidoQueries.AtualizarStatusPedido, parametros) > 0;
        }

        public async Task<bool> DiminuirEstoque(int id)
        {
            using IDbConnection dbConnection = _context.CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@PEDIDOID", id);


            return await dbConnection.ExecuteAsync(PedidoQueries.DiminuirEstoque, parametros) > 0;
        }
    }
}
