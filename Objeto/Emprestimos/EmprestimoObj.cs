using Objeto.Cliente;
using Objeto.Usuario;
using System;

namespace Objeto.Emprestimos;

public class EmprestimoObj
{
    public int Id { get; set; }
    public DateTime DataInicio { get; set; }
    public string Descricao { get; set; }
    public decimal ValorEmprestado { get; set; }
    public decimal ValorParcela { get; set; }
    public int Parcelas { get; set; }
    public string Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
    public UsuarioObj Usuario { get; set; }
    public ClienteObj Cliente { get; set; }
}
