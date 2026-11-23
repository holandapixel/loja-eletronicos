using System;
using LojaEletronicos.Modelos;
using LojaEletronicos.Util;

namespace LojaEletronicos.Algoritmos;

// Cada comparador define um parâmetro (critério) usado pelos algoritmos.
public static class Comparadores
{
    public static int PorPreco(Produto a, Produto b)
    {
        return a.Preco.CompareTo(b.Preco);
    }

    public static int PorNome(Produto a, Produto b)
    {
        return string.CompareOrdinal(Texto.Normalizar(a.Nome),
                                     Texto.Normalizar(b.Nome));
    }

    public static int PorEstoque(Produto a, Produto b)
    {
        return a.Estoque.CompareTo(b.Estoque);
    }

    public static Comparison<Produto> Inverter(Comparison<Produto> comparador)
    {
        return (a, b) => comparador(b, a);
    }
}
