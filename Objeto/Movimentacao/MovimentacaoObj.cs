using Objeto.Cliente;
using Objeto.Usuario;
using System;

namespace Objeto.Movimentacao
{
    public class MovimentacaoObj
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public char TipoLancamento { get; set; }
        public char TipoMonetario { get; set; }
        public char TipoPagoRecebido { get; set; }
        public UsuarioObj Usuario { get; set; }
        public ClienteObj Cliente { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
