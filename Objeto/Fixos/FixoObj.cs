using Objeto.Cliente;
using Objeto.Usuario;
using System;

namespace Objeto.Fixos
{
    public class FixoObj
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataFim { get; set; }
        public string Ativo { get; set; }
        public string Integrar { get; set; }
        public UsuarioObj Usuario { get; set; }
        public ClienteObj Cliente { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
