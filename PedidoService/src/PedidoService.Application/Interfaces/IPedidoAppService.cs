using System.Collections.Generic;
using System.Threading.Tasks;
using PedidoService.Application.DTOs;

namespace PedidoService.Application.Interfaces;

public interface IPedidoAppService
{
    Task<PedidoResponse> CriarPedidoAsync(PedidoRequest request);
    Task<PedidoResponse?> ObterPedidoPorIdAsync(int id);
    Task<IEnumerable<PedidoResponse>> ListarPedidosPorStatusAsync(string status);
}
