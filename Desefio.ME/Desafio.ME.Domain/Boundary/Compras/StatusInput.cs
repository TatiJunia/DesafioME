using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.ME.Domain.Boundary.Compras
{
    public class StatusInput
    {
        public string Status { get; set; }
        public long Pedido { get; set; }
        public int ItensAprovados { get; set; }
        public decimal ValorAprovado { get; set; }
    }
}
