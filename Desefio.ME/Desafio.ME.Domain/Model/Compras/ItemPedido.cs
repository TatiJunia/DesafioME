using Desafio.ME.Domain.Model;
using DesafioME.Domain.Model.Cadastro;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioME.Domain.Model.Compras
{
    public class ItemPedido : Entity
    {
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
        public decimal Quantidade { get; set; }
    }
}
