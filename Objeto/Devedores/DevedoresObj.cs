using Objeto.Cliente;
using Objeto.Usuario;
using System;

namespace Objeto.Devedores
{
    public class DevedoresObj
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }
        public string Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public UsuarioObj Usuario { get; set; }
        public ClienteObj Cliente { get; set; }
    }
}
