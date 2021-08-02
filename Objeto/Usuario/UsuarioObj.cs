using System;

namespace Objeto.Usuario
{
    public class UsuarioObj
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Chave { get; set; }
        public string Senha { get; set; }
        public string Lembrete { get; set; }
        public string Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
