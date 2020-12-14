using Desafio.ME.Domain.Boundary.Compras;
using Desafio.ME.Domain.Model.Compras;
using Desafio.ME.Domain.Repository.Cadastro;
using Desafio.ME.Domain.Repository.Compras;
using Desafio.ME.Domain.Services;
using DesafioME.Domain.Model.Cadastro;
using DesafioME.Domain.Model.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio.ME.Services.Compras
{
    public class PedidoService : IPedidoService
    {


        public IPedidoRepository PedidoRepository { get; set; }
        public IProdutoRepository ProdutoRepository { get; set; }

        public async Task<PedidoOutput> Get(long id, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                var pedido = PedidoRepository.GetById(id);
                return PedidoOutput.From(pedido);
            }, cancellationToken);
        }

        public async Task<long> Create(PedidoInput pedidoInput, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                pedidoInput.Validar();

                Pedido pedido = new Pedido();
                pedido.DataCriacao = DateTime.Now;
                //pedido.UsuarioCriacao = Thread.CurrentPrincipal.Identity;
                foreach (var itemInput in pedidoInput.Itens)
                {
                    ItemPedido item = new ItemPedido();
                    Produto produto = ProdutoRepository.GetById(itemInput.ProdutoId);
                    if (produto == null)
                        throw new Exception("Produto não encontrado");

                    item.Produto = produto;
                    item.Quantidade = itemInput.Qtd;
                    pedido.Itens.Add(item);
                }

                PedidoRepository.Add(pedido);
                return pedido.Id;
            }, cancellationToken);
        }


        public async Task Edit(long pedidoId, PedidoInput pedidoInput, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                pedidoInput.Validar();
                Pedido pedido = PedidoRepository.GetById(pedidoId);
                var itensRemovidos = pedido.Itens.Where(i => !pedidoInput.Itens.Any(ii => ii.ProdutoId == i.Produto.Id));

                foreach (var item in itensRemovidos)
                {
                    pedido.Itens.Remove(item);
                }

                foreach (var itemInput in pedidoInput.Itens)
                {
                    var item = pedido.Itens.FirstOrDefault(i => i.Produto.Id == itemInput.ProdutoId);
                    if (item == null)
                    {
                        Produto produto = ProdutoRepository.GetById(itemInput.ProdutoId);
                        if (produto == null)
                            throw new Exception("Produto não encontrado");

                        item.Produto = produto;
                        item.Quantidade = itemInput.Qtd;
                        pedido.Itens.Add(item);
                    }
                    else
                    {
                        item.Quantidade = itemInput.Qtd;
                    }
                }

                PedidoRepository.Update(pedido);
            }, cancellationToken);
        }

        public async Task Delete(long id, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                var pedido = PedidoRepository.GetById(id);
                if (pedido == null)
                    throw new Exception("Pedido não encontrado");

                PedidoRepository.Delete(pedido);
            }, cancellationToken);
        }

        public async Task<StatusOutput> AlterarStatus(StatusInput statusInput, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                StatusOutput statusOutput = new StatusOutput();
                statusOutput.Pedido = statusInput.Pedido;

                Pedido pedido = PedidoRepository.GetById(statusInput.Pedido);
                if (pedido == null)
                {
                    pedido = new Pedido();
                }

                pedido.AlterarStatus(statusInput.Status, statusInput.ItensAprovados, statusInput.ValorAprovado);
                statusOutput.Status = pedido.GetStatusDetalhado();
                return statusOutput;
            }, cancellationToken);
        }
    }
}

