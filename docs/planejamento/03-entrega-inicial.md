# Primeira entrega — planejamento e preparação do repositório

## O que este incremento entrega

Um roteiro completo, rastreável aos requisitos, com diagnóstico do projeto existente e preparação mínima para começar a desenvolver em etapas. Não representa uma implementação do portfólio ou do analisador.

Projeto identificado: `C:\Users\Infortronic\Documents\work\Codefy`. O console C++20 existente imprime `Hello World!`; a solução e seus fontes serão preservados nesta etapa.

## Alteração local aplicada

Os nove arquivos abaixo foram aplicados e conferidos no repositório existente após a concessão de acesso à pasta. `Codefy.cpp`, `Codefy.slnx`, `Codefy.vcxproj`, `Codefy.vcxproj.filters` e `.gitattributes` mantiveram seus hashes originais. O Git identifica somente o complemento ao `.gitignore` e os novos arquivos de documentação e formatação. Nenhum commit, push ou deploy foi realizado.

| Arquivo | Finalidade |
|---|---|
| `README.md` na raiz do repositório | Apresentar Codefy, estado real e links para o roteiro |
| `docs/requirements/especificacao-original-v2.txt` | Preservar a fonte recebida |
| `docs/planejamento/00-plano-mestre.md` | Sequência completa, dependências, pré-código, implementação, pós-código e critérios de conclusão |
| `docs/planejamento/01-analise-requisitos.md` | Inventário, ambiguidades e critérios de aceite |
| `docs/planejamento/02-ambiente-e-primeiro-passo.md` | Evidências locais e limitações da verificação |
| `docs/planejamento/03-entrega-inicial.md` | Explicar este incremento e seu próximo passo |
| `docs/architecture/decisoes-iniciais.md` | Registrar decisões herdadas e propostas fundamentadas |
| `.editorconfig` | Definir convenções iniciais de formatação para os próximos arquivos |
| Complemento ao `.gitignore` existente | Cobrir configurações locais e artefatos futuros de frontend/CMake, preservando as regras atuais |

Não são necessários novos pacotes, credenciais, migrations ou serviços para este incremento. Seu efeito principal é tornar o trabalho seguinte compreensível e revisável.

## Validação desta entrega

**Resultados:** cobertura dos 105 RF, 20 RN e 14 RNF conferida, links locais válidos, diff sem erros de whitespace e fontes/configuração originais preservados. Compilação direta do fonte e execução retornaram código 0, com saída `Hello World!`; a verificação da solução pelo MSBuild permanece limitada pelo FileTracker, conforme diagnóstico.

- Verificar que todos os links locais dos documentos apontam para arquivos existentes.
- Confirmar cobertura dos 105 RF, 20 RN e 14 RNF do anexo, sem perder requisitos narrativos.
- Revisar coerência entre entregas E0–E5 e os marcos do plano mestre.
- Conferir que o código C++ e os arquivos de solução/projeto mantêm o conteúdo original.
- Inspecionar o diff final para confirmar que somente os arquivos planejados foram adicionados ou alterados.
- Registrar separadamente o resultado do build e as restrições deste ambiente.

## Como aprender com esta etapa

O arquivo `.slnx` organiza os projetos abertos no Visual Studio. O `.vcxproj` configura a compilação de um projeto C++. O `Codefy.cpp` contém o código executado. O repositório Git guarda o histórico dos arquivos versionados; o remoto aponta para a cópia hospedada no GitHub. Essas responsabilidades são diferentes e serão mantidas claras ao adicionar o backend.

## Próximo incremento: primeira API executável

**Antes:** explicar requisição HTTP, endpoint, API e por que o backend C# terá um projeto próprio. Verificar a decisão de usar o SDK .NET disponível e a organização da solução.

**Durante:** criar `backend/Codefy.Api`, executar localmente e disponibilizar uma rota mínima de saúde. Adicionar somente a estrutura necessária a esse comportamento.

**Depois:** verificar o código de resposta, explicar o ciclo de uma requisição, documentar execução e revisar o diff. Uma rota de saúde do processo não comprova conexão ao PostgreSQL; a verificação do banco virá com a persistência.

**Critério de aceite:** conseguir iniciar e consultar a API local de forma reproduzível, enquanto o projeto C++ continua preservado.

O código desse próximo incremento ainda não foi criado nesta entrega. O modo de participação do proprietário — escrever com orientação ou acompanhar implementação explicada — determinará como distribuiremos as tarefas práticas.
