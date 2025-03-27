using Microsoft.AspNetCore.Mvc;
using PedidoService.Application.DTOs;
using PedidoService.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PedidoService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoAppService _pedidoAppService;

        public PedidosController(IPedidoAppService pedidoAppService)
        {
            _pedidoAppService = pedidoAppService;
        }

        /// <summary>
        /// Criar um novo pedido
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] PedidoRequest request)
        {
            var response = await _pedidoAppService.CriarPedidoAsync(request);
            return Ok(new { id = response.PedidoId, status = response.Status });
        }

        /// <summary>
        /// Obter um pedido por ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPedido(int id)
        {
            var response = await _pedidoAppService.ObterPedidoPorIdAsync(id);
            if (response is null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Listar pedidos por status
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ListarPedidos([FromQuery] string status)
        {
            var pedidos = await _pedidoAppService.ListarPedidosPorStatusAsync(status);
            return Ok(pedidos);
        }
    }
}