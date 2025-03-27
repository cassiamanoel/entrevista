using System.Collections.Generic;
using System.Threading.Tasks;
using PedidoService.Domain.Entities;

namespace PedidoService.Domain.Interfaces;

public interface IPedidoRepository
{
    Task<Pedido?> ObterPorIdAsync(int id);
    Task<IEnumerable<Pedido>> ListarPorStatusAsync(string status);
    Task<bool> ExisteDuplicadoAsync(int pedidoId);
    Task AdicionarAsync(Pedido pedido);
}