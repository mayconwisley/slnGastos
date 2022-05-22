using AcessarSistema.Login;
using Objeto.Usuario;

namespace TestGastos.AcessarSistema
{
    public class Test
    {

        UsuarioObj usuarioObj;

        [SetUp]
        public void Setup()
        {
            usuarioObj = new UsuarioObj();
        }

        [Test]
        public void Login()
        {
            usuarioObj.Login = "wisley";
            usuarioObj.Senha = "153426";
            Assert.IsTrue(Logar.Acessar(usuarioObj));
        }
        
        [Test]
        public void LoginComSenhaErrada()
        {
            usuarioObj.Login = "wisley";
            usuarioObj.Senha = "123456";
            Assert.IsFalse(Logar.Acessar(usuarioObj));
        }
        [Test]
        public void LoginComUsuarioErrado()
        {
            usuarioObj.Login = "jtests";
            usuarioObj.Senha = "153426";
            Assert.IsFalse(Logar.Acessar(usuarioObj));
        }

    }
}
