using Objeto.Usuario;
using System;

namespace Objeto.Cliente
{
    public class ClienteObj
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public UsuarioObj Usuario { get; set; }

    }
}
