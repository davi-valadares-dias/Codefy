# Codefy — decisões e propostas de arquitetura

Este documento complementa os requisitos v2.0 e orienta a implementação acompanhada. É um entregável de planejamento separado do repositório existente; nenhuma proposta aqui significa que o recurso já esteja implementado, instalado ou validado. As recomendações técnicas foram confrontadas com documentação oficial nesta etapa.

## 1. O que já está definido e o diagnóstico confirmado

| Situação | Conteúdo | Consequência |
|---|---|---|
| Definido pelo roteiro | React e TypeScript; ASP.NET Core e C#; EF Core e PostgreSQL; C++ e CMake | Preservar essas tecnologias durante a implementação. |
| Definido pelo roteiro | Monorepositório, monólito modular, um administrador e ausência de cadastro público | Organizar responsabilidades dentro da aplicação existente; não criar serviços distribuídos para cada módulo. |
| Repositório confirmado | `C:\Users\Infortronic\Documents\work\Codefy`; remoto [davi-valadares-dias/Codefy](https://github.com/davi-valadares-dias/Codefy) | Reutilizar essa raiz e seu histórico. Este diretório de entregáveis em `outputs/Codefy` não é outro repositório da aplicação. |
| Solução confirmada | `Codefy.slnx` referencia `Codefy.vcxproj`; aplicação de console C++20 com Hello World, toolset `v145` | Preservar o projeto C++ e acrescentar componentes progressivamente; a implementação inicial pode evoluir para o analisador. |
| Git no momento da inspeção | Branch `master` rastreando `origin/master`, dois commits e nenhuma modificação local | Não é necessário recriar o Git, substituir o remoto ou renomear a branch para seguir o plano. Conferir novamente o estado antes de cada alteração. |
| Componentes ainda ausentes | Frontend, backend ASP.NET Core e `CMakeLists.txt` | São trabalho futuro; o console C++ existente não comprova nenhuma implementação web. |
| Ferramentas disponíveis | SDK .NET 10.0.401, runtime ASP.NET Core 10.0.12, Node 24.11.0, npm 11.6.1 e Visual Studio 2026 | São ferramentas detectadas, não uma declaração das versões mais recentes nem versões já adotadas pela aplicação. |
| Banco disponível | PostgreSQL 18.4 com serviço em estado Running | Ainda será preciso definir e verificar banco dedicado, usuário, acesso, configuração e migrations do Codefy; serviço ativo não comprova essa integração. |
| Ferramentas C++ disponíveis | CMake 4.3.1-msvc1 e compilador MSVC 14.51.36231 acessíveis pelo ambiente do Visual Studio | Reutilizar a instalação. Disponibilidade de CMake não significa que o projeto já use CMake. |
| Verificação executada | Cópia de `Codefy.cpp` compilada diretamente com MSVC, SDK Windows 10.0.26100.0 e `/std:c++20`; build e programa encerraram com código 0; saída `Hello World!` | Confirma fonte e compilador. Todos os arquivos gerados ficaram em `work`; não altera o repositório original nem comprova o build da solução. |
| Limite da verificação | Tentativa automatizada de MSBuild encontrou `FileTracker UnauthorizedAccessException` | O fluxo da solução pelo MSBuild/Visual Studio continua sem validação completa neste ambiente; tratar separadamente da compilação direta bem-sucedida. |

**Nenhuma versão de runtime web foi adotada ou alterada nesta etapa.** Como o backend ainda não existe, .NET 10 é a proposta para sua criação em M03–M04: há SDK disponível e a família é LTS. Fixar a versão do SDK e as dependências na preparação da base reproduzível; verificar também atualizações de segurança antes da publicação. [Política oficial de suporte do .NET](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core).

Para uma base em EF Core 10, avaliar o provedor Npgsql correspondente à mesma geração e validar a integração com o PostgreSQL 18.4 disponível. A versão da hospedagem será confirmada antes do deploy; não há motivo identificado para substituir o servidor local nesta etapa. [Npgsql EF Core 10](https://www.npgsql.org/efcore/release-notes/10.0.html).

O diagnóstico M00 já distingue a compilação direta verificada da limitação do MSBuild; a próxima verificação conjunta será abrir e executar a solução no Visual Studio. Nenhum binário existente ou diretório de compilação precisa ser apagado para preparar o plano. A organização em `frontend`, `backend` e `analyzer` será gradual; qualquer futura movimentação dos fontes preservará o histórico e manterá as referências da solução funcionais. O CMake entra em M14, junto à construção do analisador independente.

## 2. Frontend e conteúdo indexável — proposta

Recomendo **React Router em Framework Mode com SSR** para as páginas públicas. React continua sendo a camada de interface; o ASP.NET Core continua sendo responsável pelos dados, autenticação e regras do produto. O frontend ainda não existe: essa escolha permanece proposta a consolidar em M03 e preparar em M04, antes da integração completa em M07.

| Alternativa | Como atende ao Codefy | Impacto |
|---|---|---|
| React Router Framework com SSR | Os loaders do servidor consultam a API e a resposta contém HTML do projeto. A renderização ocorre em runtime. | Exige processo de servidor para o frontend e configuração de deploy compatível com SSR. É uma integração direta para a API C# já prevista. |
| Next.js App Router | Também oferece renderização no servidor e recursos de cache/revalidação, além de convenções para metadados. | É uma alternativa válida; adiciona decisões específicas sobre cache e renderização que precisaríamos aprender e operar. Não há necessidade atual de outro backend de negócio em Node. |
| Somente pré-renderização no build | Produz HTML estático inicial. | Conteúdo editado no painel não atualiza esse HTML sozinho; seria necessário reconstruir ou implementar regeneração. Não atende isoladamente ao requisito de atualização sem redeploy. |

As capacidades das duas primeiras opções estão nas fontes oficiais: [estratégias do React Router](https://reactrouter.com/start/framework/rendering) e [cache e conteúdo dinâmico no Next.js](https://nextjs.org/docs/app/getting-started/caching). A preferência pelo React Router é uma avaliação de adequação ao Codefy, não uma limitação técnica do Next.js.

Fluxo proposto para a primeira entrega:

1. Visitante solicita `/projetos/meu-projeto`.
2. O loader no servidor React consulta `GET /api/v1/projects/meu-projeto` no ASP.NET Core.
3. A API consulta o PostgreSQL e devolve somente os campos públicos de um projeto publicado.
4. O frontend entrega o HTML com título, descrição, conteúdo e metadados; o React adiciona interatividade no navegador.
5. Após uma alteração administrativa confirmada no banco, uma nova solicitação ao site apresenta o conteúdo atualizado sem novo build.

Inicialmente, não manter cache compartilhado de HTML ou dados editoriais; configurar respostas dinâmicas com `Cache-Control: no-store`. Arquivos estáticos com nomes versionados podem ter cache. Isso simplifica publicação e despublicação; aumenta consultas à API, aceitáveis como hipótese inicial para um portfólio pequeno. Medir antes de adicionar cache. Uma aba já aberta só muda ao navegar/recarregar; atualização em tempo real não é requisito atual.

Depois, se necessário, documentar tempo máximo de desatualização e invalidar todas as representações de um projeto ao publicar, editar ou despublicar. Avaliar a resposta HTML sem JavaScript, códigos HTTP reais, metadados Open Graph, canonical, sitemap e robots. Uma página inexistente deve responder 404 também no servidor React.

## 3. Mesma origem, autenticação e autorização — proposta

O navegador acessará uma única origem HTTPS em produção. Um proxy encaminhará `/api/*` ao ASP.NET Core e as páginas ao servidor React. O endereço interno da API usado no SSR será configuração do servidor, sem segredos enviados ao navegador. O desenvolvimento deve simular esse encaminhamento para evitar diferenças desnecessárias em cookies e CORS.

Propor componentes do ASP.NET Core Identity para hash, verificação de senha, bloqueio de tentativas e invalidação de acesso, expondo apenas os endpoints necessários. A conta única será provisionada por procedimento administrativo. Não habilitar endpoints genéricos de registro público. [ASP.NET Core Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-10.0).

Usar cookie de autenticação com `HttpOnly`, `Secure` em produção, domínio restrito ao host e `SameSite=Lax` inicialmente. Definir expiração e revalidação; logout encerra a sessão e alteração/recuperação de senha invalida as sessões conforme política documentada. Persistir e proteger as chaves de Data Protection na hospedagem para que reinícios controlados não invalidem indevidamente cookies. [Autenticação por cookie](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-10.0).

O cookie de autenticação não será lido pelo JavaScript. Um endpoint antiforgery fornecerá um **token de requisição separado** que o frontend manterá em memória e enviará em um header nas operações de alteração. O backend verificará o token, inclusive nos fluxos de login/logout e troca de senha; renovar o token após mudanças de autenticação. Mesmo com mesma origem e SameSite, a proteção CSRF precisa ser implementada e testada. Não usar GET para alterar dados. [Proteção antiforgery do ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-10.0).

O painel poderá carregar a interface React e consultar os dados autenticados pelo navegador. A API é quem decide o acesso; esconder links e proteger a navegação melhora a experiência, mas não concede segurança aos endpoints. Respostas administrativas e de autenticação terão `Cache-Control: no-store`. Não reutilizar caches públicos para dados administrativos.

Na primeira versão, recuperação de acesso pode ser um procedimento local seguro, documentado e auditável. Escolher serviço de e-mail e recuperação automática somente no marco correspondente.

## 4. Fronteiras do backend e contratos — proposta

Ao acrescentar o backend à solução existente, organizar as responsabilidades previstas em `Api`, `Application`, `Domain` e `Infrastructure`, criando abstrações apenas quando houver uso concreto. Dentro delas, agrupar por capacidade: Portfólio, Administração, Contato e Análises. Preservar o console C++ durante essa ampliação. O frontend não consulta o banco nem aplica a decisão final de publicação.

| Contrato | Regra |
|---|---|
| `/api/v1/*` público | DTOs próprios com dados aprovados para divulgação; consultas explícitas por publicação. |
| `/api/v1/auth/*` | Login, logout, identidade atual e senha, com limitação de tentativas e proteção apropriada a cada operação. |
| `/api/v1/admin/*` | Autorização obrigatória no backend, mesmo ao acessar diretamente por HTTP. |
| `/api/v1/admin/projects/{id}/analyses` e `/api/v1/admin/analyses/{id}` | Solicitação e inspeção administrativas. O roteiro lista essas rotas sem um prefixo definitivo; esta proposta as coloca no grupo protegido. |
| `/api/v1/projects/{slug}/analysis` | Somente a análise concluída e selecionada para divulgação de um projeto publicado. |

Definir limites de paginação, filtros, ordenação estável e contratos de erros antes de implementar cada endpoint. Usar Problem Details, código de erro da aplicação e identificador de correlação sem stack traces públicos. Não introduzir agora fila externa, Redis, mediator, repositório genérico ou biblioteca global de estado; reconsiderar apenas diante de uma necessidade demonstrada.

## 5. Publicação, slug e dados — propostas de resolução

Estas interpretações concretizam pontos do roteiro e devem virar critérios verificáveis na primeira entrega de projetos:

- **Arquivado é privado.** O texto “visibilidade controlada” será interpretado como preservação administrativa; RN-010 determina que apenas conteúdo publicado apareça na API pública. Rascunho e arquivado respondem 404 publicamente, inclusive por slug antigo e endpoints de análise.
- **Separar estado editorial e andamento do projeto.** `publicationStatus` representa rascunho/publicado/arquivado. Caso a página precise mostrar “em desenvolvimento” ou “concluído”, isso será outro campo; não expor o estado editorial como andamento técnico.
- **Slug normalizado e único no banco.** Definir comprimento e caracteres permitidos; validar na aplicação e garantir por índice único. Colisão retorna conflito, inclusive quando duas gravações ocorrem ao mesmo tempo.
- **Preservar URLs publicadas.** Ao mudar o slug, manter histórico reservado e redirecionamento permanente para a URL canônica. Um slug antigo não poderá ser atribuído a outro projeto. Consultar o estado atual do destino antes de redirecionar, evitando divulgar rascunhos. Esta proposta escolhe a alternativa de redirecionamento prevista na RN-009.
- **Publicar é uma operação de domínio.** Conferir todos os campos da RN-003, categoria e pelo menos uma tecnologia; impedir vínculos que exponham tecnologia não publicada. Definir se o painel impede ocultar uma tecnologia ainda necessária a projetos publicados ou orienta a correção; propor impedir a operação até corrigir os vínculos.
- **Destaque só produz efeito em publicado.** Contagem, relacionados, busca, sitemap, prévias e análises usam o mesmo critério de visibilidade. Despublicar remove o conteúdo desses acessos na próxima requisição.
- **Instantes em UTC; datas civis como datas.** Criação e publicação são instantes; início de curso ou experiência pode ser apenas data. Não deslocar datas civis por fuso horário.
- **Concorrência de edição.** Acrescentar um controle de versão para impedir que duas abas sobrescrevam alterações sem aviso; o conflito deve preservar os dados digitados.

Criar migrations por entrega. PostgreSQL deve impor unicidade, chaves estrangeiras e restrições aplicáveis; validação HTTP sozinha não protege a consistência. Credenciais e segredos ficam fora do Git. Atualizações de schema em produção serão uma etapa controlada do deploy, com backup e compatibilidade avaliados previamente.

## 6. Mídias e conteúdo rico — proposta

No ambiente local, usar armazenamento de arquivos fora da pasta pública e do código, com metadados no PostgreSQL. Na hospedagem, escolher entre volume persistente ou armazenamento de objetos; não depender do disco temporário da aplicação. A escolha depende de capacidade, backup e limites do provedor, ainda desconhecidos.

Validar extensão permitida, tamanho, assinatura/formato real e dimensões; gerar nomes internos sem usar o caminho informado pelo navegador. Considerar reprocessamento de imagens aceitas, retirar metadados desnecessários e rejeitar SVG/HTML arbitrários na primeira versão. Currículo PDF será um tipo permitido separado. Armazenar texto alternativo e ordem. [Upload seguro no ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-10.0).

O endpoint de download público deve conferir se a mídia está vinculada a conteúdo publicado ou foi explicitamente marcada como pública. Uma URL difícil de adivinhar não torna uma imagem de rascunho privada. Na primeira versão, aplicar essa verificação também ao servir o arquivo; URLs públicas permanentes em um bucket exigiriam uma estratégia adicional para despublicação.

Antes de excluir fisicamente uma mídia, verificar todas as referências. Registrar desvinculação no banco e fazer remoção física com retentativa, evitando perda de arquivo ainda usado. Backups precisam incluir banco e arquivos; testar a restauração de ambos. Para texto rico, começar com Markdown limitado e HTML embutido desabilitado; avaliar sanitização no renderer antes de permitir mais recursos.

## 7. Análises persistentes e execução C++ — proposta para M14–M15

Em M14, evoluir o console C++20 existente para o primeiro analisador independente, adotando CMake e pequenos diretórios controlados para testes. Download e análise de arquivos externos entram em M15 e só serão habilitados quando extração, limites e confinamento estiverem implementados e verificados. O programa C++ percorre arquivos e devolve JSON; nunca compila ou executa conteúdo analisado.

### Fila e recuperação

Persistir a solicitação em `repository_analyses` antes de retornar HTTP 202 com identificador e URL de acompanhamento. Usar estados como `queued`, `running`, `completed`, `failed` e `cancelled`. Acrescentar tentativa, instante da próxima tentativa, proprietário da execução e prazo de reserva da tarefa. São campos de proposta, não alterações já aplicadas ao modelo.

Um `BackgroundService` da aplicação pode buscar trabalho no banco, inicialmente com uma análise por vez. Uma fila em memória pode apenas acordar o serviço; a fonte de verdade é o PostgreSQL. `BackgroundService` gerencia o ciclo de vida do processamento, mas não implementa a persistência do trabalho por conta própria. [Serviços em background no ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-10.0).

Reservar cada tarefa atomicamente em transação curta; uma alternativa é bloqueio da linha com `FOR UPDATE SKIP LOCKED`, seguido de gravação da reserva. Liberar a transação antes do download/processamento. O PostgreSQL documenta esse mecanismo como adequado para consumidores de filas, com as ressalvas de consistência indicadas na documentação. [SELECT e bloqueio de linhas](https://www.postgresql.org/docs/current/sql-select.html).

Atualizar o prazo da reserva durante trabalho longo. Ao reiniciar, recuperar tarefas com reserva vencida segundo política limitada de tentativas. A conclusão verifica o proprietário/token da reserva antes de gravar; uma execução antiga não sobrescreve o resultado da nova. Testar reexecução e idempotência. Adicionar chave de idempotência à solicitação para evitar duplicação por clique repetido ou retentativa de rede, sem impedir uma nova análise intencional.

### Snapshot e fronteira de segurança

Validar `owner` e `repo`, consultar os endpoints oficiais, resolver a referência escolhida para um SHA e baixar o arquivo desse SHA. Registrar SHA, versão do analisador e configuração das regras. O endpoint oficial de arquivos pode redirecionar: validar destino e limitar redirecionamentos; não encaminhar credenciais a hosts não autorizados. [Downloads de repositórios na API GitHub](https://docs.github.com/en/rest/repos/contents#download-a-repository-archive-zip).

Na extração, limitar bytes baixados e descompactados, quantidade de entradas, tamanho individual, profundidade e tempo. Rejeitar caminhos absolutos, navegação para diretórios superiores, links e arquivos especiais. Confirmar que o caminho final permanece dentro do diretório da tarefa antes de escrever. O download e a extração pertencem ao C#; o C++ recebe uma árvore previamente validada.

Executar um binário fixo com argumentos separados, sem shell e sem comandos fornecidos pelo repositório. Não herdar tokens, strings de conexão ou todo o ambiente da API. Limitar e consumir `stdout` e `stderr` sem bloquear o processo; validar tamanho, esquema e consistência do JSON. Interromper a árvore de processos ao exceder o prazo e limpar o diretório também após falhas.

**Confinamento proposto para produção:** processo C++ em ambiente isolado com usuário sem privilégios, rede desabilitada, entrada montada somente para leitura e diretório temporário limitado. Impor limites reais de CPU, memória e processos pelo sistema operacional/runtime. Um timeout em C# não limita memória. Containers podem aplicar esses controles, mas não possuem limites de recursos automaticamente. [Limites no Docker](https://docs.docker.com/engine/containers/resource_constraints/) e [controles de execução](https://docs.docker.com/engine/containers/run/).

A forma de iniciar esse ambiente depende da hospedagem. Não entregar à API acesso irrestrito ao socket Docker ou privilégios administrativos; usar um mecanismo de execução previamente restrito. Se o provedor não permitir o confinamento necessário, selecionar uma hospedagem compatível ou manter o módulo desabilitado até uma solução validada. Essa decisão será tomada antes da integração com GitHub, sem bloquear o portfólio e seu painel.

### Semântica do resultado

Documentar o que conta como linha, como tratar arquivo vazio, última linha sem quebra, CRLF/LF, binários, arquivos ignorados e extensões ambíguas. `.h` poderá ser C/C++. O denominador do percentual é o total de linhas das linguagens reconhecidas; total zero gera lista vazia. Pequenas diferenças por arredondamento precisam ser previstas. Resultado técnico concluído não significa publicação automática: a API pública usará uma análise concluída selecionada para divulgação. Exibir commit e data; contagem de linhas não será nota de qualidade.

## 8. Como validar as decisões

Os testes acompanharão as entregas, priorizando falhas que mudam o comportamento do produto:

| Camada | Evidência esperada |
|---|---|
| Domínio | Publicação incompleta rejeitada; transições editoriais corretas; slug normalizado; conflitos de edição tratados. |
| API + PostgreSQL | Rascunho/arquivado ausentes em todas as projeções públicas; índice único funciona; paginação determinística; consultas e migrations funcionam no PostgreSQL real. |
| Autenticação | Endpoint administrativo rejeita visitante; login válido cria cookie com flags; alteração sem token CSRF é rejeitada; logout e troca de senha respeitam a política de sessão. |
| React e SSR | URL direta entrega conteúdo e metadados em HTML; indisponível responde 404; publicação reflete sem redeploy; formulário pode ser usado por teclado. |
| Mídias | Arquivo inválido é recusado; mídia de rascunho não vaza; excluir vínculo não apaga arquivo usado em outra parte. |
| C++ e integração | Fixtures verificam linhas e ignorados; arquivo malformado não derruba API; timeout e memória são contidos; reinício recupera trabalho; resultado duplicado não corrompe histórico. |
| Operação | Deploy e retorno de versão demonstrados; banco e mídias restaurados em ambiente de teste; logs permitem investigar erro sem credenciais. |

Usar um banco PostgreSQL de teste isolado, não dados de produção. O provedor InMemory não comprova traduções SQL, restrições ou transações reais; os testes relacionais devem exercitar o mesmo banco usado pelo produto. [Estratégia de testes do EF Core](https://learn.microsoft.com/en-us/ef/core/testing/choosing-a-testing-strategy).

## 9. Custos e decisões no momento certo

| Marco | Decisão a concluir | Impacto operacional |
|---|---|---|
| M00 — diagnóstico | Manter a evidência de compilação direta e verificar o fluxo da solução no Visual Studio | Evita confundir fonte compilável com solução completamente validada; preserva arquivos e histórico existentes. |
| M01–M03 — regras e desenho | Consolidar escopo, publicação, slug, contratos e framework SSR | As propostas deste documento se tornam decisões verificáveis antes da implementação correspondente. |
| M04 — base reproduzível | Acrescentar backend/frontend e definir versões; preparar banco Codefy na instância disponível | Fixar ferramentas e lockfiles; manter a solução C++ utilizável e documentar execução de cada componente. |
| M05–M07 — primeira integração | EF Core/Npgsql, migrations e exibição pública com SSR | Validar PostgreSQL real, privacidade de rascunhos e atualização sem redeploy. |
| M08–M09 — administração | Provisionamento, expiração, recuperação manual e chaves de autenticação | Procedimentos de acesso e armazenamento seguro precisam ser exercitados. |
| M10 — mídias | Volume persistente ou objetos, limites e política de retenção | Espaço, tráfego, backup e remoção passam a ser parte do custo. |
| M13 — publicação | Provedor, domínio, HTTPS, proxy, regiões e orçamento | SSR, API e PostgreSQL exigem computação e persistência; comparar limites e preços reais nessa etapa. |
| M14–M15 — analisador | CMake, contrato C++, ambiente isolado e quotas de análise | Acrescenta CPU, memória, espaço temporário e suporte de execução ao provedor. |
| M16–M17 — evoluções e operação | Cache, monitoramento adicional, métricas e e-mail conforme demanda | Analytics e e-mail podem acrescentar serviços, retenção e custo; operação acompanha cada publicação. |

Não há estimativa de preço ou compromisso de hospedagem neste documento. A sequência de implementação segue o [plano mestre](../planejamento/00-plano-mestre.md): concluir M00, resolver escopo e regras em M01–M03, ampliar a base existente em M04 e demonstrar a primeira integração em M05–M07. As demais propostas serão resolvidas junto ao marco que delas depende.
