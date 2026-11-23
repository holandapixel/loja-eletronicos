using System;
using LojaEletronicos.Modelos;

namespace LojaEletronicos.Estruturas;

// Lista linear sequencial: os produtos ficam em posições contíguas de um vetor.
public class ListaProdutos
{
    private Produto[] itens;

    public int Tamanho { get; private set; }

    public ListaProdutos(int capacidadeInicial = 8)
    {
        itens = new Produto[Math.Max(1, capacidadeInicial)];
        Tamanho = 0;
    }

    public Produto Obter(int indice)
    {
        ValidarIndice(indice);
        return itens[indice];
    }

    public void Adicionar(Produto produto)
    {
        if (Tamanho == itens.Length)
        {
            Redimensionar();
        }

        itens[Tamanho] = produto;
        Tamanho++;
    }

    public Produto RemoverEm(int indice)
    {
        ValidarIndice(indice);
        Produto removido = itens[indice];

        for (int i = indice; i < Tamanho - 1; i++)
        {
            itens[i] = itens[i + 1];
        }

        Tamanho--;
        itens[Tamanho] = null;
        return removido;
    }

    public Produto[] CopiarParaVetor()
    {
        Produto[] copia = new Produto[Tamanho];
        for (int i = 0; i < Tamanho; i++)
        {
            copia[i] = itens[i];
        }
        return copia;
    }

    private void Redimensionar()
    {
        Produto[] maior = new Produto[itens.Length * 2];
        for (int i = 0; i < Tamanho; i++)
        {
            maior[i] = itens[i];
        }
        itens = maior;
    }

    private void ValidarIndice(int indice)
    {
        if (indice < 0 || indice >= Tamanho)
        {
            throw new ArgumentOutOfRangeException(nameof(indice));
        }
    }
}
