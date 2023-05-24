# RegistroPessoa-Api utilizando a arquitetura Clean
O objetivo dessa api é para estudo e pratica de Teste Unitários, escolhi usar a arquitetura clean por algumas de suas vantagens como: separação de responsabilidades, organização do código, flexibilidade, facilidade de manutenção entre outras.

## Tecnologias utilizadas
- ASP.NET Core 5.0
- Microsoft.EntityFrameworkCore.InMemory 5.0.8
- Microsoft.EntityFrameworkCore.SqlServer 5.0.8
- Microsoft.EntityFrameworkCore.Design 5.0.8
- Swagger
- AutoMapper.Extensions.Microsoft.DependencyInjection 8.1.1
- NSubstitute 5.0.0
- XUnit 2.4.1
- FluentAssertions 6.10.0
- AutoFixture 4.18.0

## Pré-requisitos
Visual Studio 2019 ou superior
.NET 5.0 SDK


## Executando a API
1. Clone o repositório:
```bash
 git clone https://github.com/caio2296/Registro-Api.git
 ```
2. Abra o projeto no Visual Studio

3. Use alguma ferramenta como o Postman ou o Swagger para testar os endpoints.

Alguns dos Endpoints disponíveis GET /api/pessoa - Retorna todas os pessoas. POST /api/pessoa - Cria uma nova pessoa.
