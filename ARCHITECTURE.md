# Arquitetura

## Dependências permitidas

```text
Gastos (WPF/MVVM) ─┬─> Application ─> Domain
                   └─> Infrastructure ─> Application/Domain
```

`Domain` não referencia EF Core, SQLite, WPF ou classes legadas. A interface usa DTOs e handlers; não acessa `DbContext`, `Crud` ou SQL.

## Convenções

- Commands modificam estado e retornam `Result`/`Result<T>`.
- Queries projetam DTOs e usam `AsNoTracking`.
- Entidades validam invariantes em fábricas e métodos de intenção; não expõem setters públicos.
- I/O é assíncrono e recebe `CancellationToken`.
- Persistência local é SQLite em `%LocalAppData%\Gastos\gastos.db`; migrations são aplicadas no início.
- O bootstrap reconhece bancos existentes, normaliza o esquema necessário e registra as migrations-base antes de aplicar as migrations versionadas restantes. Bancos novos são criados pela migration-base moderna, sem arquivo SQLite distribuído.
- Senhas novas usam PBKDF2-SHA256. O verificador de compatibilidade fica isolado na Infrastructure para permitir a atualização transparente de credenciais já existentes.

## Estado da migração

| Módulo | Domain/Application/Infrastructure | WPF/MVVM |
|---|---|---|
| Clientes | concluído | concluído |
| Competências | concluído | concluído |
| Despesas Fixas | concluído | concluído |
| Empréstimos | concluído, incluindo geração transacional de parcelas | concluído |
| Devedores | concluído, incluindo geração transacional de parcelas | concluído |
| Movimentações | concluído, incluindo cálculo de resumo por queries | concluído |
| Liquidação de parcelas | concluído, com baixa de empréstimos e recebimento de devedores | concluído |
| Painel e consultas | query de resumo e consultas EF por DTO | concluído |
| Usuários e autenticação | PBKDF2, CQRS, EF e compatibilidade de credenciais históricas isolada na Infrastructure | concluído |

Os projetos da arquitetura anterior foram removidos do repositório. A compatibilidade de dados existentes está encapsulada na Infrastructure e não introduz dependências entre as camadas atuais.

## Presentation WPF

`Gastos` usa WPF e MVVM sem bibliotecas adicionais: ViewModels expõem estado e comandos, Views contêm apenas XAML e interação inevitável de `PasswordBox`, e `FabricaPagina` centraliza a composição das páginas. O tema é aplicado por `ResourceDictionary` e pode ser alternado entre claro e escuro, ambos com a paleta azul.

Os formulários WinForms permanecem somente como fonte histórica no repositório e foram excluídos da compilação. Novas telas não devem reutilizá-los nem adicionar referências a `System.Windows.Forms`.
