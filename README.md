# Loja de Eletrônicos — Algoritmos de Ordenação, Busca e Seleção em C#

Sistema de console em C# que gerencia o catálogo de uma loja de eletrônicos usando uma **estrutura de dados linear** (lista sequencial sobre vetor). Sobre essa lista são aplicados algoritmos de **ordenação**, **busca** e **seleção**, cada um com **dois parâmetros**.

Trabalho da disciplina de Algoritmos e Estruturas de Dados II — Faculdade UniSapiens, Porto Velho/RO, 2026.
Professora: Rosângela Cunha.

## Integrantes

- Tiago Schleder
- Luis Eduardo
- Otavio Martins

## Algoritmos e parâmetros

| Categoria  | Algoritmo                  | Parâmetro 1 | Parâmetro 2 | Complexidade |
|------------|----------------------------|-------------|-------------|--------------|
| Ordenação  | Merge Sort                 | Preço       | Nome        | O(n log n)   |
| Ordenação  | Selection Sort             | Preço       | Nome        | O(n²)        |
| Busca      | Busca binária              | Código      | —           | O(log n)     |
| Busca      | Busca sequencial (linear)  | —           | Nome        | O(n)         |
| Seleção    | Quickselect (K primeiros)  | Preço       | Estoque     | O(n) em média |

- A ordenação aceita ordem crescente ou decrescente e mostra quantas comparações o algoritmo fez.
- A busca binária funciona porque a lista é mantida sempre em ordem de código (os códigos são gerados em sequência).
- A busca por nome ignora maiúsculas e acentos (`camera` encontra `Câmera`).
- A seleção mostra os K produtos mais baratos, os K mais caros ou os K com menor estoque (para reposição), sem ordenar a lista inteira.

## Estrutura do projeto

```
LojaEletronicos/
├── Program.cs                  Ponto de entrada
├── LojaEletronicos.csproj
├── Modelos/Produto.cs          Entidade Produto
├── Estruturas/ListaProdutos.cs Lista linear sequencial (vetor com crescimento dinâmico)
├── Algoritmos/
│   ├── Comparadores.cs         Parâmetros de comparação (preço, nome, estoque)
│   ├── Ordenacao.cs            Merge Sort e Selection Sort
│   ├── Busca.cs                Busca binária e busca sequencial
│   └── Selecao.cs              Quickselect e seleção dos K primeiros
├── Servicos/Loja.cs            Cadastro e remoção de produtos
├── Dados/CatalogoInicial.cs    20 produtos de exemplo
├── Interface/
│   ├── Menu.cs                 Menu principal e fluxos
│   └── Tela.cs                 Leitura de dados e impressão de tabelas
└── docs/                       Relatório em PDF e prints de execução
```

## Como executar

Pré-requisito: [.NET SDK 8](https://dotnet.microsoft.com/download) ou mais recente.

```bash
git clone <url-do-repositorio>
cd LojaEletronicos
dotnet run
```

No Visual Studio, abra o arquivo `LojaEletronicos.csproj` e pressione F5.

## Menu

```
1 - Listar produtos
2 - Cadastrar produto
3 - Remover produto
4 - Ordenar produtos (preço ou nome)
5 - Buscar produto (código ou nome)
6 - Selecionar produtos (preço ou estoque)
0 - Sair
```

## Prints de execução

As capturas de tela estão na pasta [`docs/prints`](docs/prints) e no relatório em PDF, na pasta [`docs`](docs).
