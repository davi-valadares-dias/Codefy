# Codefy — plano mestre de execução

**Estado:** roteiro proposto a partir da especificação v2 recebida e da inspeção do projeto em `C:\Users\Infortronic\Documents\work\Codefy`: console C++20 inicial, solução `Codefy.slnx`, branch `master` e remoto GitHub configurado. Nenhuma funcionalidade do portfólio está implementada nessa base.

## 1. Objetivo e forma de trabalhar

Construir um portfólio individual com conteúdo administrável e um analisador de código em C++, desenvolvendo também a capacidade de explicar, testar, publicar e manter o sistema.

Stack definida no documento: React + TypeScript; ASP.NET Core + C#; PostgreSQL + Entity Framework Core; C++ + CMake; Git + GitHub. Backend em monólito modular, um administrador, nenhum cadastro público. As bibliotecas, versões do projeto e hospedagem serão verificadas ou escolhidas nos marcos correspondentes.

Em cada incremento:

1. **Antes:** definir o problema, o comportamento esperado, os limites e os critérios de aceite.
2. **Desenho:** apresentar o fluxo, os dados e o contrato que realmente serão necessários.
3. **Implementação:** escrever uma alteração pequena e explicar as responsabilidades.
4. **Verificação:** executar, testar casos importantes e revisar erros e efeitos colaterais.
5. **Registro:** atualizar documentação e preparar um commit coerente com o resultado.
6. **Revisão conjunta:** o proprietário explica o fluxo, valida a entrega e escolhemos a próxima tarefa do plano.

Uma etapa pode ocupar vários encontros. Etapas extensas serão divididas em tarefas independentes de aproximadamente uma sessão de trabalho; o tamanho da sessão dependerá da disponibilidade do proprietário. Não haverá um calendário fictício antes disso ser conhecido.

## 2. Entregas e recorte do produto

| Entrega | Conteúdo | Condição para avançar |
|---|---|---|
| E0 — diagnóstico e plano | Inventário do projeto existente, ambiente, requisitos, decisões iniciais e primeira tarefa | Conseguimos explicar como o projeto atual abre, compila e executa, ou temos um diagnóstico reproduzível do bloqueio |
| E1 — primeira integração interna | Um projeto persistido no PostgreSQL, consultado pela API e exibido pelo React; rascunhos privados | Dados reais atravessam as três camadas e as consultas públicas não expõem rascunhos |
| E2 — MVP publicável | Perfil/Home/Sobre; projetos com detalhes, busca, filtros, paginação e relacionados; tecnologias; login/admin; mídia; PDF de currículo pronto; contato e mensagens; qualidade, deploy e recuperação | Conteúdo administrável, regras protegidas, páginas indexáveis, validação da versão publicada e restauração exercitada |
| E3 — trajetória estruturada | Experiências, formação, linha do tempo e certificações com gestão e apresentação completas | Dados e relações consistentes, interface pública e administrativa verificadas |
| E4 — diferencial técnico | Analisador C++ independente e depois integrado ao GitHub, com tarefas persistentes e resultados vinculados a commits | Limites e falhas controlados, métricas corretas e execução isolada validada |
| E5 — evoluções | Currículo dinâmico, recuperação de acesso pela interface, notificações e métricas de visitantes, quando habilitadas | Cada recurso tem critérios próprios e não compromete o funcionamento existente |

**Recorte proposto, a confirmar com o proprietário:** experiências e formação têm prioridade média nas seções específicas, mas aparecem também na seção Sobre, classificada como essencial. Para E2, a biografia pode apresentar o resumo da trajetória; os cadastros estruturados entram em E3. Se estes forem necessários na primeira publicação, o marco 12 será antecipado. Nenhum desses requisitos é descartado.

Segurança, acessibilidade e tratamento de erros fazem parte das entregas desde a primeira implementação. O marco de publicação consolida essas verificações.

## 3. Marcos em ordem de execução

### M00 — conhecer o projeto existente

**Antes do código:** obter a pasta raiz; procurar instruções locais; identificar `.sln`, `.slnx`, `.csproj`, `.vcxproj`, `CMakeLists.txt`, `package.json` e arquivos de configuração existentes.

**Passos:**

1. Identificar o repositório, a branch atual, o remoto, commits recentes e alterações não commitadas.
2. Entender qual template o Visual Studio criou e quais projetos compõem a solução.
3. Separar fontes, configurações e artefatos de compilação no diagnóstico.
4. Executar o procedimento de build existente e registrar o resultado.
5. Propor somente as mudanças necessárias para chegar à arquitetura desejada.

**Depois:** produzir um mapa do estado atual e da próxima alteração. Se o projeto inicial for C++, avaliar seu aproveitamento no analisador. Se for ASP.NET ou React, aproveitar sua base correspondente. As pastas `x64`, `bin` e `obj` serão entendidas antes de qualquer limpeza; arquivos existentes não serão movidos indiscriminadamente.

**Concluído quando:** sabemos o que existe, o que funciona e como evoluir sem perder trabalho.

### M01 — fechar escopo e regras do primeiro lançamento

**Pré-requisito:** diagnóstico inicial.

1. Identificar o público e os principais caminhos: conhecer o desenvolvedor, avaliar um projeto, acessar currículo e entrar em contato.
2. Confirmar E2 e as evoluções; transformar requisitos em tarefas identificáveis.
3. Definir vocabulário: projeto, categoria, tecnologia, publicação, destaque, arquivamento e andamento do trabalho.
4. Resolver primeiro as ambiguidades que afetam o modelo: visibilidade de arquivados, status editorial versus status de desenvolvimento, tecnologias privadas e mudança de slug.
5. Escrever cenários de aceite para a primeira integração e para publicação/despublicação.

**Depois:** registrar decisões e itens ainda pendentes, com o marco em que serão resolvidos.

**Concluído quando:** a primeira entrega cabe em um escopo compreensível, com comportamento verificável e sem regras contraditórias.

### M02 — conteúdo, navegação e interface

1. Mapear páginas públicas e administrativas, separando acesso público de operações restritas.
2. Preparar textos e dados reais mínimos: nome, título, biografia, links, um projeto e currículo, quando disponíveis.
3. Desenhar os fluxos de navegação e wireframes de Home, projetos, detalhe, login e editor de projeto.
4. Definir tipografia, cores, espaçamento, componentes de formulário e comportamento em celular.
5. Projetar carregamento, vazio, erro, sucesso, 404, foco do teclado e mensagens de validação.
6. Definir a apresentação de fotografias, capas e links opcionais ausentes.

**Depois:** revisar os principais caminhos antes de construir páginas completas. Dados demonstrativos serão identificados e substituídos antes da publicação.

**Concluído quando:** sabemos o que cada tela permite fazer e como verificar sua acessibilidade básica.

### M03 — arquitetura e contratos iniciais

1. Reaproveitar a estrutura existente e planejar a organização progressiva em `frontend`, `backend`, `analyzer`, `docs` e testes.
2. Definir dependências das camadas: domínio sem dependência de interface ou infraestrutura; aplicação orquestra casos de uso; infraestrutura implementa persistência e integrações; API compõe os serviços e expõe HTTP.
3. Escolher a estratégia React que entregue HTML indexável e atualize conteúdo sem um deploy a cada edição.
4. Desenhar a mesma origem pública para páginas e `/api`, incluindo roteamento local e futuro proxy de produção.
5. Definir DTOs públicos e administrativos, paginação, erros, datas e contratos da primeira funcionalidade.
6. Registrar autenticação por cookie e proteção CSRF como desenho a implementar, com o backend responsável pela autorização.

**Depois:** manter decisões curtas com contexto, escolha, motivo e consequência. Não criar abstrações sem um caso de uso real.

**Concluído quando:** conseguimos seguir uma requisição do navegador ao banco e explicar onde cada responsabilidade fica.

### M04 — base reproduzível e primeira execução

1. Verificar e fixar versões compatíveis com o projeto existente; registrar comandos de instalação e execução.
2. Ajustar `.gitignore`, formatação, finais de linha e documentação de configuração.
3. Organizar projetos e referências somente conforme necessário; manter o Visual Studio abrindo a solução corretamente.
4. Configurar dados de desenvolvimento e segredos fora do Git; documentar nomes das configurações sem incluir valores privados.
5. Preparar banco dedicado ao Codefy e usuário com permissões adequadas, depois de confirmar a instância e o destino.
6. Criar uma API mínima executável, uma verificação de processo e uma página React inicial.
7. Adicionar verificações de build, tipagem e testes existentes ao fluxo do GitHub, respeitando a configuração do repositório.

**Depois:** reproduzir o procedimento usando somente o README e a configuração local documentada. Não tratar uma verificação de processo como prova de que o banco está acessível.

**Concluído quando:** os componentes iniciais executam de forma previsível e uma alteração inválida é detectada pelas verificações correspondentes.

### M05 — dados e regras de projetos

1. Modelar somente os dados necessários ao incremento: projetos, categorias, tecnologias e relações.
2. Separar estado de publicação de andamento do projeto, caso a decisão de M01 confirme essa necessidade.
3. Definir campos obrigatórios, limites, índices, unicidade do slug e comportamento de exclusões.
4. Implementar regras de rascunho, publicação, despublicação, destaque e arquivamento.
5. Configurar EF Core/PostgreSQL e criar a primeira migration revisada.
6. Preparar dados locais determinísticos para desenvolvimento, sem credenciais ou informações pessoais fictícias apresentadas como reais.
7. Testar regras relevantes e integridade de persistência, incluindo duplicidade de slug e publicação incompleta.

**Depois:** revisar o esquema e provar que os dados permanecem após reiniciar a aplicação. Verificar separadamente um banco novo e o caminho de evolução de um banco existente.

**Concluído quando:** a persistência e as regras fundamentais funcionam com PostgreSQL e erros têm comportamento conhecido.

### M06 — API pública de projetos

1. Implementar listagem de publicados e detalhe por slug com DTOs explícitos.
2. Implementar filtros por categoria/tecnologia, pesquisa por título, ordenação determinística e paginação limitada.
3. Definir o significado dos totais, destaques e tecnologias públicas relacionadas.
4. Tratar 404 de projeto ausente ou privado sem expor conteúdo administrativo.
5. Padronizar erros com Problem Details e documentar o contrato da API.
6. Testar filtros combinados, fronteiras da paginação, total de publicados e ausência de vazamento por relações.

**Depois:** executar exemplos de requisições válidas e inválidas; revisar dados públicos e campos internos.

**Concluído quando:** os consumidores conseguem listar e consultar somente o conteúdo autorizado para publicação.

### M07 — primeira integração completa com React

1. Conectar a listagem e a página de detalhe à API real.
2. Usar a estratégia de renderização definida em M03 para conteúdo público e metadados.
3. Implementar URLs, carregamento, erro, vazio, imagem ausente e links opcionais.
4. Exibir título, resumo, categoria e tecnologias do projeto persistido.
5. Verificar teclado, leitura em celular e HTML recebido na requisição inicial.
6. Alterar a publicação no ambiente de desenvolvimento e verificar o efeito na API e no site, sem editar o frontend.

**Depois:** demonstrar a primeira integração; explicar o papel do navegador, servidor de páginas, API e banco.

**Concluído quando:** E1 está comprovada. Essa é uma entrega interna; a administração completa virá nos marcos seguintes.

### M08 — identidade e sessão administrativa

1. Definir como criar a única conta administrativa de forma controlada, sem cadastro público ou senha fixa no código.
2. Implementar hash de senha com mecanismo consolidado, login, consulta de sessão e logout.
3. Configurar cookie seguro para produção, expiração e resposta de endpoints de API a acessos não autenticados.
4. Implementar proteção CSRF para operações que alteram dados, conforme o fluxo real de cookies.
5. Limitar tentativas de login e permitir alteração de senha com as verificações necessárias.
6. Documentar e exercitar recuperação administrativa segura antes da interface futura de recuperação.
7. Testar acesso direto aos endpoints, credenciais inválidas, sessão expirada e tentativas sem proteção CSRF válida.

**Depois:** verificar que ocultar uma página no React não é o mecanismo de autorização; as operações precisam ser protegidas na API.

**Concluído quando:** existe uma sessão administrativa utilizável e operações privadas são recusadas no servidor quando não autorizadas.

### M09 — administração de projetos, tecnologias e perfil

1. Implementar casos de uso e endpoints administrativos com validação e autorização.
2. Criar lista administrativa e formulários de projeto, categoria e tecnologia.
3. Implementar rascunho, publicação, despublicação, arquivamento, destaque e ordem com as regras acordadas.
4. Tratar confirmação de exclusão, associações existentes e mudança de URL pública.
5. Criar edição do perfil e links sociais; integrar Home e Sobre aos dados do perfil.
6. Exibir dashboard com totais reais de projetos e alterações registradas; acrescentar mensagens quando o módulo existir.
7. Implementar projetos relacionados pelo critério acordado de tecnologias em comum.
8. Completar o detalhe público com descrições, objetivo/problema/solução, funcionalidades, arquitetura, desafios, aprendizados, datas e andamento; integrar galeria em M10 e análises em M15.
9. Completar a apresentação pública de tecnologias com categorias, ícones, ordem e ocultação das não publicadas, inclusive em relações com projetos.
10. Testar um ciclo completo: entrar, cadastrar, publicar, visitar, editar, despublicar e conferir a remoção pública.

**Depois:** revisar a experiência do administrador e os dados disponíveis publicamente.

**Concluído quando:** projetos, tecnologias e perfil são administráveis sem alteração de código ou novo deploy.

### M10 — mídia e currículo inicial

1. Definir formatos aceitos, tamanhos máximos, armazenamento persistente e metadados.
2. Implementar envio autenticado, validação de extensão/conteúdo conforme o tipo, nomes gerados e tratamento seguro dos arquivos.
3. Integrar fotografia, capa, galeria e texto alternativo; limitar custo de imagens grandes.
4. Controlar referências a arquivos para evitar exclusões que quebrem conteúdo compartilhado.
5. Disponibilizar um currículo PDF previamente preparado; validar publicação, substituição e download.
6. Testar arquivo inválido, excesso de tamanho, substituição e remoção de mídia referenciada.

**Depois:** demonstrar que mídia não desaparece em uma reinicialização ou atualização de versão e incluir seus arquivos no plano de backup.

**Concluído quando:** o administrador gerencia as mídias previstas e o site exibe ou omite corretamente os elementos opcionais.

### M11 — contato e mensagens

1. Definir campos, limites, finalidade da coleta e prazo de retenção adotado pelo projeto.
2. Implementar validações na interface e na API, armazenamento e confirmação de envio.
3. Aplicar limitação de requisições e proteção antispam adequada ao fluxo.
4. Implementar consulta administrativa, leitura e exclusão de mensagens.
5. Integrar indicadores reais ao dashboard e alternativas de contato ao site.
6. Testar campos inválidos, limites, duplicação acidental de envio e acesso não autorizado às mensagens.

**Depois:** conferir que nenhuma mensagem ou e-mail recebido aparece em respostas públicas ou logs indevidos. O fluxo inicial armazena mensagens; envio de e-mail é uma evolução identificada.

**Concluído quando:** visitantes conseguem enviar mensagens válidas e somente o administrador consegue consultá-las.

### M12 — trajetória, formação e certificações

**Posição sugerida:** E3, após a primeira publicação; antecipar o que for confirmado como necessário para E2.

1. Modelar experiências, tecnologias relacionadas, formação, eventos da linha do tempo e certificações.
2. Definir publicação, ordenação e datas; experiência atual pode ter término vazio.
3. Implementar operações administrativas e respostas públicas adequadas.
4. Construir telas com estados vazios para quem ainda não possui experiências ou certificados.
5. Validar credenciais e arquivos escolhidos para divulgação pelo proprietário.
6. Testar datas inválidas, ordenação, associações e ocultação do conteúdo privado.

**Depois:** revisar coerência entre Home, Sobre, trajetória e currículo.

**Concluído quando:** cada módulo escolhido pode ser mantido pelo administrador e apresentado corretamente ao público.

### M13 — preparação e publicação do MVP

**Pré-requisito:** M00–M11 concluídos, além dos itens de M12 incluídos no escopo confirmado.

1. Revisar responsividade, navegação por teclado, contraste, formulários e temas claro/escuro, incluindo movimento reduzido.
2. Completar metadados por página, Open Graph, sitemap, robots e dados estruturados coerentes com os dados reais.
3. Verificar XSS, autorização, CSRF, uploads, limites, segredos, tratamento de erros e registros sem credenciais.
4. Executar testes relevantes de domínio, API com PostgreSQL e jornadas completas do visitante e administrador.
5. Medir performance, acessibilidade e SEO em condições registradas; as metas Lighthouse de 90 são objetivos a verificar, não uma garantia.
6. Escolher hospedagem compatível com os componentes e com a futura execução isolada do C++; registrar custos reais antes da contratação.
7. Preparar ambiente de homologação, HTTPS, configurações, persistência, migrations e criação controlada do administrador.
8. Configurar logs úteis, diagnóstico de falhas e verificações de processo e prontidão sem expor dados internos publicamente.
9. Criar backup do banco e das mídias e testar restauração em ambiente separado.
10. Documentar atualização e retorno à versão anterior, incluindo compatibilidade de banco; não presumir que toda migration pode ser revertida sem perda.
11. Validar a publicação em homologação e apresentar o resultado antes de ações externas que precisem de escolha de conta, domínio ou custo.
12. Publicar no destino autorizado, verificar os fluxos reais e registrar a versão.

**Depois:** executar uma verificação curta de produção: páginas, sessão, uma edição controlada, download, contato e saúde dos serviços.

**Concluído quando:** E2 está disponível no destino escolhido, verificada e acompanhada de procedimentos de operação e recuperação.

### M14 — analisador C++ independente

1. Definir exatamente o que significa linha contada, como tratar arquivo vazio/final sem quebra e como calcular os percentuais.
2. Versionar o contrato de entrada/saída e separar JSON em saída padrão de diagnósticos em saída de erro.
3. Configurar CMake e testes com diretórios de exemplo pequenos e determinísticos.
4. Implementar percurso dos arquivos permitidos, classificação por extensão e tratamento de `.h` ambíguo.
5. Ignorar dependências, gerados, binários e links simbólicos conforme a política definida.
6. Implementar limites de arquivos, tamanho individual, volume total e duração; documentar as diferenças entre limites internos e limites externos do processo.
7. Gerar estatísticas por linguagem e resultado vazio seguro quando não houver linguagens reconhecidas.
8. Testar permissões negadas, codificações definidas no contrato, quebras de linha, arquivos grandes, diretório vazio e erro parcial.

**Depois:** comparar resultados com expectativas calculadas dos arquivos de teste e documentar build/uso no sistema de produção escolhido.

**Concluído quando:** o executável funciona isoladamente, tem métricas verificadas e nunca compila ou executa código analisado.

### M15 — GitHub, fila persistente e integração C# → C++

1. Implementar vínculo validado de proprietário/repositório público, sem download de URL arbitrária.
2. Consultar endpoints oficiais, identificar um commit e baixar seu snapshot com limites.
3. Validar extração contra escape de diretório, links, excesso de arquivos e crescimento desproporcional do conteúdo extraído.
4. Persistir solicitação e estados da análise antes de responder `202 Accepted` com identificador.
5. Implementar processamento em segundo plano com recuperação após reinício, controle de concorrência, tentativas limitadas e prevenção de execução duplicada indevida.
6. Preparar diretório isolado; iniciar o executável sem shell, sem credenciais GitHub e com tempo e recursos limitados na infraestrutura escolhida.
7. Capturar saída sem bloquear o processo, limitar seu tamanho e validar esquema e consistência dos resultados.
8. Armazenar resultado, commit, datas e erros apropriados; limpar temporários em sucesso e falha.
9. Exibir histórico no admin e resultado público conforme uma política explícita de publicação da análise.
10. Testar repositório inacessível, limites GitHub, snapshot inválido, JSON inválido, timeout, falha de processo, reinício do servidor e falha de limpeza.

**Depois:** provar que um erro de análise não indisponibiliza o portfólio e que os dados identificam a versão analisada. Métricas representam volume de código, não qualidade ou produtividade.

**Concluído quando:** E4 funciona no ambiente de destino com recuperação, limites e isolamento comprovados. A integração externa ficará desabilitada até essas condições estarem atendidas.

### M16 — evoluções do produto

Tratar cada item como um incremento independente:

1. **Currículo dinâmico:** seleção de projetos/experiências, seções opcionais, geração consistente, atualização e validação visual do PDF.
2. **Recuperação pela interface:** fluxo de comprovação, tokens de uso único/expiração e testes contra reutilização e exposição de contas.
3. **Notificação por e-mail:** provedor escolhido, configuração de segredos, tratamento de falhas e envio sem duplicação indevida.
4. **Estatísticas de visitantes:** definir eventos, minimização e retenção de dados; implementar coleta antes de apresentar números; excluir tráfego de teste conforme a política adotada.
5. **Aperfeiçoamentos administrativos:** configurações gerais, auditoria e navegação de histórico conforme necessidades e escopo narrativo da especificação.

**Depois:** documentar custos e comportamento quando cada recurso estiver desabilitado ou indisponível.

**Concluído quando:** cada evolução escolhida foi validada e incorporada à documentação de operação. Itens adiados continuam identificados no backlog.

### M17 — operação e evolução contínua

1. Acompanhar falhas e erros de uso com logs úteis e sem dados sensíveis desnecessários.
2. Verificar backups, exercitar restauração periodicamente e revisar retenção de mensagens, análises e arquivos temporários.
3. Atualizar dependências de forma controlada, executando os testes relevantes antes de publicar.
4. Rever acessibilidade, indexação e desempenho após mudanças significativas.
5. Registrar correções, versões e decisões; manter exemplos e instruções de instalação atualizados.
6. Avaliar novas funcionalidades conforme benefício, complexidade e manutenção exigida.

**Concluído quando:** o procedimento de manutenção está documentado e foi exercitado. Manutenção futura é atividade contínua, não uma promessa de monitoramento automático nesta conversa.

## 4. Ordem de dependência

Sequência principal: M00 → M01 → M02 → M03 → M04 → M05 → M06 → M07 → M08 → M09 → M10 → M11 → M13.

M12 entra antes de M13 somente no recorte confirmado como necessário para a primeira publicação; o restante vem depois. M14 pode ser estudado isoladamente, mas M15 depende de M14, autenticação, persistência e desenho da infraestrutura. M16 contém evoluções independentes; M17 acompanha cada versão publicada.

## 5. Primeiras tarefas práticas

| Ordem | Tarefa | Evidência esperada |
|---|---|---|
| 1 | Identificar pasta e solução existentes | Caminhos e tipo de projeto confirmados |
| 2 | Inspecionar Git e instruções locais | Branch, remoto, alterações e comandos existentes registrados |
| 3 | Executar o projeto atual | Build e execução observados, ou erro reproduzível registrado |
| 4 | Decidir como reaproveitar a base | Estrutura atual mapeada para os componentes futuros |
| 5 | Confirmar E2 e as primeiras regras ambíguas | Pequeno conjunto de decisões documentado |
| 6 | Preparar a primeira alteração de infraestrutura | Projeto continua compilando com procedimento reproduzível |
| 7 | Implementar o primeiro dado de projeto | Persistência e validação verificadas |
| 8 | Consultar pela API e renderizar no React | Primeira integração demonstrada |

O proprietário já criou projeto e GitHub. As tarefas 1 e 2 foram verificadas: solução C++ localizada, repositório inspecionado e árvore inicialmente limpa. A tentativa de build da cópia da solução encontrou restrição do FileTracker no ambiente de execução; as evidências e a verificação alternativa do compilador ficam no diagnóstico. Não criar outro repositório.

## 6. Critérios gerais de conclusão

Uma funcionalidade fica concluída quando:

- seus critérios de aceite estão satisfeitos e o comportamento foi demonstrado;
- validações e autorização são aplicadas no backend quando necessárias;
- os testes relevantes cobrem regras, integrações e falhas de maior impacto;
- existem estados de interface coerentes e mensagens compreensíveis;
- nenhuma informação privada ou segredo foi incluído indevidamente no Git, respostas ou logs;
- documentação e migrations correspondem ao resultado real;
- o diff foi revisado e a alteração pode ser explicada pelo proprietário;
- o commit preparado descreve uma alteração coerente.

Mudanças pequenas de texto ou aparência não exigem testes que apenas repitam a implementação. Regras de negócio, persistência, autenticação, publicação e processamento externo exigem verificação apropriada ao risco.

## 7. Modelo de tarefa para o repositório

```text
Título: [módulo] comportamento esperado
Referências: RF/RN/RNF aplicáveis
Problema: quem precisa fazer o quê e por quê
Escopo: alteração pequena desta tarefa
Dependências: decisões ou entregas necessárias
Critérios de aceite: cenários observáveis
Verificação: teste automatizado e/ou roteiro manual adequado
Documentação: contrato, configuração ou decisão a atualizar
Evidência final: resultado real da execução
```

GitHub Issues, Projects e pull requests poderão representar essas tarefas, aproveitando o fluxo já adotado. Esta preparação não criou issues nem publicou conteúdo no GitHub.

## 8. Limites conhecidos do planejamento

- O anexo termina na seção 36, em “Evolução de acess”. O restante não foi recebido nem presumido.
- O projeto existente foi inspecionado. Confirmar a execução pelo Visual Studio com o proprietário, pois o build MSBuild neste ambiente restrito encontrou falha de acesso no FileTracker.
- Experiência e disponibilidade do proprietário ainda não foram informadas; não há prazo fechado.
- Bibliotecas e hospedagem são propostas a avaliar; não foram instaladas ou contratadas nesta etapa.
- O plano será atualizado quando o código real revelar trabalho já concluído ou restrições adicionais.
