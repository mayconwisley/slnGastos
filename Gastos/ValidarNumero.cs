using System.Globalization;
using System.Linq;

namespace Gastos;

public sealed class ValidarNumero
{
    private static readonly CultureInfo Cultura = CultureInfo.GetCultureInfo("pt-BR");

    public string Validar(string valor)
    {
        var caracteres = valor.Where(caractere => char.IsDigit(caractere) || caractere is ',' or '.');
        var resultado = new string(caracteres.ToArray()).Replace('.', ',');
        var indiceSeparador = resultado.IndexOf(',');
        return indiceSeparador < 0
            ? resultado
            : resultado[..(indiceSeparador + 1)] + resultado[(indiceSeparador + 1)..].Replace(",", string.Empty);
    }

    public string Formatar(string valor) =>
        decimal.TryParse(valor, NumberStyles.Number, Cultura, out var numero)
            ? numero.ToString("#,##0.00", Cultura)
            : "0,00";

    public string Zero(string valor) => string.IsNullOrWhiteSpace(valor) ? "0,00" : valor;

    public string ValidarNumeroInteiro(string valor) => new(valor.Where(char.IsDigit).ToArray());

    public string ZeroInteiro(string valor) => string.IsNullOrWhiteSpace(valor) ? "1" : valor;

    public string FormatarInteiro(string valor) =>
        int.TryParse(valor, NumberStyles.Integer, Cultura, out var numero) && numero > 0
            ? numero.ToString(Cultura)
            : "1";
}
