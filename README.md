
# 🧼 CleanArch - ASP.NET Core Web API

Este projeto é uma **Web API em ASP.NET Core** que segue os princípios da **Clean Architecture**, aplicando boas práticas de separação de responsabilidades e uso do padrão **CQRS (Command Query Responsibility Segregation)**, com auxílio da biblioteca [MediatR](https://github.com/jbogard/MediatR).  
Além disso, o projeto utiliza **Entity Framework Core** com suporte tanto a banco de dados **MySQL Server** quanto a uma **banco em memória** para desenvolvimento.

---

## ✅ Requisitos

- [.NET SDK 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- MySQL Server (exceto em modo desenvolvimento com banco em memória)

---

## 📐 Estrutura do Projeto

O projeto está dividido em camadas conforme os princípios da Clean Architecture:

- `Domain`: Entidades, interfaces e regras de negócio
- `Application`: Casos de uso e validações
- `Infrastructure`: Implementações de banco de dados e serviços externos
- `API`: Interface HTTP e injeção de dependências

---

## 🚀 Execução

### 🔧 Build e Run

No diretório do projeto, execute:

```bash
dotnet build
dotnet run
```

---

### 🧪 Modo de Desenvolvimento com Banco em Memória

Caso não queira instalar o MySQL, o projeto já está configurado para utilizar **InMemoryDatabase** automaticamente ao rodar em ambiente de desenvolvimento:

```bash
set ASPNETCORE_ENVIRONMENT=Development
dotnet run
```

---

### 🗃️ Configuração com MySQL

1. Certifique-se de que o MySQL Server está rodando.
2. Atualize a `ConnectionString` no arquivo `appsettings.json` com as credenciais do seu banco.
3. Aplique as migrations (caso estejam habilitadas):

```bash
dotnet ef database update
```

---

## 🧰 Tecnologias Utilizadas

- ASP.NET Core 6
- Entity Framework Core
- MediatR
- MySQL
- InMemoryDatabase
- Clean Architecture
- CQRS Pattern

---

## 📄 Licença

Este projeto está licenciado sob os termos da licença que você desejar. Para isso, inclua um arquivo `LICENSE` no repositório.

---

## 👨‍💻 Desenvolvido por

Tiago (CleanArch)

---
