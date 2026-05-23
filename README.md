# BolaoNet

BolaoNet é uma solução corporativa em .NET Framework para gerenciamento de bolões esportivos (placares, pontuação, relatórios e feeds). Este README segue um padrão de mercado, fornecendo visão geral, arquitetura, instruções de build/execução, configurações essenciais, informações sobre o banco de dados, testes, documentação e guidelines de contribuição.

Sumário
- Visão geral
- Principais projetos e responsabilidades
- Requisitos
- Estrutura do repositório
- Configuração mínima (exemplos)
- Build e execução (local e CI)
- Banco de dados e deploy do schema
- Testes
- Documentação e diagramas
- Arquitetura e padrões adotados
- Segurança e segredos
- Contribuição
- Licença e contatos

Visão geral
BolaoNet é organizado em camadas: Presentation (ASP.NET MVC e Web API), Application (casos de uso), Domain (entidades, interfaces, regras), Infraestrutura (persistence, logging, caching, notificações) e Database (projeto .sqlproj para SQL Server). A solução possui projetos de teste unitário e integração.

Principais projetos (extraído da solução)
- BolaoNet.MVC — Aplicação ASP.NET MVC (interface web)
- BolaoNet.WebApi — API REST
- BolaoNet.Application — Camada de orquestração / casos de uso
- BolaoNet.Domain.Entities — Entidades do domínio (POCOs)
- BolaoNet.Domain.Interfaces.Repositories — Contratos de repositório
- BolaoNet.Domain.Interfaces.Services — Contratos de serviços de domínio
- BolaoNet.Domain.Services — Implementações das regras de negócio
- BolaoNet.Infra.Data.EF — Implementação Entity Framework (DbContext, repositórios)
- BolaoNet.Infra.Data.EF.Mapping — Mapeamentos EF (EntityTypeConfiguration)
- BolaoNet.Database.SqlServer — Projeto de banco de dados (.sqlproj) com scripts/objetos
- BolaoNet.Infra.CrossCutting.IoC — Configuração de IoC/DI container
- BolaoNet.Infra.CrossCutting.Logging — Camada de logging
- BolaoNet.Infra.CrossCutting.Caching — Abstrações de cache
- BolaoNet.Infra.Notification.Mail — Serviço de envio de e-mail
- BolaoNet.Infra.Reports — Geração de relatórios (exportação/PDF)
- BolaoNet.Feed.Rss — Feed RSS
- BolaoNet.Estatisticas.Calculo — Cálculos estatísticos / regras de pontuação
- Info/DocFx — Projeto para geração de documentação (DocFX)
- Projetos de teste: BolaoNet.Tests, BolaoNet.Tests.Debug, BolaoNet.MVC.Tests, BolaoNet.Tests.Exploratory, BolaoNet.WebApi.Integration

Requisitos
- Microsoft Visual Studio Community 2022/2026 com workloads para desenvolvimento .NET (ASP.NET, .NET Framework)
- .NET Framework 4.8 (projetos da solução são direcionados a 4.8)
- SQL Server (local ou remoto) para executar scripts do projeto `BolaoNet.Database.SqlServer`
- Node.js + npm (opcional) para usar ferramentas como mermaid-cli
- DocFX (opcional) para gerar documentação técnica

Estrutura do repositório (resumo)
- /BolaoNet.MVC — UI (views, controllers, scripts)
- /BolaoNet.WebApi — API REST
- /BolaoNet.Application — Serviços de aplicação, comandos/handlers
- /BolaoNet.Domain.* — Domínio: entidades, interfaces e serviços
- /BolaoNet.Infra.* — Implementações de infraestrutura (EF, IoC, Logging, Mail)
- /BolaoNet.Database.SqlServer — Scripts, objetos e artefatos SQL
- /Info/DocFx — Configuração e conteúdo para DocFX
- /docs — (sugerido) diagramas gerados e documentação estática

Configuração mínima (exemplos)
- Web.config (connection string e smtp) — NÃO commitar segredos reais.

```xml
<!-- Exemplo: Web.config (trecho) -->
<configuration>
  <connectionStrings>
    <add name="BolaoNetDb" connectionString="Server=localhost;Database=BolaoNet;User Id=sa;Password=YourStrong!Pass;" providerName="System.Data.SqlClient" />
  </connectionStrings>

  <system.net>
    <mailSettings>
      <smtp from="no-reply@bolao.local">
        <network host="smtp.example.com" port="587" userName="user" password="pass" enableSsl="true" />
      </smtp>
    </mailSettings>
  </system.net>
</configuration>
```

- Use transforms `Web.Debug.config` / `Web.Release.config` e variáveis de CI para substituir valores sensíveis.

Build e execução (local)
1. Abra `BolaoNet.sln` no Visual Studio (Workspace path: C:\Thoris\Pessoal\Projetos\BolaoNet\).
2. Restaure pacotes NuGet (Visual Studio costuma restaurar automaticamente).
3. Selecione o projeto de inicialização (`BolaoNet.MVC` ou `BolaoNet.WebApi`) e pressione F5.

Linha de comando (PowerShell)
- Restaurar pacotes NuGet (se necessário): nuget restore BolaoNet.sln
- Build: msbuild .\BolaoNet.sln /p:Configuration=Release /m
- Publicar web (exemplo para MVC): use Visual Studio publish profiles ou MSBuild com targets adequados.

Banco de dados e deploy do schema
- O projeto `BolaoNet.Database.SqlServer` é um Database Project (.sqlproj). Publicação/Deploy:
  - Via Visual Studio: right-click -> Publish (escolha target connection string).
  - Via linha de comando: use SqlPackage.exe ou MSBuild para publicar o .sqlproj.
- Antes de publicar em produção, revisar scripts de criação, indexes, procedures e backups.

Testes
- Execute via Test Explorer no Visual Studio.
- Ou via linha de comando com VSTest: `vstest.console.exe path\to\BolaoNet.Tests.dll`.
- Observação: alguns testes de integração dependem de DB e serviços externos; configure ambientes isolados para CI.

Documentação e diagramas
- DocFX: o projeto `Info/DocFx` contém artefatos para geração de docs.
  - Instalar DocFX: `choco install docfx` ou baixar a versão apropriada.
  - Gerar e servir docs localmente: `docfx .\Info\DocFx\docfx.json --serve` (ajuste caminhos conforme necessário).
- Mermaid: para gerar SVGs a partir de diagramas Mermaid, use `@mermaid-js/mermaid-cli` com Node:
  - `npm i -g @mermaid-js/mermaid-cli`
  - `mmdc -i diagram.mmd -o diagram.svg`
- Recomenda-se manter diagramas fonte em `/docs/diagrams` e incluir SVGs gerados para publicação em DocFX.

Arquitetura e padrões adotados
- Padrão em camadas (Presentation, Application, Domain, Infra).
- Inversão de controle e DI centralizada em `Infra.CrossCutting.IoC`.
- Separação de contratos (Interfaces.*) e implementações para facilitar testes e portabilidade.
- Logging e caching centralizados em `Infra.CrossCutting`.
- Persistência via Entity Framework com classes de mapeamento separadas (`Infra.Data.EF.Mapping`).

CI/CD (sugestão - Azure DevOps / GitHub Actions)
- Pipeline típico:
  1. Restore NuGet
  2. Build (MSBuild)
  3. Run unit tests (VSTest)
  4. Publish artifacts (web packages, database dacpac)
  5. Deploy (slot swap, or green/blue via release pipeline)

Exemplo simplificado (Azure DevOps YAML):
```yaml
trigger:
  - master
pool:
  vmImage: 'windows-latest'
steps:
  - task: NuGetToolInstaller@1
  - task: NuGetCommand@2
    inputs:
      restoreSolution: 'BolaoNet.sln'
  - task: VSBuild@1
    inputs:
      solution: 'BolaoNet.sln'
      msbuildArgs: '/p:Configuration=Release'
  - task: VSTest@2
    inputs:
      testSelector: 'testAssemblies'
      testAssemblyVer2: '**\*Tests.dll'
```

Segurança e segredos
- Nunca commitar credentials. Use:
  - Azure Key Vault / GitHub Secrets / Variable Groups em Azure DevOps
  - Transformações de config para substituir valores no deploy
  - Managed Identity quando possível para acesso a recursos no Azure

Boas práticas para contribuição
- Abra uma Issue descrevendo a mudança proposta.
- Crie um branch com prefixo: `feature/`, `fix/` ou `chore/`.
- Adicione testes para mudanças funcionais; garanta que o build passe localmente.
- Submeta Pull Request com descrição clara, screenshots e comandos de repro quando aplicável.

Checklist antes de merge
- Build em modo Release bem-sucedido
- Testes unitários passando
- Revisão de código (2+ reviewers recomendado)
- Validação de alterações de banco de dados e scripts SQL revisados
- Atualização de documentação se necessário

Licença
- Não existe um arquivo `LICENSE` no repositório. Se o projeto for open-source, adicione um arquivo `LICENSE` (ex: MIT) na raiz. Até lá, trate o código como privado/proprietário conforme acordo do projeto.

Contatos e referências
- Repositório remoto: https://github.com/Thoris/BolaoNet
- Workspace local do usuário: C:\Thoris\Pessoal\Projetos\BolaoNet\

Próximos passos sugeridos (posso implementar)
- Gerar / adicionar `docs/diagrams` contendo arquivos Mermaid (.mmd) e SVGs gerados.
- Criar `docs/index.md` e integrar com `Info/DocFx` para publicação automática.
- Adicionar um arquivo `LICENSE` (MIT) se desejar abrir o projeto.
- Gerar exemplos de `Web.Debug.config` e `Web.Release.config` com placeholders.

---

Se quiser, eu posso aplicar automaticamente as próximas ações sugeridas (ex.: criar a pasta docs, adicionar diagramas .mmd e um LICENSE MIT). Informe qual ação prefere que eu faça agora.
