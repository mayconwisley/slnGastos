using Objeto.Devedores;
using Objeto.Usuario;
using System;

namespace Objeto.MovimentoDevedores
{
    public class MovimentoDevedoresObj
    {

        public int Id { get; set; }
        public DateTime DataMovimento { get; set; }
        public DevedoresObj Devedores { get; set; }
        public DateTime DataParcela { get; set; }
        public int Parcela { get; set; }
        public decimal Valor { get; set; }
        public string Pago { get; set; }
        public UsuarioObj Usuario { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataPagameno { get; set; }
    }
}
