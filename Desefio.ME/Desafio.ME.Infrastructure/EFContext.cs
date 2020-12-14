using DesafioME.Domain.Model.Cadastro;
using DesafioME.Domain.Model.Compras;
using DesafioME.Domain.Model.Seguranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.ME.Infrastructure
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
          : base(options)
        { }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
