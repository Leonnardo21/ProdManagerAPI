# 🚀 ProdManager API (v2) [Em Desenvolvimento]

API RESTful desenvolvida em .NET 9 para gestão de estoque. O projeto serve como um backend robusto para controle de produtos, categorias e usuários, utilizando uma arquitetura limpa e práticas modernas de desenvolvimento.

---

## ✨ Funcionalidades Principais

- **Autenticação e Autorização:** Sistema seguro de login com tokens JWT (JSON Web Tokens).
- **Gestão de Usuários:** CRUD completo de usuários, com busca por e-mail e matrícula.
- **Gestão de Produtos:** Operações CRUD para produtos.
- **Gestão de Categorias:** Operações CRUD para categorias.
- **Segurança de Senhas:** Armazenamento seguro de senhas utilizando o `IPasswordHasher` do ASP.NET Core Identity.

---

## 🛠️ Tecnologias e Arquitetura

- **Framework:** .NET 9
- **Linguagem:** C# 13
- **ORM:** Entity Framework Core 9
- **Banco de Dados:** SQL Server
- **Arquitetura:** Clean Architecture (Domínio, Aplicação, Infraestrutura, API)
- **Padrões de Projeto:** Repository Pattern
- **Autenticação:** JWT (JSON Web Tokens)

---

## 📁 Estrutura do Projeto

```text
ProdManager.Domain        -> Entidades e regras de negócio (sem dependências)
ProdManager.Application   -> Interfaces, DTOs e lógica da aplicação (depende do Domínio)
ProdManager.Infrastructure -> Repositórios, DbContext e serviços (depende da Application)
ProdManager.API           -> Controllers, configuração e ponto de entrada da API
```

## ⚙️ Começando

### Pré-requisitos

- .NET 9 SDK

- SQL Server (Express, Developer, etc.)

- IDE de sua preferência (Visual Studio 2022, VS Code, Rider)

### Clone o Repositório

```bash
git clone https://URL_DO_SEU_REPOSITORIO.git
cd ProdManagerAPI
```

### Configure a Conexão com o Banco de Dados

- Edite o arquivo ProdManager.API/appsettings.json:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=ProdManagerDb;User Id=SEU_USUARIO;Password=SUA_SENHA;TrustServerCertificate=true"
  },
  "Jwt": {
    "Key": "SUA_CHAVE_SECRETA_SUPER_LONGA_E_SEGURA_AQUI_PARA_A_VERSAO_9",
    "Issuer": "ProdManager.Api",
    "Audience": "ProdManager.Api"
  }
}
```

### Aplique as Migrações

```bash
dotnet ef database update --startup-project ProdManager.API
```

### Execute a Aplicação

```bash
dotnet run --project ProdManager.API
```

- A API estará rodando em https://localhost:PORTA.

### 👨‍💻 Endpoints - UserController

| Método | Rota                                         | Descrição                                   | Requer Autenticação? |
| ------ | -------------------------------------------- | ------------------------------------------- | -------------------- |
| POST   | `/api/auth/login`                            | Autentica um usuário e retorna um token JWT | ❌ Não               |
| POST   | `/api/user`                                  | Cria um novo usuário                        | ❌ Não               |
| GET    | `/api/user`                                  | Lista todos os usuários                     | ✅ Sim               |
| GET    | `/api/user/by-registration/{registrationId}` | Busca um usuário pela matrícula             | ✅ Sim               |
| GET    | `/api/user/by-email?email={email}`           | Busca um usuário pelo e-mail                | ✅ Sim               |
| DELETE | `/api/user/{registrationId}`                 | Deleta um usuário pela matrícula            | ✅ Sim               |

### 📦 Endpoints - ProductController

| Método | Rota                | Descrição                       | Requer Autenticação? |
| ------ | ------------------- | ------------------------------- | -------------------- |
| GET    | `/api/product`      | Lista todos os produtos         | ✅ Sim               |
| GET    | `/api/product/{id}` | Busca um produto pelo ID        | ✅ Sim               |
| POST   | `/api/product`      | Cria um novo produto            | ✅ Sim               |
| PUT    | `/api/product/{id}` | Atualiza os dados de um produto | ✅ Sim               |
| DELETE | `/api/product/{id}` | Remove um produto pelo ID       | ✅ Sim               |

### 🗂️ Endpoints - CategoryController

| Método | Rota                 | Descrição                          | Requer Autenticação? |
| ------ | -------------------- | ---------------------------------- | -------------------- |
| GET    | `/api/category`      | Lista todas as categorias          | ✅ Sim               |
| GET    | `/api/category/{id}` | Busca uma categoria pelo ID        | ✅ Sim               |
| POST   | `/api/category`      | Cria uma nova categoria            | ✅ Sim               |
| PUT    | `/api/category/{id}` | Atualiza os dados de uma categoria | ✅ Sim               |
| DELETE | `/api/category/{id}` | Remove uma categoria pelo ID       | ✅ Sim               |

## ⚖️ Licença

Distribuído sob a licença MIT.
Consulte o arquivo LICENSE para mais informações.
