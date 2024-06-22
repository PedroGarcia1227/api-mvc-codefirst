# api-mvc-codefirst

# Projeto Back-End para Empresa Fictícia
Este projeto é uma API REST desenvolvida para o back-end de uma empresa fictícia. A API utiliza a arquitetura de software Model View Controller (MVC) e emprega técnicas de Code First, Fluent API e Migrations para a criação e manutenção do banco de dados diretamente a partir do código. Além disso, o projeto implementa programação assíncrona para garantir a eficiência e a responsividade das operações, permitindo que tarefas demoradas, como consultas a banco de dados e chamadas a serviços externos, sejam executadas sem bloquear a execução de outras operações.

## Tecnologias Utilizadas
- **C#**: Linguagem de programação utilizada para desenvolver a API.
- **Arquitetura MVC**: Para separar as responsabilidades do software em três componentes principais: Model (dados), View (interface do usuário) e Controller (lógica de controle).
- **Code First**: Permite definir o modelo de dados diretamente no código e gerar o banco de dados a partir dessas definições.
- **Fluent API**: Utilizada para configurar detalhadamente o modelo de dados de maneira programática e flexível.
- **Migrations**: Ferramenta para gerenciar alterações incrementais no esquema do banco de dados, mantendo os dados existentes.

## Pré-requisitos
- [.NET Core SDK](https://dotnet.microsoft.com/download) instalado
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) ou outro banco de dados compatível

## Configuração do Projeto

1. **Clone o repositório**:
    ```bash
    git clone https://github.com/PedroGarcia1227/api-mvc-codefirst
    ```

2. **Configure a string de conexão do banco de dados**:
    Atualize a string de conexão no arquivo `appsettings.json` com as informações do seu banco de dados.
    ```json
    {
        "ConnectionStrings": {
            "DefaultConnection": "Server=.;Database=EmpresaFicticiaDB;Trusted_Connection=True"
        }
    }
    ```

3. **Execute as migrações para criar o banco de dados**:
    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

## Executando a API

1. **Inicie o servidor**:
    ```bash
    dotnet run
    ```

2. A API estará disponível em `http://localhost:<porta>`, verifique a porta no terminal.

## Endpoints da API

### CustomerController

- **GET /customer**
  - **Parâmetros**: Nenhum.
  - **Retorno**: Retorna uma lista de todas as entidades de clientes.
  - **Resposta de Sucesso**: `200 OK` com um corpo contendo uma lista de clientes.

- **GET /customer/{id}**
  - **Parâmetros**:
    - `id` (int): ID do cliente a ser retornado.
  - **Retorno**: Retorna a entidade de cliente específica pelo ID.
  - **Resposta de Sucesso**: `200 OK` com um corpo contendo o cliente.
  - **Resposta de Falha**:
    - `404 Not Found` se o cliente com o ID fornecido não for encontrado.

- **POST /customer**
  - **Parâmetros**:
    - Corpo da solicitação: JSON contendo os dados do cliente a ser criado.
  - **Retorno**: Cria uma nova entidade de cliente.
  - **Resposta de Sucesso**: `201 Created` com um corpo contendo o cliente criado e um cabeçalho `Location` apontando para o novo recurso.
  - **Resposta de Falha**:
    - `400 Bad Request` se os dados fornecidos forem inválidos.

- **PUT /customer/{id}**
  - **Parâmetros**:
    - `id` (int): ID do cliente a ser atualizado.
    - Corpo da solicitação: JSON contendo os dados atualizados do cliente.
  - **Retorno**: Atualiza uma entidade de cliente existente pelo ID.
  - **Resposta de Sucesso**: `204 No Content`.
  - **Resposta de Falha**:
    - `400 Bad Request` se o ID no corpo da solicitação não corresponder ao ID fornecido na URL.
    - `404 Not Found` se o cliente com o ID fornecido não for encontrado.

- **DELETE /customer/{id}**
  - **Parâmetros**:
    - `id` (int): ID do cliente a ser deletado.
  - **Retorno**: Deleta uma entidade de cliente pelo ID.
  - **Resposta de Sucesso**: `204 No Content`.
  - **Resposta de Falha**:
    - `404 Not Found` se o cliente com o ID fornecido não for encontrado.

### ProductController

- **GET /product**
  - **Parâmetros**: Nenhum.
  - **Retorno**: Retorna uma lista de todas as entidades de produtos.
  - **Resposta de Sucesso**: `200 OK` com um corpo contendo uma lista de produtos.

- **GET /product/{id}**
  - **Parâmetros**:
    - `id` (int): ID do produto a ser retornado.
  - **Retorno**: Retorna a entidade de produto específica pelo ID.
  - **Resposta de Sucesso**: `200 OK` com um corpo contendo o produto.
  - **Resposta de Falha**:
    - `404 Not Found` se o produto com o ID fornecido não for encontrado.

- **POST /product**
  - **Parâmetros**:
    - Corpo da solicitação: JSON contendo os dados do produto a ser criado.
  - **Retorno**: Cria uma nova entidade de produto.
  - **Resposta de Sucesso**: `201 Created` com um corpo contendo o produto criado e um cabeçalho `Location` apontando para o novo recurso.
  - **Resposta de Falha**:
    - `400 Bad Request` se os dados fornecidos forem inválidos.

- **PUT /product/{id}**
  - **Parâmetros**:
    - `id` (int): ID do produto a ser atualizado.
    - Corpo da solicitação: JSON contendo os dados atualizados do produto.
  - **Retorno**: Atualiza uma entidade de produto existente pelo ID.
  - **Resposta de Sucesso**: `204 No Content`.
  - **Resposta de Falha**:
    - `400 Bad Request` se o ID no corpo da solicitação não corresponder ao ID fornecido na URL.
    - `404 Not Found` se o produto com o ID fornecido não for encontrado.

- **DELETE /product/{id}**
  - **Parâmetros**:
    - `id` (int): ID do produto a ser deletado.
  - **Retorno**: Deleta uma entidade de produto pelo ID.
  - **Resposta de Sucesso**: `204 No Content`.
  - **Resposta de Falha**:
    - `404 Not Found` se o produto com o ID fornecido não for encontrado.


## Licença
Este projeto está licenciado sob a Licença MIT. Consulte o arquivo [LICENSE](LICENSE) para obter mais detalhes.
