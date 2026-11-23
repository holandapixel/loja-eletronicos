using System.Globalization;
using System.Text;

namespace LojaEletronicos.Util;

public static class Texto
{
    private const string ComAcento = "áàâãäéèêëíìîïóòôõöúùûüç";
    private const string SemAcento = "aaaaaeeeeiiiiooooouuuuc";

    private static readonly NumberFormatInfo FormatoReal = new NumberFormatInfo
    {
        NumberDecimalSeparator = ",",
        NumberGroupSeparator = "."
    };

    // Deixa o texto em minúsculas e sem acentos para comparar "Câmera" com "camera".
    public static string Normalizar(string texto)
    {
        string minusculo = texto.Trim().ToLowerInvariant();
        StringBuilder resultado = new StringBuilder(minusculo.Length);

        foreach (char c in minusculo)
        {
            int posicao = ComAcento.IndexOf(c);
            resultado.Append(posicao >= 0 ? SemAcento[posicao] : c);
        }

        return resultado.ToString();
    }

    public static string FormatarPreco(decimal valor)
    {
        return "R$ " + valor.ToString("N2", FormatoReal);
    }

    public static string Ajustar(string texto, int largura)
    {
        if (texto.Length > largura)
        {
            return texto.Substring(0, largura - 3) + "...";
        }
        return texto.PadRight(largura);
    }
}
