using System;
using LojaEletronicos.Modelos;

namespace LojaEletronicos.Algoritmos;

// Os métodos ordenam o vetor recebido e devolvem o número de comparações feitas.
public static class Ordenacao
{
    public static int MergeSort(Produto[] vetor, Comparison<Produto> comparar)
    {
        if (vetor.Length < 2)
        {
            return 0;
        }

        Produto[] auxiliar = new Produto[vetor.Length];
        return MergeSortRecursivo(vetor, auxiliar, 0, vetor.Length - 1, comparar);
    }

    private static int MergeSortRecursivo(Produto[] vetor, Produto[] auxiliar,
        int inicio, int fim, Comparison<Produto> comparar)
    {
        if (inicio >= fim)
        {
            return 0;
        }

        int meio = inicio + (fim - inicio) / 2;
        int comparacoes = MergeSortRecursivo(vetor, auxiliar, inicio, meio, comparar);
        comparacoes += MergeSortRecursivo(vetor, auxiliar, meio + 1, fim, comparar);
        comparacoes += Intercalar(vetor, auxiliar, inicio, meio, fim, comparar);
        return comparacoes;
    }

    private static int Intercalar(Produto[] vetor, Produto[] auxiliar,
        int inicio, int meio, int fim, Comparison<Produto> comparar)
    {
        for (int k = inicio; k <= fim; k++)
        {
            auxiliar[k] = vetor[k];
        }

        int i = inicio;
        int j = meio + 1;
        int comparacoes = 0;

        for (int k = inicio; k <= fim; k++)
        {
            if (i > meio)
            {
                vetor[k] = auxiliar[j++];
            }
            else if (j > fim)
            {
                vetor[k] = auxiliar[i++];
            }
            else
            {
                comparacoes++;
                if (comparar(auxiliar[j], auxiliar[i]) < 0)
                {
                    vetor[k] = auxiliar[j++];
                }
                else
                {
                    vetor[k] = auxiliar[i++];
                }
            }
        }

        return comparacoes;
    }

    public static int SelectionSort(Produto[] vetor, Comparison<Produto> comparar)
    {
        int comparacoes = 0;

        for (int i = 0; i < vetor.Length - 1; i++)
        {
            int menor = i;
            for (int j = i + 1; j < vetor.Length; j++)
            {
                comparacoes++;
                if (comparar(vetor[j], vetor[menor]) < 0)
                {
                    menor = j;
                }
            }

            if (menor != i)
            {
                Trocar(vetor, i, menor);
            }
        }

        return comparacoes;
    }

    public static void Trocar(Produto[] vetor, int a, int b)
    {
        Produto temporario = vetor[a];
        vetor[a] = vetor[b];
        vetor[b] = temporario;
    }
}
