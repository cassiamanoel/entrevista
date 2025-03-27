# PedidoService

Sistema de processamento de pedidos com cálculo de imposto e integração externa.

## Tecnologias

- .NET 7
- EF Core + PostgreSQL
- Serilog
- XUnit, FluentAssertions, NSubstitute
- Arquitetura: Clean + DDD + Camadas

## Executar o projeto

```bash
docker-compose up -d
dotnet ef database update --project src/PedidoService.Infrastructure
dotnet run --project src/PedidoService.API
