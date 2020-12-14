using Desafio.ME.Domain.Repository.Cadastro;
using DesafioME.Domain.Model.Cadastro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.ME.Infrastructure.Repository.Cadastro
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(EFContext context) : base(context) { }
    }
}
