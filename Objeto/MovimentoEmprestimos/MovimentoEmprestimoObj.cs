using Objeto.Emprestimos;
using Objeto.Usuario;
using System;

namespace Objeto.MovimentoEmprestimos
{
    public class MovimentoEmprestimoObj
    {
        public int Id { get; set; }
        public EmprestimoObj Emprestimo { get; set; }
        public DateTime DataParcela { get; set; }
        public int Parcela { get; set; }
        public decimal Valor { get; set; }
        public string Pago { get; set; }
        public UsuarioObj Usuario { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataPagameno { get; set; }

    }
}
