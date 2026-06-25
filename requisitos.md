Contexto do sistema existente

Você recebeu um programa console (base) cuja finalidade é gerar um arquivo texto (.txt) a partir de dados contidos em um arquivo JSON local. Não há banco de dados; todos os dados são lidos de um arquivo .json previamente configurado. Atualmente este gerador produz linhas em um leiaute que contém três tipos de linha: 00 (Empresa), 01 (Documento) e 02 (Itens do Documento).

*Se houver alguma dificuldade para obter o projeto existência e/ou os arquivos “.json” que representam as bases de dados para execução do sistema, entre em contato conosco.

 

Leiaute 1 (atual – já existente):

00|CNPJEMPRESA|NOMEEMPRESA|TELEFONE

01|MODELODOCUMENTO|NUMERODOCUMENTO|VALORDOCUMENTO

02|DESCRICAOITEM|VALORITEM

Observações do Leiaute 1:

• Tipo 00 (Empresa): exatamente 1 linha por empresa.

- CNPJ empresa (string): CNPJ da empresa.

- Nome empresa (string): Razão social ou nome fantasia.

- Telefone (string): Telefone de contato.

• Tipo 01 (Documento): N linhas (0..N) por empresa.

- Modelo do documento (string): Ex.: NF, NFS, CTRC.

- Número do documento (string): Identificador único no contexto da empresa.

- Valor do documento (decimal): Soma dos itens

• Tipo 02 (Item do Documento): N linhas (0..N) por documento.

- Descrição do item (string).

- Valor do item (decimal).

O objetivo desta avaliação é evoluir o programa prevendo a existência de múltiplos leiautes.

 

Leiaute 2 (inexistente / a criar):

Diferenças em relação ao Leiaute 1:

• Linha 02 ganha novo campo “número do item”.

• Surge a linha 03 (categoria do item), com 0..N categorias por item.

Leiaute 2 (proposto):

00|CNPJEMPRESA|NOMEEMPRESA|TELEFONE

01|MODELODOCUMENTO|NUMERODOCUMENTO|VALORDOCUMENTO

02|NUMEROITEM|DESCRICAOITEM|VALORITEM

03|NUMEROCATEGORIA|DESCRICAOCATEGORIA

 

Sobre a base de dados (JSON):

Para fins de teste, o arquivo .json conterá 20 empresas; cada empresa terá 10 documentos; cada documento terá entre 5 e 10 itens. O programa deverá ler esse arquivo e gerar o arquivo .txt conforme o leiaute.

Os arquivos de dados estão localizados no diretório:

Projeto_ToDo\AvaliacaoDotnet\ConsoleApp1\data

Os arquivos de saída (gerados pelo Sistema) devem ser alocados no diretório:

Projeto_ToDo\AvaliacaoDotnet\ConsoleApp1\out

 

Integração com a Console (classe MainConsole):

O programa oferece um menu para o usuário:

    Configurar arquivo .json (base de dados): solicita e salva o caminho do arquivo.

    Configurar diretório de output: solicita e salva a pasta onde os .txt serão gerados.

    Gerar arquivo: solicita o número do leiaute (versão) e gera o .txt informando o caminho final.

*Espera-se que candidato incremente a solution deste projeto conforme necessário.

 

Avaliação – início

1) Evolução do engenho gerador de arquivo.

O sistema atual gera o Leiaute versão 01. Precisamos suportar um novo leiaute (versão 02) sem alterar a saída do Leiaute 01.

Leiaute 1 (já existente):

00|CNPJEMPRESA|NOMEEMPRESA|TELEFONE

01|MODELODOCUMENTO|NUMERODOCUMENTO|VALORDOCUMENTO

02|DESCRICAOITEM|VALORITEM

Leiaute 2 (a criar):

00|CNPJEMPRESA|NOMEEMPRESA|TELEFONE

01|MODELODOCUMENTO|NUMERODOCUMENTO|VALORDOCUMENTO

02|NUMEROITEM|DESCRICAOITEM|VALORITEM

03|NUMEROCATEGORIA|DESCRICAOCATEGORIA

a) Revição e refatoração do código-fonte e do projeto.

    Analise a solução entregue, considerando aspectos de organização, estrutura de classes, segregação por camada/domínio, namespaces, manutenibilidade e boas práticas de desenvolvimento em C# e se necessário, implemente/refatore o código/projeto já existente de forma a considerer a separação de responsabilidades, a reutilização de código e a evolução futura do Sistema.

b) Evoluir o engenho para contemplar a geração do leiaute versão 02, sem afetar o leiaute versão 01.

c) Alterar a console para que, ao selecionar o item de menu 3 (Gerar arquivo), o sistema pergunte ao usuário, qual é o número da versão de leiaute a ser gerado (inteiro).

d) Antes de gerar o arquivo, implementar uma nova validação para garantir que a soma do valor dos itens de cada documento gerado correspondam ao valor do respectivo documento.

e) Implementar um novo tipo de linha (09), que exibirão a quantidade total de linhas de cada tipo de linha (válido para todas as versões de laitue), exemplos:

    09|00|QUANTIDADE_LINHAS_DO_TIPO_00

    09|01|QUANTIDADE_LINHAS_DO_TIPO_01

    09|02|QUANTIDADE_LINHAS_DO_TIPO_02

    09|03|QUANTIDADE_LINHAS_DO_TIPO_03

f) Implementar um novo tinha de linha (99), que exibirá a quantidade total de linhas do arquivo. Exemplo:

    99|QUANTIDADE_LINHAS_NO_ARQUIVO

g) Implementar teste unitário (utilizar NUnit).

 

Observação importante:

- Serão avaliadas as decisões e a forma utilizada pelo candidato para implementar cada requisito.

- O candidato terá que apresentar/defender a solução final implementada.
