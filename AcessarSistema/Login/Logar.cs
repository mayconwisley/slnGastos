using Criptografia;
using Objeto.Usuario;
using System;

namespace AcessarSistema.Login
{
    public static class Logar
    {
        static string strSenha = string.Empty, strChave = string.Empty, strSenhaDescriptografada;
        public static bool Acessar(UsuarioObj usuario)
        {
            try
            {
                strChave = BuscarChave.Chave(usuario);
                strSenha = BuscarSenha.Senha(usuario);

                strSenhaDescriptografada = Descriptografar.DescriptografarSenha(strChave, strSenha);

                if (usuario.Senha == strSenhaDescriptografada)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
