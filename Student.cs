using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Grade { get; set; } = 0;
        public int Age { get; set; }
        public bool IsCertified { get; set; }
        public ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    }
}
