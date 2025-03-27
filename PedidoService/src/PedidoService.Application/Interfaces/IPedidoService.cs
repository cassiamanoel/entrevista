using System.Threading.Tasks;

using PedidoService.Domain.Entities;
using PedidoService.Application.DTOs;

namespace PedidoService.Application.Interfaces;

public interface IPedidoService
{
    Task<Pedido> CriarPedidoAsync(PedidoRequest request);
}
