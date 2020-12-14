using Desafio.ME.Domain.Repository.Compras;
using DesafioME.Domain.Model.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.ME.Infrastructure.Repository.Compras
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(EFContext context) : base(context) { }
    }
}
