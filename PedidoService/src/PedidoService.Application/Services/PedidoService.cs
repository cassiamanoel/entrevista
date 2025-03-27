using System.Threading.Tasks;
using System.Linq;
using PedidoService.Application.DTOs;
using PedidoService.Application.Interfaces;
using PedidoService.Domain.Entities;
using PedidoService.Domain.Interfaces; 

namespace PedidoService.Application.Services;

public class PedidoService : IPedidoService
{
    private readonly IFeatureFlagService _featureFlagService;

    public PedidoService(IFeatureFlagService featureFlagService)
    {
        _featureFlagService = featureFlagService;
    }

    public Task<Pedido> CriarPedidoAsync(PedidoRequest request)
    {
        var itens = request.Itens.Select(i =>
            new ItemPedido(i.ProdutoId, i.Quantidade, i.Valor)).ToList();

        var pedido = new Pedido(request.PedidoId, request.ClienteId, itens);

        bool usarNovaRegra = _featureFlagService.IsNovaRegraTributariaAtiva();
        pedido.CalcularImposto(usarNovaRegra);

        return Task.FromResult(pedido);
    }
}