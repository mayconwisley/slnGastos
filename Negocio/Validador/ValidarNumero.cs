using System;

namespace Negocio.Validador
{
    public class ValidarNumero
    {
        string strValor = string.Empty;
        int posicao = 0;

        public string Validar(string valor)
        {
            try
            {
                foreach (char x in valor)
                {
                    posicao = "1234567890,.".IndexOf(x);
                    if (posicao >= 0)
                    {
                        if (x == Convert.ToChar(","))
                        {
                            if (strValor.IndexOf(",") < 0)
                            {
                                strValor = strValor + x;
                            }
                        }
                        else
                        {
                            strValor = strValor + x;
                        }
                    }
                }
                return strValor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Formatar(string valor)
        {
            decimal formatar = decimal.Parse(valor);
            strValor = formatar.ToString("#,##0.00");
            if (strValor == "0,00")
            {
                strValor = "0,00";
            }
            return strValor;
        }

        public string Zero(string valor)
        {
            strValor = valor;
            if (valor == "")
            {
                strValor = "0,00";
            }
            return strValor;
        }

        public string ValidarNumeroInteiro(string valor)
        {
            try
            {
                foreach (char x in valor)
                {
                    posicao = "1234567890".IndexOf(x);
                    if (posicao >= 0)
                    {
                        strValor = strValor + x;
                    }
                }
                return strValor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ZeroInteiro(string valor)
        {
            strValor = valor;
            if (valor == "")
            {
                strValor = "1";
            }
            return strValor;
        }

        public string FormatarInteiro(string valor)
        {
            decimal formatar = decimal.Parse(valor);
            strValor = formatar.ToString("0");
            if (strValor == "0")
            {
                strValor = "1";
            }
            return strValor;
        }
    }
}
