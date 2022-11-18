using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    public class Services
    {

        static public void SearchUserByEmail()
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Name="Michael",
                    LastName="Nossa",
                    Email="MichaelNossaB@gmail.com",
                    Password="123456789"
                },
                new User()
                {
                    Id=2,
                    Name="Joaquin",
                    LastName="Daniel",
                    Email="JDaniel@gmail.com",
                    Password="123456789"
                },               
                new User()
                {
                    Id=3,
                    Name="Gareth",
                    LastName="Lolo",
                    Email="GLolo@gmail.com",
                    Password="123456789"
                }
            };
            var usersByEmail = from user in users
                               where user.Email == "MichaelNossaB@gmail.com"
                               select user;
        }
        static public void SearchStudentAdult()
        {
             List<Student> students = new List<Student>()
             {
                new Student
                {
                    Id = 1,
                    Name = "Michael",
                    Grade = 90,
                    Age = 20,
                    IsCertified = true,
                    Cursos = new List<Curso>(){
                        new Curso()
                        {
                            Name = "Álgebra",
                            DescriptionSmall = "Curso matemático",
                            DescriptionLarge = "Curso matematico completo de algebra",
                            PublicObject = "Ingenieros",
                            Objects = "Esclarecer las bases y fundamentos de la algebra",
                            Requirements = "Ninguno",
                            Nivel = Nivel.Intermedio,
                            Categories = new List<Category>()
                            {
                                new Category()
                                {
                                    Id=1,
                                    Name="Matemáticas"
                                }
                            },
                            Students = new List<Student>()
                            {
                                new Student()
                                {
                                    Id = 2,
                                    Name = "Juan",
                                    Grade = 80,
                                    Age = 15,
                                    IsCertified = false,
                                },
                                new Student()
                                {
                                    Id = 3,
                                    Name = "David",
                                    Grade = 95,
                                    Age = 18,
                                    IsCertified = true,
                                }
                            }
                        }
                    }
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 80,
                    Age = 15,
                    IsCertified = false,
                },
                new Student
                {
                    Id = 3,
                    Name = "David",
                    Grade = 95,
                    Age = 18,
                    IsCertified = true,
                },
                new Student
                {
                    Id = 4,
                    Name = "Gabi",
                    Grade = 50,
                    Age = 21,
                    IsCertified = true,
                },
                new Student
                {
                    Id = 5,
                    Name = "Jorge",
                    Grade = 80,
                    Age = 16,
                    IsCertified = false,
                }
            };

            var studentsAdult = from student in students
                                where student.Age >= 18
                                select student;

        }

        static public void SearchStudentWithOneOrMoreCourses()
        {
            List<Student> students = new List<Student>()
             {
                new Student
                {
                    Id = 1,
                    Name = "Michael",
                    Grade = 90,
                    Age = 20,
                    IsCertified = true,
                    Cursos = new List<Curso>(){
                        new Curso()
                        {
                            Name = "Álgebra",
                            DescriptionSmall = "Curso matemático",
                            DescriptionLarge = "Curso matematico completo de algebra",
                            PublicObject = "Ingenieros",
                            Objects = "Esclarecer las bases y fundamentos de la algebra",
                            Requirements = "Ninguno",
                            Nivel = Nivel.Intermedio,
                            Categories = new List<Category>()
                            {
                                new Category()
                                {
                                    Id=1,
                                    Name="Matemáticas"
                                }
                            },
                            Students = new List<Student>()
                            {
                                new Student()
                                {
                                    Id = 2,
                                    Name = "Juan",
                                    Grade = 80,
                                    Age = 15,
                                    IsCertified = false,
                                },
                                new Student()
                                {
                                    Id = 3,
                                    Name = "David",
                                    Grade = 95,
                                    Age = 18,
                                    IsCertified = true,
                                }
                            }
                        }
                    }
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 80,
                    Age = 15,
                    IsCertified = false,
                },
                new Student
                {
                    Id = 3,
                    Name = "David",
                    Grade = 95,
                    Age = 18,
                    IsCertified = true,
                },
                new Student
                {
                    Id = 4,
                    Name = "Gabi",
                    Grade = 50,
                    Age = 21,
                    IsCertified = true,
                },
                new Student
                {
                    Id = 5,
                    Name = "Jorge",
                    Grade = 80,
                    Age = 16,
                    IsCertified = false,
                }
            };

            var studentsWithOneOrMoreCourses = from student in students
                                where student.Cursos.Count >= 1
                                select student;

        }

        static public void SearchCoursesWithOneOrMoreStudents()
        {
            List<Curso> cursos = new List<Curso>()
            {
                new Curso()
                {
                    Name = "Álgebra",
                    DescriptionSmall = "Curso matemático",
                    DescriptionLarge = "Curso matematico completo de algebra",
                    PublicObject = "Ingenieros",
                    Objects = "Esclarecer las bases y fundamentos de la algebra",
                    Requirements = "Ninguno",
                    Nivel = Nivel.Intermedio,
                    Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Id=1,
                            Name="Matemáticas"
                        }
                    },
                    Students = new List<Student>()
                    {
                        new Student()
                        {
                            Id = 2,
                            Name = "Juan",
                            Grade = 80,
                            Age = 15,
                            IsCertified = false,
                        },
                        new Student()
                        {
                            Id = 3,
                            Name = "David",
                            Grade = 95,
                            Age = 18,
                            IsCertified = true,
                        }
                    }
                },
                new Curso()
                {
                    Name = "Inglés",
                    DescriptionSmall = "Curso básico de inglés",
                    DescriptionLarge = "Curso para aprender las bases del inglés",
                    PublicObject = "Todos",
                    Objects = "Dar a conocer y entender lo básico del lenguaje más conocido en el mundo",
                    Requirements = "Ninguno",
                    Nivel = Nivel.Básico,
                    Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Id=2,
                            Name="Inglés"
                        }
                    },
                    Students = new List<Student>()
                    {
                        new Student()
                        {
                            Id = 2,
                            Name = "Juan",
                            Grade = 80,
                            Age = 15,
                            IsCertified = false,
                        },
                        new Student()
                        {
                            Id = 1,
                            Name = "Michael",
                            Grade = 90,
                            Age = 20,
                            IsCertified = true,
                        }
                    }
                },
                new Curso()
                {
                    Name = "Algoritmos y Programación",
                    DescriptionSmall = "Curso de algoritmos y programación",
                    DescriptionLarge = "Curso para aprender el concepto de Algoritmos y desarrollar habilidades para entender la programación",
                    PublicObject = "Ingenieros o Interesados en la programación",
                    Objects = "Dar a conocer y entender conceptos",
                    Requirements = "Ninguno",
                    Nivel = Nivel.Básico,
                    Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Id=3,
                            Name="Programación"
                        }
                    },
                    Students = new List<Student>()
                }
            };

            var coursesWithOneOrMoreStudents= from curso in cursos
                                        where curso.Students.Count >= 1
                                        select curso;

            var coursesWithCategoryX = cursos.Any(curso =>
                        curso.Categories.Any(category => category.Name == "Programación"));

            var coursesWithoutStudents = from curso in cursos
                                         where curso.Students.Count == 0
                                         select curso;

        }

    }
}
