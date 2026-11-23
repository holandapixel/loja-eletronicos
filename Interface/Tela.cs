using System;
using System.Globalization;
using LojaEletronicos.Estruturas;
using LojaEletronicos.Modelos;
using LojaEletronicos.Util;

namespace LojaEletronicos.Interface;

// Funções de entrada e saída no console, separadas da lógica do menu.
public static class Tela
{
    private const int LarguraLinha = 95;

    public static void Cabecalho(string titulo)
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }

        Console.WriteLine(new string('=', LarguraLinha));
        Console.WriteLine("  " + titulo);
        Console.WriteLine(new string('=', LarguraLinha));
    }

    public static void ExibirTabela(ListaProdutos lista)
    {
        ExibirTabela(lista.CopiarParaVetor());
    }

    public static void ExibirTabela(Produto[] produtos)
    {
        if (produtos.Length == 0)
        {
            Console.WriteLine("Nenhum produto para exibir.");
            return;
        }

        Console.WriteLine(Linha("Código", "Nome", "Categoria", "Marca", "Preço", "Estoque"));
        Console.WriteLine(new string('-', LarguraLinha));

        foreach (Produto p in produtos)
        {
            Console.WriteLine(Linha(p.Codigo.ToString(), p.Nome, p.Categoria, p.Marca,
                Texto.FormatarPreco(p.Preco), p.Estoque.ToString()));
        }

        Console.WriteLine(new string('-', LarguraLinha));
        Console.WriteLine($"{produtos.Length} produto(s) exibido(s).");
    }

    public static int LerOpcao(string pergunta, params string[] opcoes)
    {
        Console.WriteLine();
        Console.WriteLine(pergunta + ":");
        for (int i = 0; i < opcoes.Length; i++)
        {
            Console.WriteLine($"  {i + 1} - {opcoes[i]}");
        }
        return LerInteiro("Opção: ", 1, opcoes.Length);
    }

    public static int LerInteiro(string rotulo, int minimo, int maximo)
    {
        while (true)
        {
            Console.Write(rotulo);
            if (int.TryParse(LerLinha(), out int valor) && valor >= minimo && valor <= maximo)
            {
                return valor;
            }
            Console.WriteLine($"Entrada inválida. Digite um número entre {minimo} e {maximo}.");
        }
    }

    public static decimal LerDecimal(string rotulo, decimal minimo)
    {
        while (true)
        {
            Console.Write(rotulo);
            string entrada = LerLinha().Replace("R$", "").Trim();

            if (entrada.Contains(","))
            {
                entrada = entrada.Replace(".", "").Replace(",", ".");
            }

            if (decimal.TryParse(entrada, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal valor)
                && valor >= minimo)
            {
                return valor;
            }
            Console.WriteLine($"Valor inválido. Digite um valor a partir de {Texto.FormatarPreco(minimo)}.");
        }
    }

    public static string LerTexto(string rotulo)
    {
        while (true)
        {
            Console.Write(rotulo);
            string texto = LerLinha();
            if (texto.Length > 0)
            {
                return texto;
            }
            Console.WriteLine("O campo não pode ficar vazio.");
        }
    }

    public static void Pausar()
    {
        Console.WriteLine();
        Console.Write("Pressione ENTER para voltar ao menu...");
        LerLinha();
    }

    private static string LerLinha()
    {
        string linha = Console.ReadLine();
        if (linha == null)
        {
            Environment.Exit(0);
        }
        return linha.Trim();
    }

    private static string Linha(string codigo, string nome, string categoria,
        string marca, string preco, string estoque)
    {
        return Texto.Ajustar(codigo, 6) + " | "
             + Texto.Ajustar(nome, 30) + " | "
             + Texto.Ajustar(categoria, 16) + " | "
             + Texto.Ajustar(marca, 9) + " | "
             + preco.PadLeft(12) + " | "
             + estoque.PadLeft(7);
    }
}
