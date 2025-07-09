# 📚 Biblioteca Joia (Versão 1)

Gerenciador de livros para clientes e administradores, desenvolvido em **.NET 6 MVC** com SQL Server. Permite cadastro, empréstimo e devolução de livros com controle de acesso via Identity.

---

## 🚀 Funcionalidades

- 📖 Gerenciamento dos livros disponíveis por usuários administradores
- 🆕 Empréstimo de livros por usuários clientes
- 🔒 Autenticação e autorização com ASP.NET Identity (roles Admin/Cliente)
- 🎨 Interface responsiva com validações eficazes

---

## 🧱 Tecnologias

| Camada            | Ferramenta / Tecnologia                  |
|-------------------|-----------------------------------------|
| Backend           | ASP.NET Core MVC (.NET 6)              |
| ORM / DB          | Entity Framework Core + SQL Server     |
| Autenticação      | ASP.NET Core Identity                  |
| Frontend styles   | HTML, CSS, componentização MVC         |

---

## 🔧 Como executar

1. Clone o repositório:
    ```bash
    git clone https://github.com/ycarogb/BibliotecaJoia.git
    cd BibliotecaJoia
    ```

2. Atualize o banco de dados:
    ```bash
    dotnet ef database update
    ```

3. Execute o projeto:
    ```bash
    dotnet run
    ```

4. Acesse no navegador:
    ```
    https://localhost:5001
    ```

---

## 🧩 Estrutura do projeto

- **Controllers/** – Lógica de rotas e ações (usuários, livros, empréstimos)
- **Models/** – DTOs, entidades (Livro, Usuário, EmprestimoLivro), enums e viewmodels
- **Data/** – `DbContext` e configurações de migrações
- **Views/** – Páginas Razor (List, Create, Edit, Details, etc.)
- **Repositories/Services/** – Lógica de domínio (cadastro, empréstimo, devolução)

---

## 👥 Autoria e Licença

 <img style="border-radius: 80%;" src="https://i1.sndcdn.com/avatars-001002863491-80v8qp-t500x500.jpg" width="100px;" alt=""/>
<br />
Feito de ❤️ por Ycaro Batalha

<br />
👋🏽 Let's talk!
<br />

[![Linkedin Badge](https://img.shields.io/badge/-Ycaro-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/ycaro-gabriel-da-costa-batalha-2019/)](https://www.linkedin.com/in/ycaro-gabriel-da-costa-batalha-2019/) 

---

## 🌟 Sugestões de melhorias (versões futuras)

- Melhorar a usabilidade usando Bootstrap ou Blazor
- Funcionalidade de reservas para livros indisponíveis
- Dashboard com estatísticas de empréstimos
