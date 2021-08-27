using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Dto
{
    /// <summary>
    /// DTO da classe AlunoDTO
    /// </summary>
    public class AlunoDto
    {
        /// <summary>
        /// Id do Aluno
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Matricula do ALuno
        /// </summary>
        public int Matricula { get; set; }

        /// <summary>
        /// Nome do Aluno
        /// </summary>
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
        public DateTime DataIni { get; set; }
        public bool Ativo { get; set; }
    }
}
