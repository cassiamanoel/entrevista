using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using PedidoService.Application.DTOs;
using PedidoService.Application.Interfaces;
using PedidoService.Domain.Entities;
using PedidoService.Domain.Interfaces;

public class PedidoAppService : IPedidoAppService
{
    private readonly IPedidoService _pedidoService;
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoAppService(IPedidoService pedidoService, IPedidoRepository pedidoRepository)
    {
        _pedidoService = pedidoService;
        _pedidoRepository = pedidoRepository;
    }

    public async Task<PedidoResponse> CriarPedidoAsync(PedidoRequest request)
    {
        var pedido = await _pedidoService.CriarPedidoAsync(request);
        await _pedidoRepository.AdicionarAsync(pedido);
        return new PedidoResponse(pedido);
    }

    public async Task<PedidoResponse?> ObterPedidoPorIdAsync(int id)
    {
        var pedido = await _pedidoRepository.ObterPorIdAsync(id);
        return pedido is null ? null : new PedidoResponse(pedido);
    }

    public async Task<IEnumerable<PedidoResponse>> ListarPedidosPorStatusAsync(string status)
    {
        var pedidos = await _pedidoRepository.ListarPorStatusAsync(status);
        return pedidos.Select(p => new PedidoResponse(p));
    }
}
