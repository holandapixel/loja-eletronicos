using System;
using LojaEletronicos.Estruturas;
using LojaEletronicos.Modelos;

namespace LojaEletronicos.Algoritmos;

public static class Selecao
{
    // Quickselect: coloca na posição k o elemento que estaria ali se o vetor fosse ordenado.
    // Tudo antes de k fica menor ou igual a ele, sem ordenar o vetor inteiro.
    public static Produto KEsimo(Produto[] vetor, int k, Comparison<Produto> comparar)
    {
        if (k < 0 || k >= vetor.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(k));
        }

        int inicio = 0;
        int fim = vetor.Length - 1;

        while (inicio < fim)
        {
            int posicaoPivo = Particionar(vetor, inicio, fim, comparar);

            if (posicaoPivo == k)
            {
                return vetor[k];
            }

            if (k < posicaoPivo)
            {
                fim = posicaoPivo - 1;
            }
            else
            {
                inicio = posicaoPivo + 1;
            }
        }

        return vetor[k];
    }

    // Seleciona os K primeiros segundo o comparador e devolve só eles, já ordenados.
    public static Produto[] KPrimeiros(ListaProdutos lista, int k, Comparison<Produto> comparar)
    {
        Produto[] vetor = lista.CopiarParaVetor();
        k = Math.Min(k, vetor.Length);

        if (k <= 0)
        {
            return new Produto[0];
        }

        KEsimo(vetor, k - 1, comparar);

        Produto[] selecionados = new Produto[k];
        for (int i = 0; i < k; i++)
        {
            selecionados[i] = vetor[i];
        }

        Ordenacao.MergeSort(selecionados, comparar);
        return selecionados;
    }

    private static int Particionar(Produto[] vetor, int inicio, int fim, Comparison<Produto> comparar)
    {
        int meio = inicio + (fim - inicio) / 2;
        Ordenacao.Trocar(vetor, meio, fim);
        Produto pivo = vetor[fim];

        int limite = inicio;
        for (int j = inicio; j < fim; j++)
        {
            if (comparar(vetor[j], pivo) < 0)
            {
                Ordenacao.Trocar(vetor, limite, j);
                limite++;
            }
        }

        Ordenacao.Trocar(vetor, limite, fim);
        return limite;
    }
}
