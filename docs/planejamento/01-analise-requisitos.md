# Codefy — análise e rastreabilidade dos requisitos

**Situação:** planejamento para revisão conjunta; não representa funcionalidades implementadas nem decisões técnicas adicionais aprovadas.

**Fonte:** documento colado “Codefy. Personal Developer Portfolio — Documento de Requisitos e Especificações Técnicas”, versão 2.0, datado de 20 de setembro de 2026.

**Limite da fonte:** o arquivo recebido termina na seção 36, “Estatísticas de visitantes”, com o trecho incompleto “Evolução de acess”. Não recebemos a continuação. Esta análise cobre somente o conteúdo efetivamente disponível; não presume seções posteriores nem completa a frase.

**Contexto atual do projeto:** o Codefy existente foi localizado em `C:\Users\Infortronic\Documents\work\Codefy`. A solução `Codefy.slnx` referencia `Codefy.vcxproj`, um console C++20 com o exemplo Hello World. O diagnóstico identificou a branch `master` acompanhando `origin/master`, dois commits existentes e nenhuma alteração nos arquivos rastreados. O remoto é [davi-valadares-dias/Codefy](https://github.com/davi-valadares-dias/Codefy.git). Ainda não foram identificados frontend, backend ou configuração CMake. O console atual é um ponto de partida a avaliar para aproveitamento; não representa o analisador implementado.

Esta pasta contém entregáveis de planejamento, não um novo repositório de aplicação. As mudanças futuras deverão aproveitar o projeto existente. O inventário acima registra o estado observado no diagnóstico; build, comportamento de execução e conclusão de cada etapa exigem suas próprias evidências.

## 1. Avaliação do roteiro recebido

O documento oferece uma base consistente: delimita um produto individual, separa o site público do painel administrativo, identifica 105 requisitos funcionais, define 20 regras de negócio e reúne 14 requisitos não funcionais de segurança. Também preserva um espaço próprio para o C++, cuja responsabilidade é medir arquivos de código, sem substituir o backend C#.

Sua principal qualidade é conectar conteúdo gerenciável, regras de publicação e análise de repositórios em um produto demonstrável. Já prevê pontos que frequentemente ficam para depois: snapshots identificados por commit, proteção da extração de arquivos, execução em segundo plano, recuperação de tarefas após reinício e restrição de dados públicos.

Ainda não é uma especificação pronta para implementar integralmente. Parte do comportamento está apenas na narrativa; alguns exemplos de tabelas e endpoints não atendem todos os fluxos descritos; faltam limites numéricos, contratos e decisões de apresentação. A primeira entrega deverá concretizar um subconjunto verificável, mantendo o restante do escopo rastreado.

### Compromissos já presentes na fonte

- Produto de uso individual, com uma conta administrativa e sem cadastro público, equipes, organizações, cobrança ou portfólios para terceiros.
- React e TypeScript no frontend; ASP.NET Core e C# no backend; PostgreSQL e Entity Framework Core na persistência; C++ com CMake no analisador; Git/GitHub para versionamento e Visual Studio como IDE principal.
- Um monorepositório e um monólito modular. O executável C++ tem responsabilidade especializada e é invocado pelo backend.
- Conteúdo público obtido pelo backend e editável sem alterar código ou realizar novo deploy a cada alteração de conteúdo.
- Publicação controlada: rascunhos e conteúdo privado não podem vazar pela API pública.
- Analisador restrito inicialmente a repositórios públicos escolhidos pelo administrador; nunca compila nem executa o código analisado.
- Estrutura de diretórios e tabelas criada conforme a necessidade da etapa, sem preencher o repositório com pastas ou abstrações vazias.

### O que precisa ser definido durante o projeto

- Contratos HTTP, modelo de publicação, formatos de texto, política de mídias e comportamento de paginação e ordenação.
- Estratégia de renderização e atualização do conteúdo para SEO.
- Autenticação administrativa, recuperação de acesso e provisionamento da primeira conta.
- Plataforma de hospedagem, suporte ao processo C++, armazenamento persistente e rotina de restauração de backups.
- Critérios mensuráveis do analisador, seus limites e a recuperação dos trabalhos em andamento.
- Conteúdo real, identidade visual final, rotinas de manutenção e critérios de aceite de cada entrega.

## 2. Prioridades propostas sem descarte de escopo

As entregas E0 a E5 abaixo seguem a mesma identificação do [plano mestre](00-plano-mestre.md) e são uma **proposta de sequência**, sujeita à revisão com o usuário. E2 corresponde ao MVP publicável. A prioridade original do documento permanece registrada; adiar um requisito não o torna opcional nem concluído. Não há estimativa de prazo antes de conhecer as condições de execução e o ritmo de desenvolvimento.

| Marco | Resultado verificável | Conteúdo principal |
|---|---|---|
| E0 | Diagnóstico e plano | Inventário do projeto existente, ambiente, Git, requisitos, decisões iniciais e primeira tarefa; explicar a base atual e registrar sua compilação/execução ou bloqueio reproduzível. |
| E1 | Primeira integração interna | Conexão com PostgreSQL, migrations, projeto persistido acessível pela API e interface React; rascunho inacessível publicamente. |
| E2 — MVP | Primeira versão publicável e administrável | Perfil, Home, Sobre, projetos com busca, filtros, paginação, detalhes e relacionados; tecnologias, contato, currículo estático, autenticação, gerenciamento principal, mídia, dashboard básico, SEO, acessibilidade, segurança, publicação e restauração verificadas. |
| E3 | Trajetória profissional estruturada | Experiências, formação, linha do tempo e certificações; respectivos cadastros, relações, permissões de divulgação e ordenação. |
| E4 | Diferencial C++ integrado com segurança | Analisador independente, contrato JSON, obtenção do snapshot, fila persistente, limites, histórico e exibição pública controlada das análises. |
| E5 | Evoluções documentadas | Currículo dinâmico, recuperação de acesso pela interface, notificações de contato por e-mail e métricas reais de visitantes quando habilitadas. |

A entrega E2 é maior que o primeiro exercício. A primeira fatia local em E1 não precisa conter login, uploads ou todo o painel para demonstrar leitura pública, mas **não pode ser publicada como produto pronto** sem os controles e operações de E2. Requisitos de segurança, acessibilidade e tratamento de erros acompanham a funcionalidade correspondente desde sua implementação.

O documento trata “Sobre mim” como essencial, mas reúne ali histórico e formação. A proposta coloca a biografia no E2 e os registros estruturados de trajetória e formação na E3. Essa divisão precisa ser confirmada na definição do E2; se o histórico estruturado for indispensável ao primeiro lançamento, RF-015 e RF-016 e suas dependências devem entrar no E2.

RF-073 tem uma entrega parcial explícita no documento: procedimento seguro de recuperação no E2 e fluxo pela aplicação após o E2. O procedimento não deve ser apresentado como se a interface de recuperação estivesse implementada.

## 3. Inventário dos requisitos funcionais

**Leitura:** a coluna “Marco proposto” indica quando comprovar o requisito completo. “Prioridade original” é a prioridade do módulo informada na fonte. Todos os itens abaixo estão com situação **planejado**, sem alegação de implementação.

### Home — prioridade original: essencial

| ID | Comportamento a comprovar | Marco proposto |
|---|---|---|
| RF-001 | Exibir nome e título profissional obtidos da API. | E2 |
| RF-002 | Exibir fotografia do perfil com alternativa acessível. | E2 |
| RF-003 | Exibir descrição resumida do perfil. | E2 |
| RF-004 | Exibir disponibilidade profissional configurada no painel. | E2 |
| RF-005 | Mostrar projetos destacados somente se publicados. | E2 |
| RF-006 | Apresentar tecnologias principais configuradas. | E2 |
| RF-007 | Disponibilizar download ou acesso ao currículo vigente. | E2, PDF previamente gerado |
| RF-008 | Exibir links válidos de GitHub e LinkedIn. | E2 |
| RF-009 | Oferecer ação de contato acessível. | E2 |
| RF-010 | Calcular a quantidade de projetos considerando apenas publicados. | E2 |

### Sobre mim — prioridade original: essencial

| ID | Comportamento a comprovar | Marco proposto |
|---|---|---|
| RF-011 | Apresentar a biografia completa. | E2 |
| RF-012 | Exibir fotografia na apresentação pessoal. | E2 |
| RF-013 | Exibir resumo profissional. | E2 |
| RF-014 | Apresentar áreas de interesse. | E2 |
| RF-015 | Exibir trajetória profissional. | E3; validar dependência no E2 |
| RF-016 | Apresentar formação acadêmica. | E3; validar dependência no E2 |
| RF-017 | Exibir objetivos profissionais. | E2 |
| RF-018 | Disponibilizar links de contato. | E2 |

### Listagem pública de projetos — prioridade original: crítica

| ID | Comportamento a comprovar | Marco proposto |
|---|---|---|
| RF-019 | Listar somente projetos publicados. | E1, consolidar no E2 |
| RF-020 | Exibir imagem de capa quando cadastrada e estado adequado quando ausente. | E2 |
| RF-021 | Exibir título e descrição curta. | E1, consolidar no E2 |
| RF-022 | Exibir tecnologias associadas que possam ser divulgadas. | E2 |
| RF-023 | Filtrar projetos por categoria. | E2 |
| RF-024 | Filtrar projetos por tecnologia. | E2 |
| RF-025 | Pesquisar projetos pelo título. | E2 |
| RF-026 | Ordenar resultados por data conforme regra definida. | E2 |
| RF-027 | Paginar resultados com parâmetros e limites validados. | E2 |
| RF-028 | Abrir detalhes do projeto por URL própria. | E1, consolidar no E2 |

### Detalhes de projetos — prioridade original: crítica

| ID | Comportamento a comprovar | Marco proposto |
|---|---|---|
| RF-029 | Exibir informações completas do projeto e seus campos opcionais disponíveis. | E2 |
| RF-030 | Exibir galeria de imagens na ordem configurada. | E2 |
| RF-031 | Exibir funcionalidades cadastradas. | E2 |
| RF-032 | Exibir tecnologias relacionadas ao projeto. | E2 |
| RF-033 | Disponibilizar link válido do GitHub quando informado. | E2 |
| RF-034 | Disponibilizar link de demonstração quando informado. | E2 |
| RF-035 | Exibir status do projeto com semântica definida. | E2 |
| RF-036 | Exibir projetos relacionados por tecnologias em comum. | E2 |
| RF-037 | Exibir análise técnica disponível e autorizada para divulgação. | E4 |

### Tecnologias e habilidades — prioridade original: essencial

| ID | Comportamento a comprovar | Marco proposto |
|---|---|---|
| RF-038 | Exibir tecnologias cadastradas para publicação. | E2 |
| RF-039 | Agrupar tecnologias por categoria. | E2 |
| RF-040 | Exibir ícones das tecnologias com tratamento de ausência. | E2 |
| RF-041 | Relacionar tecnologia aos seus projetos públicos. | E2 |
| RF-042 | Respeitar a ordenação configurada das tecnologias. | E2 |
| RF-043 | Ocultar tecnologias não publicadas em todas as respostas públicas aplicáveis. | E2 |

### Experiências — prioridade original: média

| ID | Comportamento a comprovar | Marco proposto |
|---|---|---|
| RF-044 | Exibir histórico profissional. | E3 |
| RF-045 | Exibir empresa e cargo. | E3 |
| RF-046 | Exibir período da experiência. | E3 |
| RF-047 | Exibir responsabilidades. | E3 |
| RF-048 | Exibir descrição das atividades. | E3 |
| RF-049 | Exibir tecnologias relacionadas à experiência. | E3 |
| RF-050 | Identificar experiência atual, admitindo término vazio. | E3 |

### Formação — prioridade original: média

| ID | Comportamento a comprovar | Marco proposto |
|---|---|---|
| RF-051 | Exibir instituição de ensino. | E3 |
| RF-052 | Exibir curso. | E3 |
| RF-053 | Exibir período de formação. | E3 |
| RF-054 | Exibir situação acadêmica: em andamento, concluído ou interrompido. | E3 |
| RF-055 | Exibir informações complementares cadastradas. | E3 |

### Certificações — prioridade original: evolução

| ID | Comportamento a comprovar | Marco proposto |
|---|---|---|
| RF-056 | Listar certificações autorizadas para publicação. | E3 |
| RF-057 | Exibir instituição emissora. | E3 |
| RF-058 | Exibir data da certificação. | E3 |
| RF-059 | Disponibilizar credencial apropriada para divulgação. | E3 |
| RF-060 | Exibir certificado somente quando autorizado. | E3 |

### Contato — prioridade original: essencial

| ID | Comportamento a comprovar | Marco proposto |
|---|---|---|
| RF-061 | Exibir formulário de nome, e-mail, assunto e mensagem. | E2 |
| RF-062 | Validar campos no frontend e backend. | E2 |
| RF-063 | Enviar mensagem à API. | E2 |
| RF-064 | Persistir mensagem aceita para consulta administrativa. | E2 |
| RF-065 | Exibir confirmação somente após sucesso da operação. | E2 |
| RF-066 | Aplicar proteção antispam e limites de requisição. | E2 |
| RF-067 | Exibir alternativas de contato. | E2 |

### Autenticação administrativa — prioridade original: não rotulada

| ID | Comportamento a comprovar | Marco proposto |
|---|---|---|
| RF-068 | Autenticar a conta administrativa. | E2 |
| RF-069 | Encerrar a sessão de forma efetiva. | E2 |
| RF-070 | Proteger interface administrativa e operações no backend. | E2 |
| RF-071 | Permitir alteração segura de senha. | E2 |
| RF-072 | Limitar tentativas de login e responder de forma consistente. | E2 |
| RF-073 | Permitir recuperação segura de acesso. | Procedimento operacional no E2; fluxo pela aplicação na E5 |

### Dashboard — prioridade original: não rotulada

| ID | Comportamento a comprovar | Marco proposto |
|---|---|---|
| RF-074 | Exibir total real de projetos. | E2 |
| RF-075 | Exibir quantidade real de projetos publicados. | E2 |
| RF-076 | Exibir quantidade real de rascunhos. | E2 |
| RF-077 | Exibir mensagens recebidas ou sua contagem definida. | E2 |
| RF-078 | Exibir últimas alterações com origem e horário verificáveis. | E2 |
| RF-079 | Oferecer ações rápidas para operações existentes. | E2 |
| RF-080 | Exibir estatísticas reais de visitantes somente quando a coleta estiver habilitada. | E5 |

### Gerenciamento de projetos — prioridade original: crítica

| ID | Comportamento a comprovar | Marco proposto |
|---|---|---|
| RF-081 | Cadastrar projeto. | E2 |
| RF-082 | Editar projeto respeitando suas regras de estado. | E2 |
| RF-083 | Salvar rascunho sem exposição pública. | E2 |
| RF-084 | Publicar somente quando os requisitos mínimos forem atendidos. | E2 |
| RF-085 | Despublicar e retirar o projeto de todas as superfícies públicas. | E2 |
| RF-086 | Arquivar preservando os dados e aplicando a regra de visibilidade definida. | E2 |
| RF-087 | Excluir projeto após confirmação e tratamento de dependências. | E2 |
| RF-088 | Alterar ordem de exibição conforme escopo definido. | E2 |
| RF-089 | Definir destaque sem divulgar projetos não publicados. | E2 |
| RF-090 | Gerenciar galeria, ordem, vínculos e exclusão de imagens. | E2 |
| RF-091 | Vincular tecnologias ao projeto. | E2 |
| RF-092 | Vincular repositório GitHub ao projeto. | E2; consumo pela análise na E4 |

### Analisador — prioridade original: diferencial, sem prioridade numérica

| ID | Comportamento a comprovar | Marco proposto |
|---|---|---|
| RF-093 | Receber o diretório preparado pelo backend. | E4 |
| RF-094 | Percorrer somente arquivos permitidos. | E4 |
| RF-095 | Identificar extensões. | E4 |
| RF-096 | Identificar linguagens segundo regras explícitas. | E4 |
| RF-097 | Contabilizar arquivos analisados. | E4 |
| RF-098 | Contabilizar linhas segundo uma definição documentada. | E4 |
| RF-099 | Contabilizar linhas por linguagem. | E4 |
| RF-100 | Calcular percentuais sobre as linhas de linguagens reconhecidas. | E4 |
| RF-101 | Ignorar diretórios e arquivos de dependências. | E4 |
| RF-102 | Ignorar arquivos gerados conforme regras documentadas. | E4 |
| RF-103 | Gerar resultado JSON compatível com contrato validado. | E4 |
| RF-104 | Informar erros sem confundir diagnósticos com o resultado JSON. | E4 |
| RF-105 | Respeitar limites de quantidade, tamanho, tempo e recursos. | E4 |

**Conferência:** RF-001 a RF-105 contabilizados, sem lacunas. O agrupamento por módulos não redefine a numeração original.

## 4. Regras de negócio rastreadas

| ID | Regra da fonte | Evidência de aceite | Marco |
|---|---|---|---|
| RN-001 | Título obrigatório. | Criar ou editar com título vazio produz erro de validação. | E2 |
| RN-002 | Slug único. | Colisão é recusada, inclusive com gravações concorrentes; normalização definida. | E2 |
| RN-003 | Publicar exige título, slug, descrição curta, descrição completa, categoria e ao menos uma tecnologia. | Cada campo ausente impede publicação e identifica o problema. | E2 |
| RN-004 | Rascunho não pode ser acessado publicamente. | Listagem, detalhe, busca, relacionados e contagens não o expõem. | E1/E2 |
| RN-005 | Somente publicados aparecem em destaque. | Marcação de destaque nunca contorna o filtro de publicação. | E2 |
| RN-006 | Exclusão exige confirmação. | A interface exige confirmação inequívoca do item antes da operação. | E2 |
| RN-007 | Imagens removidas ou desvinculadas com segurança. | Arquivo compartilhado não quebra referências; exclusão respeita o armazenamento permitido. | E2 |
| RN-008 | Links opcionais vazios não geram botões sem destino. | Ausência de GitHub ou demonstração não produz ação quebrada. | E2 |
| RN-009 | Alterar slug publicado preserva redirecionamento ou exige confirmação da mudança de URL. | O comportamento escolhido é explícito e verificado na URL antiga. | E2 |
| RN-010 | API pública retorna somente conteúdo publicado. | Filtros se aplicam a endpoints, relações e recursos derivados. | Transversal |
| RN-011 | Primeira versão analisa apenas repositórios públicos do GitHub escolhidos pelo administrador. | Repositório privado ou solicitação não autenticada é rejeitado. | E4 |
| RN-012 | Validar proprietário/nome e usar endpoints oficiais, sem URLs arbitrárias de download. | Valores inválidos e destinos fora da política são recusados. | E4 |
| RN-013 | Limitar tamanho de download. | Exceder o limite interrompe a obtenção e registra a falha. | E4 |
| RN-014 | Extração bloqueia caminhos que escapem da pasta permitida. | Arquivo com caminho absoluto ou travessia de diretórios é recusado. | E4 |
| RN-015 | Ignorar links simbólicos ou impedir acesso por eles a caminhos externos. | Link não permite ler arquivos fora do snapshot. | E4 |
| RN-016 | Não executar scripts ou comandos do repositório. | Arquivos são tratados como dados; nenhuma etapa de build ou instalação do repositório é iniciada. | E4 |
| RN-017 | Limitar número de arquivos, tamanho individual e volume total. | Cada limite possui valor configurado e cenário de excesso verificado. | E4 |
| RN-018 | Processo restrito, preferencialmente isolado e sem rede. | Configuração de produção comprova restrições de usuário, filesystem e rede adotadas. | E4 |
| RN-019 | Falha da análise não compromete disponibilidade do portfólio. | Estado de erro é persistido e consultas públicas continuam funcionando. | E4 |
| RN-020 | Backend encerra processos que excedem limites. | Processo excedente e seus recursos são encerrados; trabalho recebe estado final coerente. | E4 |

**Conferência:** RN-001 a RN-020 contabilizadas, sem lacunas.

## 5. Requisitos não funcionais rastreados

| ID | Requisito | Evidência esperada | Marco |
|---|---|---|---|
| RNF-001 | HTTPS obrigatório em produção. | Site, API e configuração de proxy produzem acesso HTTPS consistente. | E2/publicação |
| RNF-002 | Hash apropriado de senhas. | Persistência não contém senha em texto puro; mecanismo de autenticação usa hash de senha adequado. | E2 |
| RNF-003 | Cookies de autenticação seguros. | Flags e duração são definidas e verificadas no ambiente de produção. | E2 |
| RNF-004 | Permissões validadas no backend. | Requisições diretas não autenticadas às operações privadas falham. | E2 |
| RNF-005 | Proteção contra CSRF quando aplicável. | Operações autenticadas por cookie exigem a proteção escolhida; teste cobre requisição indevida. | E2 |
| RNF-006 | Proteção contra XSS. | Conteúdo controlado pelo usuário não executa scripts quando renderizado. | E2 e novas superfícies |
| RNF-007 | Proteção contra SQL Injection. | Consultas parametrizadas; qualquer SQL manual é revisado. | E1 e transversal |
| RNF-008 | Limitação de requisições. | Políticas para login, contato e operações custosas; resposta de excesso definida. | E2 e E4 |
| RNF-009 | Validação de uploads. | Tipo, tamanho, conteúdo e destino são validados; arquivos indevidos são recusados. | E2/mídia |
| RNF-010 | Segredos fora do Git. | Arquivos de exemplo não contêm credenciais reais; histórico e configuração são revisados. | E0 e transversal |
| RNF-011 | Logs sem credenciais. | Senhas, cookies, tokens e dados sensíveis não aparecem nos registros. | E2 e transversal |
| RNF-012 | Backups periódicos. | Agenda e retenção documentadas; restauração de banco e mídias demonstrada. | Antes do primeiro lançamento |
| RNF-013 | Isolamento do analisador. | Processo tem acesso limitado e falhas não comprometem outros componentes. | E4 |
| RNF-014 | Tratamento seguro de erros. | Cliente recebe resposta consistente sem stack trace ou segredos; diagnóstico interno permite investigação. | E1 e transversal |

**Conferência:** RNF-001 a RNF-014 contabilizados, sem lacunas. A lista original concentra segurança; acessibilidade, desempenho, SEO e operação aparecem na narrativa e também fazem parte do escopo.

## 6. Requisitos narrativos sem identificador original

Os códigos N-xxx abaixo são identificadores **locais deste planejamento**, criados para rastrear o texto sem fingir que faziam parte do documento original. Eles complementam os RF/RN/RNF, podendo ter sobreposição deliberada.

| Código local | Exigência ou comportamento recebido | Origem | Marco proposto |
|---|---|---|---|
| N-001 | Produto individual; uma conta administrativa; sem cadastro público, multiusuário, planos, cobrança, organizações ou painel de recrutadores. | 1.2 | E0 e transversal |
| N-002 | Editar conteúdo sem mudar código ou fazer novo deploy a cada atualização. | 1.1 e 16 | E2 e transversal |
| N-003 | Stack definida, monólito modular, monorepositório e executável C++ independente. | 2 e 3 | Planejamento em E0; implementação progressiva em E1 e E4 |
| N-004 | Inspecionar o projeto existente no Visual Studio e o vínculo GitHub informado pelo usuário, identificando raiz, solução e estado do Git antes de reorganizar arquivos ou iniciar componentes. | 3 e contexto do usuário | E0; inventário localizado, validar execução separadamente |
| N-005 | Construir pastas, projetos internos, tabelas e bibliotecas conforme necessidade concreta. | 2, 3, 23 e 27 | Transversal |
| N-006 | Linha do tempo com eventos independentes no banco e ordenação. | 5 e 17 | E3 |
| N-007 | Categorias de projetos configuráveis pelo administrador. | 6.1 | E2 |
| N-008 | Detalhe inclui objetivo, problema, solução, arquitetura, desafios, aprendizados, período e demais dados listados, quando aplicáveis. | 6.2 | E2 |
| N-009 | Relacionados por tecnologias em comum; quantidade compartilhada e data são critérios simples sugeridos, sem mecanismo de IA. | 6.2 | E2 |
| N-010 | Um cadastro por tecnologia, várias associações e categorias próprias; sem inferir proficiência pela contagem de linhas ou repositórios. | 7 | E2 |
| N-011 | Experiências ordenadas pelo início decrescente; experiência atual permite término vazio. | 8 | E3 |
| N-012 | Formação com estados em andamento, concluído ou interrompido. | 9 | E3 |
| N-013 | Certificados, identificadores e arquivos adequados e autorizados para divulgação pública. | 10 | E3 |
| N-014 | Currículo dinâmico em PDF com seleção de projetos e experiências, tecnologias, formação, contato e ocultação de seções; atualização após mudanças. | 11 | E5 |
| N-015 | Currículo PDF previamente gerado é permitido na versão inicial; primeiro gerador pode ter um único layout. | 11 | E2 e E5 |
| N-016 | Contato valida nome, e-mail, assunto e mensagem nos dois lados, limita tamanho, informa finalidade e evita retenção desnecessária. | 12 | E2 |
| N-017 | Consulta de mensagens no painel é o comportamento inicial; notificação por e-mail é evolução. | 12 e 17 | E2 e E5 |
| N-018 | Conta única sem cadastro público, hash de senha e procedimento seguro de recuperação enquanto não houver fluxo na aplicação. | 13 | E2 |
| N-019 | Dashboard não apresenta números fictícios como métricas reais; analytics só aparece após implementação. | 14 | E2 e E5 |
| N-020 | Perfil editável: nome, foto, título, resumo, biografia, localização pública, disponibilidade, e-mail, GitHub, LinkedIn e outras redes. | 16 | E2 |
| N-021 | Administração de tecnologias/categorias/ícones; experiências; formação; certificações; linha do tempo; mensagens; mídia; currículo; estatísticas e configurações gerais. | 17 | Distribuído entre E2, E3 e E5 |
| N-022 | Projetos, tecnologias e perfil precedem os demais módulos administrativos. | 17 | Sequenciamento |
| N-023 | Analisador só examina arquivos: não compila nem executa código remoto. | 18.1 | E4 |
| N-024 | Suporte inicial a C++, C#, TypeScript, JavaScript, Python, HTML, CSS e SQL, nas extensões listadas; .h exige tratamento de ambiguidade C/C++. | 18.2 | E4 |
| N-025 | Snapshot identificável por commit, com data e SHA persistidos para contextualizar o resultado. | 19 | E4 |
| N-026 | Backend obtém, valida e extrai snapshot; C++ recebe somente diretório preparado. | 19 e 21 | E4 |
| N-027 | Processo devolve JSON; backend valida parâmetros e saída; diagnósticos separados; processo não recebe credenciais GitHub. | 20 | E4 |
| N-028 | Percentuais usam linhas reconhecidas como denominador; nenhuma linguagem reconhecida gera distribuição vazia. | 20 | E4 |
| N-029 | Temporários removidos ao concluir ou falhar; erros não derrubam a API. | 20 | E4 |
| N-030 | Exibir, quando disponível, data, commit e quantidade de arquivos ignorados; linhas não representam qualidade ou produtividade. | 22 | E4 |
| N-031 | Modelo PostgreSQL com EF Core, chaves, índice único de slug, vínculos de mídia, estado controlado e timestamps obrigatórios. | 23 e 24 | E1 e evolução |
| N-032 | Armazenar em UTC os valores que representem instantes. | 24 | E1 e transversal |
| N-033 | Relações N:N projeto/tecnologia e experiência/tecnologia; relações 1:N para imagens, funcionalidades e análises; estatísticas por análise. | 23, 25 e 26 | E2, E3 e E4 |
| N-034 | Histórico de análises ligado ao projeto, com possibilidade de retenção limitada; consistência entre JSON validado e banco. | 25 e 26 | E4 |
| N-035 | Camadas API, Application, Domain e Infrastructure com responsabilidades descritas, evitando abstrações desnecessárias. | 27 | E1 e transversal |
| N-036 | API REST versionada, endpoints públicos sem dados privados e endpoints administrativos autenticados. | 28 a 31 | E1 e cada módulo |
| N-037 | Endpoints públicos para perfil, projetos, tecnologias, experiências, formação, certificações, linha do tempo, redes, análise e currículo; POST de contato. | 28 | Marco de cada módulo |
| N-038 | Login, logout, consulta da sessão e alteração de senha; endpoints adicionais de recuperação quando implementada. | 29 | E2 e E5 |
| N-039 | Rotas administrativas para dashboard, projetos, perfil, tecnologias, mídia, mensagens e configurações; equivalentes para outros cadastros. | 30 | Marco de cada módulo |
| N-040 | Solicitar análise retorna identificador/status inicial e HTTP 202; histórico e resultado consultáveis; requisição não permanece aberta até a conclusão. | 31 e 32 | E4 |
| N-041 | Processamento em segundo plano com persistência e recuperação adequada após reinício. | 31 | E4 |
| N-042 | Códigos HTTP adequados e formato consistente de erros, preferencialmente Problem Details, sem detalhes internos expostos. | 32 | E1 e transversal |
| N-043 | Descrições ricas e Markdown convertidos ou sanitizados antes da renderização. | 33 | Quando habilitados |
| N-044 | Interface responsiva em celular, tablet e computador; teclado, contraste, textos alternativos, labels e erros acessíveis. | 34 | E2 e cada interface |
| N-045 | Estados de carregamento, ausência de dados, feedback de operações; temas claro/escuro e respeito a movimento reduzido. | 34 | E2 e cada interface |
| N-046 | Identidade visual proposta: Codefy., “Build. Create. Evolve.”, minimalismo, tons escuros e azul. | 34 | Proposta visual do E2 |
| N-047 | Título, descrição, URL amigável, Open Graph, sitemap, robots.txt, dados estruturados apropriados e páginas indexáveis. | 35 | E2 |
| N-048 | Escolher renderização que exponha o conteúdo aos mecanismos de busca: pré-renderização, geração estática ou servidor são alternativas, não decisões finais. | 35 | Antes de estruturar frontend público |
| N-049 | Metas Lighthouse de 90 ou mais em Performance, Accessibility e SEO; validar na produção; otimizar imagens e carregar recursos pesados sob demanda. | 35 | E2 e publicação |
| N-050 | Quando implementado, registrar visualizações de portfólio/projetos, cliques externos, downloads de currículo e páginas mais acessadas. | 36, trecho disponível | E5 |

As tabelas sugeridas na fonte incluem também logs de integração GitHub, auditoria, configurações de currículo e eventos de analytics. São pistas para a modelagem dos comportamentos correspondentes, não autorização para criar tabelas antecipadamente sem uso definido. O fragmento final da seção 36 não especifica uma exigência adicional verificável.

## 7. Ambiguidades e propostas provisórias de resolução

Cada proposta abaixo deverá ser revista quando sua etapa começar. “Recomendação” não significa decisão já tomada pelo usuário.

| Tema | Problema concreto | Proposta provisória | Decidir antes de |
|---|---|---|---|
| Projetos arquivados | O texto admite “visibilidade controlada”, mas RN-010 só permite publicados na API pública. | Tratar arquivado como preservado e privado; documentar transições de restauração. Visibilidade pública excepcional exigiria revisão explícita da regra. | Modelar estados de projeto |
| Dois significados de status | O estado editorial é rascunho/publicado/arquivado; a página também pode querer mostrar andamento/concluído. Há apenas um campo status sugerido. | Separar estado editorial de situação de desenvolvimento se os dois conceitos forem necessários; não mostrar o estado editorial como andamento. | Modelo e formulário do projeto |
| Edição de publicado | É possível remover um campo obrigatório durante a edição e deixar um publicado inválido. | Validar RN-003 também ao salvar um publicado; bloqueio com explicação ou despublicação explícita. | Casos de uso de edição |
| Tecnologia não publicada | RN-010/RF-043 proíbem exposição, mas projetos publicados exigem pelo menos uma tecnologia. | Definir se publicação exige uma tecnologia publicável e impedir alterações que tornem o projeto inconsistente; filtrar todas as relações públicas. | Modelar tecnologias/publicação |
| Publicação em outros módulos | O documento usa “conteúdo publicado”, mas não descreve estado de visibilidade para todas as entidades. | Identificar quais entidades têm publicação própria e quais herdam do proprietário; manter projeções públicas explícitas. | Contratos de cada módulo |
| Slug e URL antiga | RN-009 admite duas soluções e não define normalização, reserva ou reuso. | Preferir redirecionamento permanente com histórico de slugs, regras de colisão e prevenção de ciclos; confirmar o custo diante da alternativa de confirmação. | API de edição e SEO |
| Datas e reordenação | RF-026 pede ordem por data e RF-088 pede ordem manual, sem precedência. | Definir filtros com ordem explícita e desempate estável; separar ordem editorial de destacados da lista por data, se adequado. | Contrato de listagem |
| Publicação novamente | published_at não define primeira publicação versus republicação. | Documentar se a data é preservada ou renovada; manter created_at/updated_at com semânticas independentes. | Transições de estado |
| “Informações completas” | Objetivo aparece no detalhe, mas não consta no esquema ilustrativo; vários campos não têm obrigatoriedade ou limites. | Dicionário de dados por campo: finalidade, tipo, obrigatoriedade, limites e exposição; adicionar objetivo somente após confirmar sua separação da descrição. | Primeira migration de conteúdo |
| Filtros e paginação | Não há regra de combinação, acentos/maiúsculas, tamanho de página ou busca vazia. | Definir contrato único e exemplos de consultas combinadas, ordenação estável e página sem resultados. | Endpoint GET /projects |
| Destaques e relacionadas | Quantidade máxima, ausência de relacionados e autoinclusão não foram definidos. | Excluir o próprio projeto, filtrar publicados, ordenar deterministamente e ocultar a seção quando vazia; definir limite. | E2 |
| Exclusão de categorias/tecnologias | Há CRUD, mas não se define o comportamento quando existem vínculos. | Bloquear exclusão utilizada e permitir reassociação explícita; evitar cascata que apague projetos. | CRUD de referências |
| Exclusão e mídia compartilhada | Uma mídia pode estar no perfil, na capa, na galeria ou no currículo. | Modelar referências, validar tipo e tamanho, impedir remoção usada ou pedir desvinculação; definir política para arquivos órfãos. | Upload e galeria |
| Arquivos privados | Certificados autorizados e mídia genérica podem usar o mesmo armazenamento. | Distinguir permissão de divulgação do arquivo e vínculo público; não presumir que toda URL de mídia é pública. | Armazenamento de mídia |
| Login e hospedagem | Cookies seguros são exigidos, mas domínio, origem, duração e renovação não estão definidos. | Preferir implantação que facilite mesma origem para web/API; escolher mecanismo de cookie e proteção CSRF com suas regras documentadas. | Autenticação |
| Conta única | Não há fluxo de criação inicial nem regra de recuperação operacional. | Provisionamento restrito sem endpoint de cadastro público; procedimento de recuperação, troca de senha e encerramento de sessões revisado. | Primeiro acesso administrativo |
| Recuperação de senha | Fluxo automático pode depender de entrega de e-mail, serviço ainda não definido. | Entregar procedimento seguro no E2 e planejar canal verificado, expiração e uso único para a recuperação na aplicação. | E2 e E5 |
| “Últimas alterações” | Dashboard requer alterações recentes, mas não define auditoria nem dados registrados. | Registrar operação, entidade, identificador e horário, evitando credenciais e conteúdo sensível; definir retenção. | Dashboard |
| SEO e atualização imediata | Uma SPA só no cliente não garante o comportamento de indexação desejado; geração estática pode exigir reconstrução. | Avaliar renderização no servidor ou cache/pré-renderização com invalidação; comprovar atualização sem deploy manual e HTML compartilhável. | Escolher estrutura do frontend |
| Cache após despublicar | Uma resposta pública pode persistir em cache mesmo quando o banco mudou. | Definir invalidação para detalhe, listagem, sitemap, relacionados e metadados; documentar limites do cache externo. | Cache e primeira publicação |
| Descrições ricas | Há menção a Markdown, mas editor e subset de sintaxe não foram escolhidos. | Começar com formato explícito; habilitar Markdown somente com renderização/sanitização e imagens/links controlados. | Campos de texto público |
| Contato e privacidade | “Tempo necessário” e “proteção antispam” não especificam política ou limites. | Definir finalidade apresentada, prazo de retenção, rotina de exclusão e limites proporcionais; adotar barreiras adicionais conforme necessidade real. | Formulário público |
| Semântica de linhas | “Linhas” pode significar linhas físicas, linhas não vazias ou código sem comentários. | Inicialmente contar linhas físicas segundo regra documentada, incluindo comportamento de arquivo vazio e última linha sem quebra; não chamar a métrica de qualidade. | Contrato do analisador |
| Arquivos e linguagens | Extensões sozinhas não distinguem sempre linguagens; binários, codificação, links e exclusões não têm critérios completos. | Lista permitida, tratamento explícito de .h, arquivos desconhecidos/binários e exclusões versionadas, com contagem de ignorados e motivos. | Percurso C++ |
| Total versus percentuais | totalLines não declara se inclui arquivos desconhecidos; arredondamento pode não somar 100. | Definir totais e denominador de forma consistente, arredondamento para exibição e validação com tolerância documentada. | Contrato JSON |
| Publicação de análise | API promete “última análise publicada”, mas tabelas só sugerem status de execução. | Separar conclusão de aprovação para exibição, ou selecionar explicitamente uma análise pública; SHA/data visíveis e regra para projeto despublicado. | Modelo de análise |
| Contrato do executável | O JSON ilustrativo não traz versão, erros, ignorados ou códigos de saída. | Versionar contrato; stdout com resultado, stderr com diagnóstico, códigos de saída e limites de saída definidos. | Integração C#/C++ |
| Fila e reinício | BackgroundService sozinho não demonstra persistência nem recuperação do trabalho. | Registrar trabalhos no banco e definir estados, reserva, expiração e retomada; impedir processamento duplicado incompatível. | Execução em segundo plano |
| Falhas e repetição | Não há política de cancelamento, tentativa, timeout, concorrência ou reanálise. | Distinguir erros permanentes/transitórios, limitar tentativas e concorrência e definir se o mesmo commit pode produzir nova execução. | Orquestração de análises |
| Download e arquivos compactados | Limite do download não protege sozinho contra expansão enorme na extração. | Limitar tamanho baixado, descompactado, arquivo e quantidade; validar entradas e destinos antes de gravar. | Obtenção de snapshot |
| Limites de processo | “Limite de recursos” não especifica CPU, memória, duração ou aplicação na hospedagem escolhida. | Definir valores e mecanismo de contenção no ambiente real, encerramento da árvore de processos e limpeza recuperável. | Seleção da hospedagem do analisador |
| GitHub | API, credenciais opcionais, quota e falhas de sincronização não foram detalhadas. | Backend usa endpoints oficiais, trata limite/indisponibilidade e mantém credenciais fora do processo C++; registrar sincronizações úteis. | Integração externa |
| Currículo dinâmico | Seleção de experiências/ocultação de seções não está totalmente refletida nas tabelas sugeridas. | Modelar configurações e seleções pela necessidade do gerador, com prévia e regra de atualização; PDF estático mantém versão/data identificáveis. | E5 |
| Métricas de visitantes | Escopo está truncado; coleta, retenção, consentimento e precisão não foram definidos. | Não ativar coleta implicitamente; completar especificação antes da E5 e exibir somente dados efetivamente coletados. | Analytics |
| Performance | Metas Lighthouse não indicam páginas, dispositivo, dados ou protocolo de medição. | Definir amostra de páginas e condições de medição, registrar resultados reais e tratar regressões relevantes. | Primeira validação em produção |
| Operação | Backups são exigidos, mas frequência, perda tolerada, retenção e restauração não foram estabelecidas. | Definir objetivos compatíveis com o uso pessoal e testar restauração de banco, mídias e configuração necessária. | Primeiro lançamento |

## 8. Lacunas entre telas, tabelas e endpoints

As listas de banco e API são uma direção inicial. Antes de cada implementação, verificar se o contrato cobre o fluxo inteiro:

- Cadastro de categorias de projeto e tecnologia, consulta administrativa de tecnologias, gestão de funcionalidades de projeto e ordenação de galerias não têm todas as rotas detalhadas.
- Gerenciamento de mídias menciona upload, seleção e exclusão, mas a lista de endpoints só explicita upload.
- Perfil e redes sociais precisam de leitura administrativa para edição; o documento explicita atualização do perfil e leitura pública de redes, mas não todo o gerenciamento.
- Formação, experiências, certificações, linha do tempo e currículo requerem contratos administrativos completos nas etapas correspondentes.
- “Últimas alterações” exige uma origem verificável; a tabela audit_logs é proposta, sem campos ou política definidos.
- O detalhamento de análises precisa representar fila, transições, recuperação após reinício e regra de publicação além do JSON das métricas.
- URLs antigas de projetos precisam de persistência adicional se for escolhida a opção de redirecionamento.
- Contagens do wireframe de tecnologias e experiências são ilustrativas; RF-010 exige somente o contador de projetos. Outros contadores precisam de regra se forem incluídos no layout final.
- O prefixo das rotas de autenticação e do analisador deve ficar explícito no contrato: as tabelas usam caminhos relativos, enquanto as seções pública e administrativa indicam prefixos.

Essas lacunas serão resolvidas por contratos e migrations da funcionalidade em desenvolvimento, não por criação antecipada de todos os recursos.

## 9. Critérios de aceite que guiam as entregas

### AC-01 — Primeira fatia de projetos

Dado um projeto publicado e outro em rascunho no PostgreSQL, a listagem pública retorna somente o publicado, seu detalhe abre por slug e uma consulta direta ao slug do rascunho não revela seus dados. A interface exibe resposta real da API, além de carregamento, ausência e erro. Relaciona RF-019, RF-021, RF-028, RN-004 e RN-010.

### AC-02 — Publicação e manutenção do estado

Um projeto incompleto não pode ser publicado. Uma edição de publicado não pode violar silenciosamente os requisitos de publicação. Despublicar ou arquivar remove o conteúdo das superfícies públicas e invalida caches sob controle da aplicação conforme a política definida. Relaciona RF-082 a RF-086, RN-003 a RN-005 e RN-010.

### AC-03 — Gestão real de conteúdo

O administrador altera perfil, tecnologias e um projeto; a mudança chega à interface pública sem edição de código nem deploy manual. Rascunhos permanecem privados, os links ausentes não geram botões quebrados e a mudança de slug aplica a regra escolhida. Relaciona RF-001 a RF-043, RF-081 a RF-092, RN-008, RN-009 e N-002.

### AC-04 — Autenticação administrativa

Sem sessão válida, chamar diretamente a API administrativa não permite ler mensagens nem alterar conteúdo. Login inválido sofre limitação, logout encerra o acesso, troca de senha aplica a regra definida de sessões e há procedimento de recuperação testável sem credenciais expostas. Relaciona RF-068 a RF-073 e RNF-002 a RNF-005, RNF-008, RNF-010 e RNF-011.

### AC-05 — Busca, filtros e paginação

Categoria, tecnologia e título respeitam as regras combinadas e não incluem conteúdo privado. Ordenação estável evita mudanças arbitrárias entre páginas; parâmetros inválidos recebem erro consistente e uma consulta sem resultados tem estado vazio. Relaciona RF-023 a RF-027 e RN-010.

### AC-06 — Mídias e conteúdo rico

Upload inválido é recusado; imagem válida pode ser selecionada e ordenada. A remoção não quebra vínculos existentes de forma silenciosa. Conteúdo de texto não executa script ao ser apresentado. Relaciona RF-002, RF-020, RF-030, RF-090, RN-007, RNF-006 e RNF-009.

### AC-07 — Contato

Mensagem válida é persistida e consultável somente no painel. Dados inválidos ou acima dos limites são rejeitados no backend mesmo sem o formulário; falha não gera confirmação falsa. O visitante conhece a finalidade, e a rotina de retenção/exclusão definida é demonstrável. Relaciona RF-061 a RF-067, RF-077 e N-016/N-017.

### AC-08 — Site publicável

As páginas essenciais funcionam com teclado e em tamanhos de tela acordados, com labels, erros e contraste verificados. Tema e movimento reduzido respeitam a especificação. O HTML e os metadados atendem à estratégia de SEO escolhida; o sitemap contém apenas conteúdo público. Registrar medições reais das metas Lighthouse, sem declarar aprovação antecipadamente. Relaciona N-044 a N-049.

### AC-09 — Analisador independente

Um conjunto pequeno de arquivos com resultado conhecido comprova arquivos, linhas, linguagens, exclusões e percentuais; diretório sem linguagem reconhecida produz distribuição vazia. Arquivos ambíguos obedecem à regra publicada. Erros e excesso de limites têm resultados verificáveis. Relaciona RF-093 a RF-105 e N-024/N-028.

### AC-10 — Integração segura da análise

Solicitação autenticada retorna 202 e identificador. O processamento usa snapshot identificado por commit, bloqueia extração fora da pasta e execução de código, respeita limites, valida o JSON e mantém histórico. Reinício do servidor não perde silenciosamente o trabalho. Falha mantém o portfólio disponível e a exposição pública respeita a regra escolhida. Relaciona RF-037, RN-011 a RN-020, RNF-013 e N-025 a N-041 aplicáveis.

### AC-11 — Entrega e recuperação

Uma instalação a partir do repositório documentado consegue configurar o ambiente sem segredos versionados, aplicar migrations e iniciar os componentes pertinentes à versão. HTTPS e logs são verificados no ambiente publicado. Um backup de banco e mídias é restaurado em ambiente de validação e os vínculos continuam corretos. Relaciona RNF-001, RNF-010 a RNF-012 e RNF-014.

### AC-12 — Evoluções sem dados inventados

Certificações respeitam divulgação; currículo dinâmico respeita as seleções; métricas só são exibidas após coleta real habilitada; notificações e recuperação usam os fluxos definidos. Funcionalidades adiadas aparecem como pendentes no planejamento, sem números demonstrativos apresentados como dados reais. Relaciona RF-056 a RF-060, RF-073, RF-080 e N-014/N-019/N-050.

## 10. Como usar esta análise no trabalho conjunto

Para cada pequena entrega, selecionar os IDs envolvidos, esclarecer somente as decisões necessárias, escrever os critérios de aceite e implementar a menor parte coerente. Em seguida, revisar o código, executar as verificações relevantes e registrar o que foi aprendido, o que foi entregue e o que continua pendente.

Atualizar a rastreabilidade com estados como planejado, em implementação, verificado e entregue, sempre apontando a evidência correspondente. Uma lista de arquivos criados não comprova, por si, que um requisito foi atendido. Mudanças de escopo e decisões técnicas adicionais precisam ficar explícitas para o usuário, preservando a possibilidade de aprender e participar das escolhas.

**Cobertura documental desta análise:** 105 requisitos funcionais, 20 regras de negócio, 14 requisitos não funcionais e 50 entradas locais para requisitos narrativos. A continuação ausente da seção 36 continua pendente de recebimento e análise.
