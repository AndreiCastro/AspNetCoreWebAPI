using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
        public Professor() { }

        public Professor(int id, string nome)
        {
            this.Id = id;
            this.Nome = Nome;
        }
    }
}
