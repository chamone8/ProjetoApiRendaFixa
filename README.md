# API de Renda Fixa

Esta é uma API desenvolvida em .NET Core para gerenciar produtos de renda fixa, permitindo a consulta e a compra desses produtos. O projeto utiliza os padrões de arquitetura como CQRS, Repository Pattern, Dependency Injection e Factory Pattern.

## Estrutura do Projeto

O projeto é organizado nas seguintes camadas:

- **Controllers**: Contém os controladores da API que gerenciam as requisições HTTP.
- **CQRS**: Implementa o padrão CQRS, separando os comandos (modificações) das consultas (leitura).
  - **Commands**: Define os comandos que alteram o estado dos produtos.
  - **Queries**: Define as consultas que retornam informações dos produtos.
  - **Handlers**: Contém a lógica de manipulação para comandos e consultas.
- **Data**: Camada de acesso a dados, incluindo repositórios para interagir com o banco de dados.
- **Models**: Define as entidades de domínio que representam os produtos e suas propriedades.

## Tecnologias Utilizadas

- **.NET Core**: Framework para desenvolvimento da API.
- **Entity Framework Core**: Para interagir com o banco de dados SQLite.
- **SQLite**: Banco de dados leve para armazenar os produtos.

## Funcionalidades

- **Consultar Produtos**: Endpoint para listar todos os produtos de renda fixa disponíveis.
- **Comprar Produto**: Endpoint para realizar a compra de um produto, validando a quantidade disponível e o saldo.

## Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu_usuario/SeuProjeto.Api.git
