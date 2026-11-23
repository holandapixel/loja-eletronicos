namespace LojaEletronicos.Modelos;

public class Produto
{
    public int Codigo { get; }
    public string Nome { get; }
    public string Categoria { get; }
    public string Marca { get; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }

    public Produto(int codigo, string nome, string categoria, string marca, decimal preco, int estoque)
    {
        Codigo = codigo;
        Nome = nome;
        Categoria = categoria;
        Marca = marca;
        Preco = preco;
        Estoque = estoque;
    }
}
