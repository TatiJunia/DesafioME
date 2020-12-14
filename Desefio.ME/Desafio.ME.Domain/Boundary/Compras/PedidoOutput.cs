using DesafioME.Domain.Model.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.ME.Domain.Boundary.Compras
{
    public class PedidoOutput
    {
        public long Pedido { get; set; }
        public List<ItemPedidoOutput> Itens { get; set; }

        public static PedidoOutput From(Pedido pedido)
        {
            if (pedido == null)
                return null;

            var output = new PedidoOutput();
            output.Pedido = pedido.Id;
            output.Itens = pedido.Itens.Select(i => ItemPedidoOutput.From(i)).ToList();

            return output;
        }
    }
}
