using Desafio.ME.Domain.Model.Cadastro;
using Desafio.ME.Domain.Model.Compras;
using DesafioME.Domain.Model.Cadastro;
using DesafioME.Domain.Model.Compras;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.ME.UnitTests.Compras
{
    public class PedidoTests
    {
        Pedido Pedido = new Pedido();

        [SetUp]
        public void Setup()
        {
            Produto produto1 = new Produto { Id = 1, Descricao = "Produto1", UnidadeMedida = UnidadeMedida.Unidade, Valor = 10 };
            Produto produto2 = new Produto { Id = 2, Descricao = "Produto2", UnidadeMedida = UnidadeMedida.Unidade, Valor = 20 };

            ItemPedido item1 = new ItemPedido { Id = 1, Pedido = Pedido, Produto = produto1, Quantidade = 10 };
            ItemPedido item2 = new ItemPedido { Id = 2, Pedido = Pedido, Produto = produto2, Quantidade = 2 };

            this.Pedido = new Pedido
            {
                Id = 1,
                DataCriacao = DateTime.Now,
                Itens = new List<ItemPedido>() { item1, item2 }
            };
        }

        [Test]
        public void AlterarStatusAprovado()
        {
            this.Pedido.AlterarStatus(StatusPedido.APROVADO, 2, 140);

            Assert.AreEqual(this.Pedido.GetStatusDetalhado(), StatusPedido.APROVADO);
        }

        [Test]
        public void AlterarStatusAprovadoQuantidadeAMaior()
        {
            this.Pedido.AlterarStatus(StatusPedido.APROVADO, 3, 150);

            Assert.AreEqual(this.Pedido.GetStatusDetalhado(), StatusPedido.APROVADO_QTD_A_MAIOR);
        }

        [Test]
        public void AlterarStatusAprovadoQuantidadeAMenor()
        {
            this.Pedido.AlterarStatus(StatusPedido.APROVADO, 1, 100);

            Assert.AreEqual(this.Pedido.GetStatusDetalhado(), StatusPedido.APROVADO_QTD_A_MENOR);
        }

        [Test]
        public void AlterarStatusAprovadoValorAMenor()
        {
            this.Pedido.AlterarStatus(StatusPedido.APROVADO, 2, 100);

            Assert.AreEqual(this.Pedido.GetStatusDetalhado(), StatusPedido.APROVADO_VALOR_A_MENOR);
        }

        [Test]
        public void AlterarStatusAprovadoValorAMaior()
        {
            this.Pedido.AlterarStatus(StatusPedido.APROVADO, 2, 150);

            Assert.AreEqual(this.Pedido.GetStatusDetalhado(), StatusPedido.APROVADO_VALOR_A_MAIOR);
        }

        [Test]
        public void AlterarStatusPedidoReprovado()
        {
            this.Pedido.AlterarStatus(StatusPedido.REPROVADO, 0, 0);

            Assert.AreEqual(this.Pedido.GetStatusDetalhado(), StatusPedido.REPROVADO);
        }

        [Test]
        public void AlterarStatusPedidoNaoEncontrado()
        {
            var pedido = new Pedido();
            pedido.AlterarStatus(StatusPedido.REPROVADO, 0, 0);

            Assert.AreEqual(pedido.GetStatusDetalhado(), StatusPedido.CODIGO_PEDIDO_INVALIDO);
        }
    }
}
