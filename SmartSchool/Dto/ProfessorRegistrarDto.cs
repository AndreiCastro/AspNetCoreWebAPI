using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Dto
{
    public class ProfessorRegistrarDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public int Registro { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
    }
}
