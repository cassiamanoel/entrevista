using System.Threading.Tasks;
using PedidoService.Domain.Entities;

namespace PedidoService.Domain.Interfaces;

public interface ISistemaBClient
{
    Task EnviarPedidoAsync(Pedido pedido);
}