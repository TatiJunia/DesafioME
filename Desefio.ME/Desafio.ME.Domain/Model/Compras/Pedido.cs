using Desafio.ME.Domain.Model;
using Desafio.ME.Domain.Model.Compras;
using DesafioME.Domain.Model.Cadastro;
using DesafioME.Domain.Model.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioME.Domain.Model.Compras
{
    public class Pedido : Entity
    {
        public Pedido()
        {
            this.Itens = new List<ItemPedido>();
        }

        public DateTime DataCriacao { get; set; }
        public Usuario UsuarioCriacao { get; set; }
        public ICollection<ItemPedido> Itens { get; set; }
        public decimal ValorTotal
        {
            get
            {
                return this.Itens.Sum(i => i.Quantidade * i.Produto.Valor);
            }
        }

        public string Status { get; set; }
        public int QuantidadeItensAprovados { get; set; }
        public decimal ValorAprovado { get; set; }

        public void AlterarStatus(string status, int quantidadeItensAprovados, decimal valorAprovado)
        {
            if (status != StatusPedido.APROVADO && status != StatusPedido.REPROVADO)
                throw new Exception("Status inválido. Por favor informe se o pedido está aprovado ou reprovado");

            if (this.Id == 0)
            {
                this.Status = StatusPedido.CODIGO_PEDIDO_INVALIDO;
            }
            else
            {
                this.Status = status;

                if (status == StatusPedido.REPROVADO)
                {
                    this.QuantidadeItensAprovados = 0;
                    this.ValorAprovado = 0;
                }
                else if (status == StatusPedido.APROVADO)
                {
                    this.QuantidadeItensAprovados = quantidadeItensAprovados;
                    this.ValorAprovado = valorAprovado;
                }
            }
        }

        public string GetStatusDetalhado()
        {
            if (this.Status == StatusPedido.APROVADO)
            {
                if (this.QuantidadeItensAprovados < this.Itens.Count())
                {
                    return StatusPedido.APROVADO_QTD_A_MENOR;
                }
                if (this.QuantidadeItensAprovados > this.Itens.Count())
                {
                    return StatusPedido.APROVADO_QTD_A_MAIOR;
                }
                if (this.ValorAprovado < this.ValorTotal)
                {
                    return StatusPedido.APROVADO_VALOR_A_MENOR;
                }
                if (this.ValorAprovado > this.ValorTotal)
                {
                    return StatusPedido.APROVADO_VALOR_A_MAIOR;
                }
            }
            return this.Status;
        }
    }
}