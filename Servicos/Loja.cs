using LojaEletronicos.Algoritmos;
using LojaEletronicos.Estruturas;
using LojaEletronicos.Modelos;

namespace LojaEletronicos.Servicos;

public class Loja
{
    private int proximoCodigo = 1001;

    // Os códigos são crescentes, então a lista fica sempre ordenada por código.
    public ListaProdutos Produtos { get; } = new ListaProdutos();

    public Produto Cadastrar(string nome, string categoria, string marca, decimal preco, int estoque)
    {
        Produto produto = new Produto(proximoCodigo, nome, categoria, marca, preco, estoque);
        proximoCodigo++;
        Produtos.Adicionar(produto);
        return produto;
    }

    public Produto Remover(int codigo)
    {
        int indice = Busca.BinariaPorCodigo(Produtos, codigo, out _);
        if (indice < 0)
        {
            return null;
        }
        return Produtos.RemoverEm(indice);
    }
}
