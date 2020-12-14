using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.ME.Domain.Model.Cadastro;
using Desafio.ME.Domain.Repository.Cadastro;
using Desafio.ME.Domain.Repository.Compras;
using Desafio.ME.Domain.Services;
using Desafio.ME.Infrastructure;
using Desafio.ME.Infrastructure.Repository.Cadastro;
using Desafio.ME.Infrastructure.Repository.Compras;
using Desafio.ME.Services.Compras;
using DesafioME.Domain.Model.Cadastro;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Desafio.ME.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EFContext>(opt => opt.UseInMemoryDatabase("DesafioME"));
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoService, PedidoService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AdicionaProdutos(EFContext context)
        {
            context.Produtos.Add(new Produto() { Id = 1, Descricao = "TESTE 1", UnidadeMedida = UnidadeMedida.Unidade });
            context.Produtos.Add(new Produto() { Id = 2, Descricao = "TESTE 2", UnidadeMedida = UnidadeMedida.Unidade });
            context.Produtos.Add(new Produto() { Id = 3, Descricao = "TESTE 3", UnidadeMedida = UnidadeMedida.Unidade });
            context.Produtos.Add(new Produto() { Id = 4, Descricao = "TESTE 4", UnidadeMedida = UnidadeMedida.Unidade });
            context.Produtos.Add(new Produto() { Id = 5, Descricao = "TESTE 5", UnidadeMedida = UnidadeMedida.Unidade });
            context.SaveChanges();
        }
    }
}
