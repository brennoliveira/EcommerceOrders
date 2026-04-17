# Ecommerce Orders API

API para gerenciamento de pedidos em um e-commerce, desenvolvida com foco em boas práticas como Clean Architecture, CQRS e uso de MediatR.

## Tecnologias

- .NET 9
- ASP.NET Core
- Entity Framework Core
- SQL Server
- MediatR (CQRS)
- Docker
- xUnit (testes)

## Arquitetura

O projeto segue os princípios da Clean Architecture:

- Domain → entidades e regras de negócio
- Application → casos de uso (CQRS + MediatR)
- Infrastructure → banco de dados
- API → camada de entrada (controllers)

Fluxo:

Controller → MediatR → UseCase → Repository → EF Core → Banco

## Como rodar o projeto

### Pré-requisitos

- Docker
- Docker Compose

### Rodando a aplicação

```bash
docker-compose up --build
```

## Acesso à API

Após iniciar a aplicação, a documentação estará disponível em:

[Swagger UI](http://localhost:5000/swagger)


---

## Banco de dados

- SQL Server rodando via Docker
- As migrations são aplicadas automaticamente no startup

## Endpoints

### Criar pedido
POST /api/v1/orders

### Listar pedidos
GET /api/v1/orders

### Buscar por ID
GET /api/v1/orders/{id}

### Cancelar pedido
DELETE /api/v1/orders/{id}

## Testes

Para rodar os testes:

```bash
dotnet test
```


---

## Docker

O projeto utiliza Docker para facilitar a execução:

- API containerizada
- SQL Server containerizado
- Comunicação via docker-compose

## Decisões técnicas

- Uso de MediatR para implementar CQRS e desacoplar controllers da lógica
- EF Core como ORM
- Migrations automáticas no startup para facilitar execução
- Separação em camadas seguindo Clean Architecture
