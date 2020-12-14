using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.ME.Domain.Boundary.Compras
{
    public class ItemPedidoInput
    {
        public long ProdutoId { get; set; }
        public decimal Qtd { get; set; }
    }
}
