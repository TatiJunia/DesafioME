using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.ME.Domain.Model.Compras
{
    public static class StatusPedido
    {
        public const string CODIGO_PEDIDO_INVALIDO = "CODIGO_PEDIDO_INVALIDO";
        public const string APROVADO = "APROVADO";
        public const string REPROVADO = "REPROVADO";
        public const string APROVADO_VALOR_A_MENOR = "APROVADO_VALOR_A_MENOR";
        public const string APROVADO_VALOR_A_MAIOR = "APROVADO_VALOR_A_MAIOR";
        public const string APROVADO_QTD_A_MENOR = "APROVADO_QTD_A_MENOR";
        public const string APROVADO_QTD_A_MAIOR = "APROVADO_QTD_A_MAIOR";
    }
}
