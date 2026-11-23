using System;
using System.Text;
using LojaEletronicos.Dados;
using LojaEletronicos.Interface;
using LojaEletronicos.Servicos;

namespace LojaEletronicos;

public static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Loja loja = new Loja();
        CatalogoInicial.Carregar(loja);

        Menu menu = new Menu(loja);
        menu.Executar();
    }
}
