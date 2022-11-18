using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    public class Curso
    {
        public string Name { get; set; } = string.Empty;
        public string DescriptionSmall { get; set; } = string.Empty;
        public string DescriptionLarge { get; set; } = string.Empty;
        public string PublicObject { get; set; } = string.Empty;
        public string Objects { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;
        public Nivel Nivel { get; set; } = Nivel.Básico;
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public Chapter Chapter { get; set; } = new Chapter();
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
    public enum Nivel
    {
        Básico,
        Intermedio,
        Avanazado
    }
}
