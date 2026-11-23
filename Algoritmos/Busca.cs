using LojaEletronicos.Estruturas;
using LojaEletronicos.Modelos;
using LojaEletronicos.Util;

namespace LojaEletronicos.Algoritmos;

public static class Busca
{
    // Exige a lista ordenada por código (a Loja garante isso ao cadastrar).
    public static int BinariaPorCodigo(ListaProdutos lista, int codigo, out int comparacoes)
    {
        int inicio = 0;
        int fim = lista.Tamanho - 1;
        comparacoes = 0;

        while (inicio <= fim)
        {
            int meio = inicio + (fim - inicio) / 2;
            int codigoDoMeio = lista.Obter(meio).Codigo;
            comparacoes++;

            if (codigoDoMeio == codigo)
            {
                return meio;
            }

            if (codigoDoMeio < codigo)
            {
                inicio = meio + 1;
            }
            else
            {
                fim = meio - 1;
            }
        }

        return -1;
    }

    // Percorre a lista inteira e devolve todos os produtos cujo nome contém o termo.
    public static ListaProdutos SequencialPorNome(ListaProdutos lista, string termo, out int comparacoes)
    {
        string alvo = Texto.Normalizar(termo);
        ListaProdutos encontrados = new ListaProdutos();
        comparacoes = 0;

        for (int i = 0; i < lista.Tamanho; i++)
        {
            Produto produto = lista.Obter(i);
            comparacoes++;

            if (Texto.Normalizar(produto.Nome).Contains(alvo))
            {
                encontrados.Adicionar(produto);
            }
        }

        return encontrados;
    }
}
