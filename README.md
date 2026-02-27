# .NET Scaffold

Template base para projetos .NET 8 seguindo os princípios de Clean Architecture.

> **Aviso:** Este scaffold foi construído com um conjunto amplo de funcionalidades pensando em projetos de médio a grande porte. Nem tudo que está aqui será necessário em todos os casos — use o que faz sentido para o seu contexto e remova o que não precisar. A ideia é ter uma base sólida e pronta, não uma obrigação de usar tudo.

---

## O que está incluído

- Mediator próprio com CQRS (sem dependência do MediatR)
- Pipeline Behaviors (Validação, Transação, Notificação)
- Result Pattern + Notification Pattern com códigos HTTP automáticos
- Eventos de Domínio síncronos (mesma transação)
- Outbox Pattern assíncrono com suporte a InMemory e Kafka
- Autenticação JWT + Refresh Token
- Integração com FluentValidation
- PostgreSQL + Entity Framework Core

---

## Estrutura

- **Scaffold.Mediator** — infraestrutura do mediator, behaviors e tipos compartilhados
- **Scaffold.Domain** — entidades, agregados, eventos e interfaces de repositório
- **Scaffold.Application** — commands, handlers e validadores
- **Scaffold.Infrastructure** — EF Core, repositórios, JWT e Outbox
- **Scaffold (Api)** — controllers, filtros e configuração da aplicação

---

## Como usar o template

### 1. Instalar o template

Clone o repositório e instale o template localmente:

```bash
git clone https://github.com/seu-usuario/dotnet-scaffold.git
cd dotnet-scaffold
dotnet new install ./
```

### 2. Criar um novo projeto

```bash
dotnet new scaffold -n NomeDoProjeto
```

Isso vai gerar a solução completa com todos os projetos e namespaces já trocados automaticamente de `Scaffold` para `NomeDoProjeto`.

### 3. Configurar o banco de dados

Edite o `appsettings.json` da Api com sua connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=nomebanco;Username=postgres;Password=senha"
}
```

### 4. Rodar as migrations

```bash
cd NomeDoProjeto.Infrastructure
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5. Rodar o projeto

```bash
cd ..
dotnet run --project NomeDoProjeto
```

---

## Eventos de Domínio e Outbox Pattern

O scaffold suporta dois tipos de eventos:

### Eventos de Domínio (síncronos)
Disparados dentro da mesma transação. Usados para regras de negócio internas que precisam de consistência forte.

```csharp
// dentro da entidade
RaiseDomainEvent(new UserCreatedEvent { UserId = Id, Email = email });
```

### Eventos de Integração via Outbox (assíncronos)
Os eventos são salvos na tabela `outbox_messages` no mesmo commit da transação. Um worker processa a tabela periodicamente e publica os eventos.

#### Modo InMemory (padrão)
Ideal para projetos monolíticos ou sem necessidade de broker externo. Os eventos são processados diretamente sem infraestrutura adicional.

```csharp
// Infrastructure/Startup.cs
services.AddScoped<IEventPublisher, InMemoryEventPublisher>();
```

#### Modo Kafka (microsserviços)
Ideal para arquiteturas distribuídas onde múltiplos serviços precisam consumir os mesmos eventos. Garante entrega mesmo que o broker esteja temporariamente indisponível.

```csharp
// Infrastructure/Startup.cs
services.AddScoped<IEventPublisher, KafkaEventPublisher>();
```

Configure o Kafka no `appsettings.json`:

```json
"Kafka": {
  "BootstrapServers": "localhost:9092"
}
```

Para subir o Kafka localmente com Docker:

```bash
docker run -d --name kafka -p 9092:9092 apache/kafka:latest
```

---

## Configuração do JWT

```json
"Jwt": {
  "SecretKey": "sua-chave-secreta-minimo-32-caracteres",
  "Issuer": "nome-do-projeto",
  "Audience": "nome-do-projeto",
  "ExpiresInMinutes": 60,
  "RefreshTokenExpiresInDays": 7
}
```

---

## Requisitos

- .NET 8 SDK
- PostgreSQL
- Docker (opcional, para Kafka)
