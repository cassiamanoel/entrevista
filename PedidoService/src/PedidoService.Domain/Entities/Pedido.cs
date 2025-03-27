using System.Linq;
using System.Collections.Generic;

namespace PedidoService.Domain.Entities;

public class Pedido
{
    public int Id { get; private set; }
    public int PedidoId { get; private set; }
    public int ClienteId { get; private set; }
    public decimal Imposto { get; private set; }
    public string Status { get; private set; }
    public List<ItemPedido> Itens { get; private set; } = new();

    protected Pedido() { }

    public Pedido(int pedidoId, int clienteId, List<ItemPedido> itens)
    {
        PedidoId = pedidoId;
        ClienteId = clienteId;
        Itens = itens;
        Status = "Criado";
    }

    public void CalcularImposto(bool usarNovaRegra)
    {
        decimal total = Itens.Sum(i => i.Valor * i.Quantidade);
        Imposto = total * (usarNovaRegra ? 0.2m : 0.3m);
    }
}