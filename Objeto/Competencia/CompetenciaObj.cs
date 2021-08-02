using Objeto.Cliente;
using System;

namespace Objeto.Competencia
{
    public class CompetenciaObj
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Ativo { get; set; }
        public ClienteObj Cliente { get; set; }

    }
}
