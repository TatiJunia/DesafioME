using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.ME.Domain.Boundary.Compras
{
    public class PedidoInput
    {
        public List<ItemPedidoInput> Itens { get; set; }

        public void Validar()
        {
            if (this.Itens.GroupBy(i => i.ProdutoId).Any(i => i.Count() > 1))
                throw new Exception("O mesmo produto não pode ser incluído mais de uma vez, ajuste a quantidade");
        }
    }
}
