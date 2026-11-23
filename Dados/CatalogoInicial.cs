using LojaEletronicos.Servicos;

namespace LojaEletronicos.Dados;

public static class CatalogoInicial
{
    public static void Carregar(Loja loja)
    {
        loja.Cadastrar("Smartphone Galaxy A55 128GB", "Celulares", "Samsung", 2199.00m, 14);
        loja.Cadastrar("iPhone 15 128GB", "Celulares", "Apple", 5299.00m, 6);
        loja.Cadastrar("Notebook IdeaPad Slim 3 i5", "Notebooks", "Lenovo", 3499.90m, 8);
        loja.Cadastrar("Notebook Aspire 5 Ryzen 7", "Notebooks", "Acer", 3999.00m, 5);
        loja.Cadastrar("Smart TV 4K 55 polegadas", "TVs", "LG", 2899.00m, 7);
        loja.Cadastrar("Fone Bluetooth Tune 520BT", "Áudio", "JBL", 249.90m, 30);
        loja.Cadastrar("Caixa de Som Flip 6", "Áudio", "JBL", 699.00m, 12);
        loja.Cadastrar("Mouse Sem Fio M170", "Periféricos", "Logitech", 69.90m, 45);
        loja.Cadastrar("Teclado Mecânico K552", "Periféricos", "Redragon", 229.90m, 20);
        loja.Cadastrar("Monitor 24 pol Full HD IPS", "Monitores", "AOC", 749.00m, 9);
        loja.Cadastrar("Console PlayStation 5 Slim", "Games", "Sony", 3799.00m, 4);
        loja.Cadastrar("Controle DualSense", "Games", "Sony", 449.00m, 16);
        loja.Cadastrar("Smartwatch Galaxy Watch6", "Vestíveis", "Samsung", 1299.00m, 10);
        loja.Cadastrar("Tablet Galaxy Tab A9", "Tablets", "Samsung", 1099.00m, 11);
        loja.Cadastrar("SSD NVMe 1TB", "Armazenamento", "Kingston", 399.90m, 25);
        loja.Cadastrar("Carregador Turbo USB-C 25W", "Acessórios", "Samsung", 89.90m, 3);
        loja.Cadastrar("Roteador Wi-Fi 6 AX1500", "Redes", "TP-Link", 399.00m, 2);
        loja.Cadastrar("Webcam Full HD C920", "Periféricos", "Logitech", 379.90m, 1);
        loja.Cadastrar("Echo Dot 5ª geração", "Casa Inteligente", "Amazon", 399.00m, 13);
        loja.Cadastrar("Kindle 11ª geração", "Leitores", "Amazon", 549.00m, 8);
    }
}
