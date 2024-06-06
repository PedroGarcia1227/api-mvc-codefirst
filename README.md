# api-mvc-codefirst

# Projeto Back-End para Empresa Fictícia
Este projeto é uma API REST desenvolvida para o back-end de uma empresa fictícia. A API utiliza a arquitetura de software Model View Controller (MVC) e emprega técnicas de Code First, Fluent API e Migrations para a criação e manutenção do banco de dados diretamente a partir do código.

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
            "DefaultConnection": "Server=.;Database=EmpresaFicticiaDB;Trusted_Connection=True;"
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

- **GET /api/entidade**: Retorna todas as entidades.
- **GET /api/entidade/{id}**: Retorna uma entidade específica pelo ID.
- **POST /api/entidade**: Cria uma nova entidade.
- **PUT /api/entidade/{id}**: Atualiza uma entidade existente pelo ID.
- **DELETE /api/entidade/{id}**: Deleta uma entidade pelo ID.

## Licença
Este projeto está licenciado sob a Licença MIT. Consulte o arquivo [LICENSE](LICENSE) para obter mais detalhes.
