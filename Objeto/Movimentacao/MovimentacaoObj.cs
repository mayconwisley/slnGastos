using Objeto.Cliente;
using Objeto.Competencia;
using Objeto.Usuario;
using System;

namespace Objeto.Movimentacao
{
    public class MovimentacaoObj
    {
        public int Id { get; set; }
        public DateTime DataMovimento { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string TipoLancamento { get; set; }
        public string TipoMonetario { get; set; }
        public string TipoPagoRecebido { get; set; }
        public string Integracao { get; set; }
        public CompetenciaObj Competencia { get; set; }
        public UsuarioObj Usuario { get; set; }
        public ClienteObj Cliente { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
