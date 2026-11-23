using System;
using LojaEletronicos.Algoritmos;
using LojaEletronicos.Estruturas;
using LojaEletronicos.Modelos;
using LojaEletronicos.Servicos;

namespace LojaEletronicos.Interface;

public class Menu
{
    private readonly Loja loja;

    public Menu(Loja loja)
    {
        this.loja = loja;
    }

    public void Executar()
    {
        while (true)
        {
            Tela.Cabecalho("LOJA DE ELETRÔNICOS - MENU PRINCIPAL");
            Console.WriteLine("1 - Listar produtos");
            Console.WriteLine("2 - Cadastrar produto");
            Console.WriteLine("3 - Remover produto");
            Console.WriteLine("4 - Ordenar produtos (preço ou nome)");
            Console.WriteLine("5 - Buscar produto (código ou nome)");
            Console.WriteLine("6 - Selecionar produtos (preço ou estoque)");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();

            int opcao = Tela.LerInteiro("Escolha uma opção: ", 0, 6);
            if (opcao == 0)
            {
                Console.WriteLine("Sistema encerrado.");
                return;
            }

            switch (opcao)
            {
                case 1: Listar(); break;
                case 2: Cadastrar(); break;
                case 3: Remover(); break;
                case 4: Ordenar(); break;
                case 5: Buscar(); break;
                case 6: Selecionar(); break;
            }

            Tela.Pausar();
        }
    }

    private void Listar()
    {
        Tela.Cabecalho("PRODUTOS CADASTRADOS (ordem de código)");
        Tela.ExibirTabela(loja.Produtos);
    }

    private void Cadastrar()
    {
        Tela.Cabecalho("CADASTRAR PRODUTO");
        string nome = Tela.LerTexto("Nome: ");
        string categoria = Tela.LerTexto("Categoria: ");
        string marca = Tela.LerTexto("Marca: ");
        decimal preco = Tela.LerDecimal("Preço (ex.: 1299,90): ", 0.01m);
        int estoque = Tela.LerInteiro("Quantidade em estoque: ", 0, 100000);

        Produto produto = loja.Cadastrar(nome, categoria, marca, preco, estoque);
        Console.WriteLine();
        Console.WriteLine($"Produto cadastrado com o código {produto.Codigo}.");
    }

    private void Remover()
    {
        Tela.Cabecalho("REMOVER PRODUTO");
        int codigo = Tela.LerInteiro("Código do produto: ", 0, int.MaxValue);
        Produto removido = loja.Remover(codigo);

        Console.WriteLine();
        if (removido == null)
        {
            Console.WriteLine("Nenhum produto encontrado com esse código.");
        }
        else
        {
            Console.WriteLine($"Produto \"{removido.Nome}\" removido.");
        }
    }

    private void Ordenar()
    {
        Tela.Cabecalho("ORDENAR PRODUTOS");
        int parametro = Tela.LerOpcao("Ordenar por", "Preço", "Nome");
        int ordem = Tela.LerOpcao("Ordem", "Crescente", "Decrescente");
        int algoritmo = Tela.LerOpcao("Algoritmo", "Merge Sort", "Selection Sort");

        Comparison<Produto> comparador = Comparadores.PorPreco;
        string nomeParametro = "PREÇO";
        if (parametro == 2)
        {
            comparador = Comparadores.PorNome;
            nomeParametro = "NOME";
        }

        string nomeOrdem = "CRESCENTE";
        if (ordem == 2)
        {
            comparador = Comparadores.Inverter(comparador);
            nomeOrdem = "DECRESCENTE";
        }

        Produto[] vetor = loja.Produtos.CopiarParaVetor();
        int comparacoes;
        string nomeAlgoritmo;
        if (algoritmo == 1)
        {
            comparacoes = Ordenacao.MergeSort(vetor, comparador);
            nomeAlgoritmo = "Merge Sort";
        }
        else
        {
            comparacoes = Ordenacao.SelectionSort(vetor, comparador);
            nomeAlgoritmo = "Selection Sort";
        }

        Tela.Cabecalho($"PRODUTOS ORDENADOS POR {nomeParametro} ({nomeOrdem})");
        Tela.ExibirTabela(vetor);
        Console.WriteLine($"Algoritmo: {nomeAlgoritmo} | Comparações realizadas: {comparacoes}");
    }

    private void Buscar()
    {
        Tela.Cabecalho("BUSCAR PRODUTO");
        int parametro = Tela.LerOpcao("Buscar por", "Código (busca binária)", "Nome (busca sequencial)");

        if (parametro == 1)
        {
            int codigo = Tela.LerInteiro("Código: ", 0, int.MaxValue);
            int indice = Busca.BinariaPorCodigo(loja.Produtos, codigo, out int comparacoes);

            Console.WriteLine();
            if (indice < 0)
            {
                Console.WriteLine("Produto não encontrado.");
            }
            else
            {
                Tela.ExibirTabela(new Produto[] { loja.Produtos.Obter(indice) });
            }
            Console.WriteLine($"Busca binária | Comparações realizadas: {comparacoes}");
        }
        else
        {
            string termo = Tela.LerTexto("Nome (ou parte do nome): ");
            ListaProdutos encontrados = Busca.SequencialPorNome(loja.Produtos, termo, out int comparacoes);

            Console.WriteLine();
            Tela.ExibirTabela(encontrados);
            Console.WriteLine($"Busca sequencial | Comparações realizadas: {comparacoes}");
        }
    }

    private void Selecionar()
    {
        Tela.Cabecalho("SELECIONAR PRODUTOS (QUICKSELECT)");
        int total = loja.Produtos.Tamanho;
        if (total == 0)
        {
            Console.WriteLine("Não há produtos cadastrados.");
            return;
        }

        int criterio = Tela.LerOpcao("Selecionar",
            "Os K mais baratos (preço)",
            "Os K mais caros (preço)",
            "Os K com menor estoque (reposição)");
        int k = Tela.LerInteiro($"Quantos produtos (K, de 1 a {total}): ", 1, total);

        Comparison<Produto> comparador = Comparadores.PorPreco;
        string titulo = $"OS {k} PRODUTOS MAIS BARATOS";
        if (criterio == 2)
        {
            comparador = Comparadores.Inverter(Comparadores.PorPreco);
            titulo = $"OS {k} PRODUTOS MAIS CAROS";
        }
        else if (criterio == 3)
        {
            comparador = Comparadores.PorEstoque;
            titulo = $"OS {k} PRODUTOS COM MENOR ESTOQUE";
        }

        Produto[] selecionados = Selecao.KPrimeiros(loja.Produtos, k, comparador);

        Tela.Cabecalho(titulo);
        Tela.ExibirTabela(selecionados);
        Console.WriteLine($"{k}º selecionado: {selecionados[k - 1].Nome}");
    }
}
