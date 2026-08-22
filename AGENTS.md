# Repository Guidelines

## Objetivo da Modernização

Este é um projeto WinForms legado de controle de gastos. Evolua-o incrementalmente, preservando comportamento e mantendo a aplicação executável. A arquitetura alvo é Clean Architecture com DDD pragmático, SOLID e Clean Code.

## Arquitetura e Dependências

Organize novos projetos e código por responsabilidade:

- `Gastos/` (Presentation): formulários, DI e conversão entre controles e DTOs; sem SQL, regras ou EF.
- `Domain/`: entidades ricas, value objects e regras; não referencia EF Core, WinForms ou Infrastructure.
- `Application/`: casos de uso CQRS, DTOs, validação e contratos, como `IClienteRepository`.
- `Infrastructure/`: `DbContext`, EF Core, migrations, repositórios e serviços externos.
- `TestGastos/`: testes unitários de Domain/Application e integração de Infrastructure.

As dependências apontam para dentro: Presentation e Infrastructure dependem de Application/Domain; Application depende de Domain. Não reintroduza projetos ou namespaces da arquitetura anterior; novas funcionalidades devem ser implementadas integralmente nas camadas atuais.

## Regras de Implementação

Entidades encapsulam invariantes e expõem métodos de intenção, como `cliente.AlterarNome(nome)`, em vez de setters públicos. Use DTOs na entrada e saída da Application; nunca exponha entidades na UI. Classes são `sealed` por padrão; permita herança apenas quando justificada.

Cada classe tem uma única responsabilidade. Use nomes de domínio claros em português e PascalCase para tipos, métodos e propriedades. Use `async`, `CancellationToken` e logging estruturado em I/O. Não engula exceções nem faça `throw new Exception(ex.Message)`.

## Convenções de Código e Contratos

- Use 4 espaços para indentação; tabs são proibidos. Mantenha chaves de abertura em linha própria e remova espaços em branco ao fim das linhas.
- Siga o arquivo `.editorconfig` da raiz. Antes de entregar alterações C#, execute a formatação aplicável sem modificar arquivos `*.Designer.cs`.
- Cada interface da Application deve ficar em `Application/<Feature>/Interfaces`, em arquivo próprio com o mesmo nome do contrato, por exemplo `Application/Clientes/Interfaces/IClienteRepository.cs`.
- Não declare interfaces em arquivos de DTOs, Commands, Queries, handlers ou entidades. Preserve o namespace da feature ao mover um contrato; a pasta organiza o código sem criar novo acoplamento de namespace.
- Repositórios de escrita e leitura permanecem em contratos distintos quando têm responsabilidades distintas. Não introduza repositórios genéricos.

## Result Pattern e CQRS

Casos de uso retornam `Result`/`Result<T>` para validação, ausência de dados e conflitos esperados; exceções são para falhas inesperadas. Um Command grava uma operação; uma Query usa `AsNoTracking`, projeta para DTO e não chama `SaveChanges`.

## Persistência Local

Use EF Core com SQLite como banco local embarcado. Mantenha o arquivo fora de `bin/`, aplique migrations controladamente no início e versione cada mudança de esquema. Não versione credenciais, caminhos pessoais ou dados sensíveis. Use parâmetros, índices e transações para múltiplas gravações.

## Qualidade, Testes e Pull Requests

Execute `dotnet build slnGastos.sln` e `dotnet test TestGastos/TestGastos.csproj` antes de entregar. Nomeie testes como `Metodo_Cenario_ResultadoEsperado`; todo bug corrigido requer regressão. Commits são pequenos e imperativos, como `Adiciona cadastro de cliente`. Em PRs, descreva regra, migration, testes e mudanças visuais.

## Restrições

Não introduza MediatR, repositórios genéricos, mapeadores automáticos ou padrões adicionais sem necessidade concreta. Não altere arquivos do Designer manualmente. Não misture regras, SQL ou `DbContext` em formulários.
