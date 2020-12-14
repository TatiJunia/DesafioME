using Desafio.ME.Domain.Boundary.Compras;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio.ME.Domain.Services
{
    public interface IPedidoService
    {
        Task<PedidoOutput> Get(long id, CancellationToken cancellationToken);
        Task<long> Create(PedidoInput pedidoInput, CancellationToken cancellationToken);
        Task Delete(long id, CancellationToken cancellationToken);
        Task<StatusOutput> AlterarStatus(StatusInput statusInput, CancellationToken cancellationToken);
    }
}
