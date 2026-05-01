# BolaoNet

BolaoNet é uma solução em .NET Framework para gerenciamento de bolões esportivos (placares, pontuação e relatórios). A solução está organizada em múltiplos projetos que separam domínio, aplicação, infraestrutura, interface web, API, banco de dados e testes.

Resumo rápido
- Tipo: Solução multi-projeto .NET Framework
- Targets observados: `.NET Framework 4.8` e `.NET Framework 4.6.1`
- IDE recomendada: `Microsoft Visual Studio 2022` / `Microsoft Visual Studio 2026` com workloads para desenvolvimento .NET
- Banco de dados alvo: `SQL Server` (projeto `.sqlproj` incluso)

Principais projetos
- `BolaoNet.Application` - Camada de aplicação (casos de uso)
- `BolaoNet.Domain.Entities` - Entidades do domínio
- `BolaoNet.Domain.Interfaces.Services` - Interfaces de serviços do domínio
- `BolaoNet.Domain.Interfaces.Repositories` - Interfaces de repositórios
- `BolaoNet.Domain.Services` - Implementações de serviços de domínio
- `BolaoNet.Infra.Data.EF` - Persistência via Entity Framework
- `BolaoNet.Infra.Data.EF.Mapping` - Mapeamentos EF
- `BolaoNet.Database.SqlServer` - Projeto de banco de dados (`.sqlproj`) com scripts/objetos
- `BolaoNet.WebApi` - API REST
- `BolaoNet.MVC` - Aplicação ASP.NET MVC (UI)
- `BolaoNet.MVC.ViewModels` - ViewModels usados pela MVC
- `BolaoNet.Infra.CrossCutting.IoC` - Registro de dependências / Injeção de Dependência
- `BolaoNet.Infra.CrossCutting.Logging` - Logging centralizado
- `BolaoNet.Infra.CrossCutting.Caching` - Abstrações de cache
- `BolaoNet.Infra.Notification.Mail` - Serviço de envio de e-mails
- `BolaoNet.Infra.Reports` - Geração de relatórios
- `BolaoNet.Feed.Rss` - Feed RSS
- `BolaoNet.Estatisticas.Calculo` - Cálculos estatísticos
- Projetos de teste: `BolaoNet.Tests`, `BolaoNet.Tests.Debug`, `BolaoNet.MVC.Tests`, `BolaoNet.Tests.Exploratory`, `BolaoNet.WebApi.Integration`
- `Info/DocFx` - Geração de documentação (DocFX)

Requisitos (desenvolvimento)
- `Visual Studio` (2022 ou 2026) com suporte a .NET Framework 4.x
- `SQL Server` (local ou remoto) para executar scripts do projeto `BolaoNet.Database.SqlServer`
- SMTP disponível para testes de envio de e-mail (ou configurar um mock)

Como abrir e compilar
1. Abra `BolaoNet.sln` no Visual Studio.
2. Restaure pacotes NuGet (o Visual Studio normalmente faz isso automaticamente).
3. Selecione o projeto startup desejado (`BolaoNet.MVC` para UI, `BolaoNet.WebApi` para API) e pressione F5 para executar em IIS Express.

Linha de comando (build)
- Compilar solução: `msbuild BolaoNet.sln /p:Configuration=Release`
- Observação: por se tratar de projetos .NET Framework, prefira `msbuild` ou Visual Studio em vez de `dotnet build` para full support.

Banco de dados
- O projeto `BolaoNet.Database.SqlServer` contém scripts e objetos de banco. Revise os scripts antes de aplicar em qualquer ambiente.
- Para desenvolvimento local: ajuste as connection strings nos `Web.config`/`App.config` dos projetos que acessam o banco e aplique os scripts via SQL Server Management Studio ou publique o `.sqlproj` para sua instância.

Configurações importantes
- Connection strings: procurar por `connectionStrings` em `Web.config` / `App.config` nos projetos Web/API.
- SMTP: verificar configurações em `appSettings` / `Web.config` relacionadas a `BolaoNet.Infra.Notification.Mail`.
- Logging / Cache: revisar `BolaoNet.Infra.CrossCutting.Logging` e `BolaoNet.Infra.CrossCutting.Caching` para ajustar provedores e níveis.

Executando testes
- Use o Test Explorer do Visual Studio para executar os testes unitários e de integração.
- É possível executar testes via `vstest.console.exe` apontando para os assemblies de teste.
- Projetos de integração podem depender de DB ou serviços externos; assegure as dependências antes de executar.

Documentação
- `Info/DocFx` sugere uso do DocFX para gerar documentação. Consulte o projeto `DocFx.csproj` e a configuração do DocFX para gerar HTML/documentação localmente.

Arquitetura e padrões
- Arquitetura em camadas (Domain, Application, Infra, Presentation).
- Separação entre interfaces e implementações (Interfaces.* e Services/Infra).
- Injeção de dependência centralizada em `BolaoNet.Infra.CrossCutting.IoC`.

Notas e recomendações
- Verifique versões de pacotes NuGet antes de atualizar o ambiente. Testes e build podem quebrar se pacotes forem atualizados sem validação.
- Mantenha credenciais e connection strings fora do controle de versão; use transformações de configuração, variáveis de ambiente ou um secret manager no CI/CD.
- Ao portar para .NET Core/NET (6/7/8), comece portando bibliotecas de domínio e testes, depois infraestrutura (EF, IIS) e adaptando a infraestrutura de hosting.

Contribuindo
- Abra uma issue descrevendo o problema ou feature.
- Crie um branch a partir de `master` com prefixo `feature/` ou `fix/`.
- Submeta um Pull Request com descrição clara e evidências (testes, logs, screenshots quando aplicável).

Licença
- Não foi detectado um arquivo de licença no repositório. Se o projeto for open-source, adicione um `LICENSE` (ex.: MIT) e atualize este README.

Contato
- Repositório remoto: `https://github.com/Thoris/BolaoNet`
- Exemplo de caminho local do autor: `C:\Thoris\Pessoal\Projetos\BolaoNet\`

---

Este README foi gerado automaticamente a partir da estrutura do repositório. Ajuste instruções específicas (strings de conexão, comandos de deploy, políticas de CI/CD) conforme sua infraestrutura.
