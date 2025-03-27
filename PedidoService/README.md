
# PedidoService

Solução desenvolvida em .NET para gerenciamento de pedidos e cálculo de imposto com regras configuráveis.

## Tecnologias

- .NET 8
- Entity Framework Core (InMemory)
- Serilog
- XUnit, NSubstitute
- Swagger

## Como executar

```bash
git clone https://github.com/cassiamanoel/entrevista.git
cd entrevista/PedidoService
dotnet restore
dotnet run --project src/PedidoService.API
```

Acesse o Swagger em: https://localhost:5101/swagger

## Endpoints disponíveis

- `POST /api/pedidos` – Criar novo pedido
- `GET /api/pedidos/{id}` – Buscar pedido por ID
- `GET /api/pedidos?status=Criado` – Listar por status

## Rodar testes

```bash
dotnet test src/PedidoService.Tests
```

## Regras de imposto

- Duas regras de cálculo ativadas por **feature flag**
- Cálculo aplicado dinamicamente via `IFeatureFlagService`

## Observações

- Persistência feita com EF Core InMemory (sem necessidade de banco externo)
- Arquitetura orientada a domínio e boas práticas SOLID
