using ecommerce.Application.Services.EstoqueService;
using ecommerce.Application.Services.PagamentoService;
using ecommerce.Application.Services.PedidoService;
using ecommerce.Core.Domain.Strategies;
using ecommerce.Core.Domain.Strategies.Interfaces;
using ecommerce.Core.Services.Interfaces;
using ecommerce.Infraestructure.DataContext;
using ecommerce.Infraestructure.Interfaces;
using ecommerce.Infraestructure.Repositories;
using Microsoft.Extensions.Options;

namespace ecommerce.StartupInfra
{
    internal static class ServicesExtensions
    {
        public static Settings GetSettings(this IServiceCollection services) =>
             services
            .BuildServiceProvider()
            .GetRequiredService<IOptions<Settings>>()
            .Value;

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<SqlServerContext>();

            // Services
            services.AddSingleton<IPagamentoService, PagamentoServico>();
            services.AddSingleton<IPedidoService, PedidoService>();
            services.AddSingleton<IEstoqueService, EstoqueServico>();

            // Strategies
            services.AddScoped<IPagamentoStrategy, PagamentoPixStrategy>();
            services.AddScoped<IPagamentoStrategy, PagamentoCartaoStrategy>();
            services.AddScoped<PagamentoContext>();


            // Repositories
            services.AddTransient<IPedidoRepositorio, PedidoRepositorio>();
            services.AddTransient<IEstoqueRepositorio, EstoqueRepositorio>();
            services.AddTransient<IPagamentoRepositorio, PagamentoRepositorio>();


            return services;
        }

    }
}
