using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Desafio.ME.Domain.Boundary.Compras;
using Desafio.ME.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Desafio.ME.API.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidoController : ControllerBase
    {
        private IPedidoService PedidoService { get; set; }
        public PedidoController()
        {
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(long id, CancellationToken cancellationToken)
        {
            var pedido = await PedidoService.Get(id, cancellationToken);
            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PedidoInput peditoInput, CancellationToken cancellationToken)
        {
            long pedidoId = await PedidoService.Create(peditoInput, cancellationToken);
            return Ok(pedidoId);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            await PedidoService.Delete(id, cancellationToken);
            return Ok();
        }


    }
}
