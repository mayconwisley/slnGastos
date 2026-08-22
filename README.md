<div align="center">
  <picture>
    <source media="(prefers-color-scheme: dark)" srcset="docs/assets/finora-logo-dark.svg">
    <source media="(prefers-color-scheme: light)" srcset="docs/assets/finora-logo-light.svg">
    <img src="docs/assets/finora-logo-light.svg" width="360" alt="Finora — Controle de Gastos">
  </picture>

  <p>Aplicação desktop para organização financeira pessoal.</p>

  <p>
    <img alt=".NET 10" src="https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet&logoColor=white">
    <img alt="C#" src="https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white">
    <img alt="WPF" src="https://img.shields.io/badge/WPF-Windows-0078D4?logo=windows&logoColor=white">
    <img alt="Entity Framework Core" src="https://img.shields.io/badge/EF%20Core-10-512BD4?logo=dotnet&logoColor=white">
    <img alt="SQLite" src="https://img.shields.io/badge/SQLite-3-003B57?logo=sqlite&logoColor=white">
    <img alt="NUnit" src="https://img.shields.io/badge/NUnit-3.13-22B14C?logo=nunit&logoColor=white">
  </p>
</div>

## Sobre

A **Finora** é um sistema Windows para o controle de gastos, cadastros financeiros, empréstimos, devedores e movimentações. A interface WPF oferece suporte nativo aos temas claro e escuro, enquanto a aplicação mantém os dados localmente em SQLite.

## Funcionalidades

- Painel com resumo financeiro.
- Gestão de clientes, competências, usuários e despesas fixas.
- Controle de movimentações, empréstimos, parcelas e devedores.
- Consultas financeiras por módulo.
- Autenticação local com senhas protegidas por PBKDF2-SHA256.
- Alternância entre os temas claro e escuro.

## Arquitetura

O projeto segue Clean Architecture com DDD pragmático e separação explícita de responsabilidades.

```text
Gastos (WPF/MVVM) ─┬─> Application ─> Domain
                   └─> Infrastructure ─> Application/Domain
```

| Projeto | Responsabilidade |
| --- | --- |
| `Gastos` | Apresentação WPF, MVVM, composição da aplicação e temas. |
| `Domain` | Entidades, invariantes e tipos do domínio. |
| `Application` | Casos de uso, DTOs, contratos e resultados de operações. |
| `Infrastructure` | EF Core, SQLite, migrations, repositórios e segurança. |
| `TestGastos` | Testes unitários e de integração. |

Consulte [ARCHITECTURE.md](ARCHITECTURE.md) para as convenções e o estado de evolução dos módulos.

## Pré-requisitos

- Windows 7 ou superior.
- [.NET SDK 10](https://dotnet.microsoft.com/download/dotnet/10.0).

## Executar

```powershell
dotnet restore slnGastos.sln
dotnet run --project Gastos/Gastos.csproj
```

Na primeira execução, o banco SQLite é criado em `%LocalAppData%\Gastos\gastos.db` e as migrations pendentes são aplicadas.

## Validar

```powershell
dotnet build slnGastos.sln
dotnet test TestGastos/TestGastos.csproj
```

## Identidade visual

<div align="center">
  <picture>
    <source media="(prefers-color-scheme: dark)" srcset="docs/assets/finora-logo-dark.svg">
    <source media="(prefers-color-scheme: light)" srcset="docs/assets/finora-logo-light.svg">
    <img src="docs/assets/finora-logo-light.svg" width="300" alt="Logo Finora">
  </picture>

  <br><br>

  <picture>
    <source media="(prefers-color-scheme: dark)" srcset="docs/assets/finora-icon-dark.svg">
    <source media="(prefers-color-scheme: light)" srcset="docs/assets/finora-icon-light.svg">
    <img src="docs/assets/finora-icon-light.svg" width="72" alt="Ícone Finora">
  </picture>
</div>

Os ativos estão em `docs/assets/` e foram criados especificamente para este repositório. A marca combina uma carteira e uma linha de crescimento, representando planejamento e evolução financeira.
