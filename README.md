# .NET Scaffold

Template base para projetos .NET 8 seguindo os princípios de Clean Architecture.

## O que está incluído

- Mediator próprio com CQRS (sem dependência do MediatR)
- Pipeline Behaviors (Validação, Transação, Notificação)
- Result Pattern + Notification Pattern
- Eventos de Domínio (síncronos) + Outbox Pattern (assíncrono)
- Autenticação JWT + Refresh Token
- Integração com FluentValidation
- PostgreSQL + Entity Framework Core

## Estrutura

- **Scaffold.Mediator** — infraestrutura do mediator, behaviors e tipos compartilhados
- **Scaffold.Domain** — entidades, agregados, eventos e interfaces de repositório
- **Scaffold.Application** — commands, handlers e validadores
- **Scaffold.Infrastructure** — EF Core, repositórios, JWT e Outbox
- **Scaffold (Api)** — controllers, filtros e configuração da aplicação
