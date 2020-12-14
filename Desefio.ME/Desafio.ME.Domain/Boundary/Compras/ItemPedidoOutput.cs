using DesafioME.Domain.Model.Compras;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.ME.Domain.Boundary.Compras
{
    public class ItemPedidoOutput
    {
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Qtd { get; set; }

        internal static ItemPedidoOutput From(ItemPedido itemPedido)
        {
            if (itemPedido == null)
                return null;

            var output = new ItemPedidoOutput();
            output.Descricao = itemPedido.Produto.Descricao;
            output.PrecoUnitario = itemPedido.Produto.Valor;
            output.Qtd = itemPedido.Quantidade;
            
            return output;
        }
    }
}
