namespace PedidoService.Domain.Entities;

public class ItemPedido
{
    public int Id { get; private set; }
    public int ProdutoId { get; private set; }
    public int Quantidade { get; private set; }
    public decimal Valor { get; private set; }

    protected ItemPedido() { }

    public ItemPedido(int produtoId, int quantidade, decimal valor)
    {
        ProdutoId = produtoId;
        Quantidade = quantidade;
        Valor = valor;
    }
}