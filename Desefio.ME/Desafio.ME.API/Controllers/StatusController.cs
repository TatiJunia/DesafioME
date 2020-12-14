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
    [Route("api/status")]
    public class StatusController : ControllerBase
    {
        private IPedidoService PedidoService { get; set; }
        public StatusController()
        {
        }


        [HttpPost]
        public async Task<IActionResult> Create(StatusInput statusInput, CancellationToken cancellationToken)
        {
            var statusOutput = await PedidoService.AlterarStatus(statusInput, cancellationToken);
            return Ok(statusOutput);
        }
    }
}
