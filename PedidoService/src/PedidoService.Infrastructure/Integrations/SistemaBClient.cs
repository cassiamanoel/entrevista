using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using PedidoService.Domain.Entities;
using PedidoService.Domain.Interfaces;

namespace PedidoService.Infrastructure.Integrations;

public class SistemaBClient : ISistemaBClient
{
    private readonly HttpClient _httpClient;

    public SistemaBClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task EnviarPedidoAsync(Pedido pedido)
    {
        var dto = new
        {
            pedido.PedidoId,
            pedido.ClienteId,
            pedido.Imposto,
            Itens = pedido.Itens.Select(i => new
            {
                i.ProdutoId,
                i.Quantidade,
                i.Valor
            })
        };

        var response = await _httpClient.PostAsJsonAsync("/api/sistema-b/pedidos", dto);
        response.EnsureSuccessStatusCode();
    }
}