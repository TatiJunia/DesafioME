using Desafio.ME.Domain.Model;
using Desafio.ME.Domain.Model.Cadastro;
using System;

namespace DesafioME.Domain.Model.Cadastro
{
    public class Produto : Entity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}
