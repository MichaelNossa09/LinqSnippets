using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    public class Chapter
    {
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; } = new Curso();
        public string List { get; set; } = string.Empty;
    }
}
