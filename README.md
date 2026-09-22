# Codefy

Portfólio profissional individual com site público, administração de conteúdo e análise de repositórios GitHub.

## Estado atual

O repositório começou com uma solução Visual Studio e um projeto de console C++20 que imprime `Hello World!`. O planejamento do sistema está documentado. A API ASP.NET Core, o frontend React e a persistência PostgreSQL serão implementados em etapas; ainda não estão disponíveis nesta base.

## Roteiro de desenvolvimento

1. [Plano mestre e sequência de entregas](docs/planejamento/00-plano-mestre.md)
2. [Requisitos, ambiguidades e critérios de aceite](docs/planejamento/01-analise-requisitos.md)
3. [Ambiente e diagnóstico do projeto](docs/planejamento/02-ambiente-e-primeiro-passo.md)
4. [Primeira entrega e próximo incremento](docs/planejamento/03-entrega-inicial.md)
5. [Decisões e propostas de arquitetura](docs/architecture/decisoes-iniciais.md)
6. [Especificação original recebida](docs/requirements/especificacao-original-v2.txt)

## Tecnologias previstas

React e TypeScript para a interface; ASP.NET Core e C# para a API; PostgreSQL e Entity Framework Core para persistência; C++ e CMake para o analisador. As versões e bibliotecas serão registradas conforme adotadas.

## Projeto atual

Abra `Codefy.slnx` no Visual Studio com as ferramentas de desenvolvimento C++. Selecione Debug/x64 e execute sem depuração com Ctrl+F5. O programa inicial deve imprimir `Hello World!`.

O diagnóstico registra os testes realizados nesta sessão e a restrição encontrada ao tentar compilar a solução pelo MSBuild do ambiente de execução. Isso não substitui a confirmação da execução pelo Visual Studio.

## Método

Cada incremento começa com comportamento esperado e termina com execução, revisão, documentação e preparação de um commit coerente. O objetivo é que o proprietário compreenda e consiga manter cada parte do sistema.

Não coloque senhas, tokens, strings de conexão privadas ou arquivos de ambiente reais no Git. Use os mecanismos de configuração local definidos para cada componente quando ele for criado.
