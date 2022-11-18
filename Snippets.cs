using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{


    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat León"
            };

            // 1. SELECT * of cars

            var carList = from car in cars select car;
            foreach ( var car in carList)
            {
                Console.Write(car);
            }

            // 2. SELECT WHERE
            var audiList = from car in cars where car.Contains("Audi") select car;
            foreach( var audi in audiList)
            {
                Console.WriteLine(audi);
            }

        }

        //Number Examples
        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1,2,3,4,5,6,7,8,9};
            //Obtener multiplicado por 3, si es un 9 no lo tomamos y ordenamos ascendentemente;
            var processedNumberList = 
                numbers.Select(num => num*3).Where(num => num!=9).OrderBy(num => num);
        }

        static public void SearchExamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };
             
            var first = textList.First();
            var firstWithC = textList.First(text => text.Equals("c"));
            var jText = textList.First(text => text.Contains("j"));
            var zOrDefualt = textList.FirstOrDefault(text => text.Contains("z"));


            var lastOrDefault = textList.LastOrDefault(text => text.Contains("z"));

            var valueUnique = textList.Single();
            var valueUniqueOrDefault = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers);
        }
        
        static public void MultipleSelect()
        {
            //SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
            };

            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterpise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id=1,
                            Name="Michael",
                            Email="MichaelNossaB@gmail.com",
                            Salary= 5000
                        },
                        new Employee
                        {
                            Id=2,
                            Name="Pepe",
                            Email="Pepe@gmail.com",
                            Salary= 1000
                        },
                        new Employee
                        {
                            Id=3,
                            Name="Juan",
                            Email="Juan@gmail.com",
                            Salary= 1500
                        }
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterpise 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id=1,
                            Name="Javi",
                            Email="Javi@gmail.com",
                            Salary= 2000
                        },
                        new Employee
                        {
                            Id=2,
                            Name="Ragnar",
                            Email="Ragnar@gmail.com",
                            Salary= 3000
                        },
                        new Employee
                        {
                            Id=3,
                            Name="JuanGabi",
                            Email="JuanGabi@gmail.com",
                            Salary= 15000
                        }
                    }
                }
            };

            //Obtain All Employees of all Enterprises
            var EmployeeList = enterprises.SelectMany(enterprise => enterprise.Employees);
            // Know if an list is empty
            bool hasEnterprise = enterprises.Any();

            bool hasEmployee = enterprises.Any(enterprise => enterprise.Employees.Any());

            //All enterprises at least has an employee with more than 1000 of salary
            bool hasEmployeeWithSalaryMoreThan1000 = 
                enterprises.Any(enterpise =>
                    enterpise.Employees.Any(employee => employee.Salary > 1000));
        }
        
        static public void linqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c", "d" };
            var secondList = new List<string>() { "a", "d", "e" };
            //iner join
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };
            var commonResult2 = firstList.Join(
                    secondList,
                    element => element,
                    secondElement => secondElement,
                    (element, secondElement) => new {element, secondElement });

            //OUTER JOIN - LEFT
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };   
            //OUTER JOIN - RIGHT
            var rightOuterJoin = from secondElement in secondList
                                 join element in firstList
                                 on secondElement equals element
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where secondElement != temporalElement
                                select new { Element = secondElement };

            var unionList = leftOuterJoin.Union(rightOuterJoin);
        }

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };
            var skipTwoFirstValues = myList.Skip(2);
            var skipLastTwoValues = myList.SkipLast(2);
            var skipWhile = myList.SkipWhile(num => num <= 4);

            var TakeFirstTwoValues = myList.Take(2);
            var TakeLastTwoValues = myList.TakeLast(2);
            var TakeWhile = myList.TakeWhile(num => num < 4);
        }

        //PAGING WITH SKIP & TAKE
        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage)
        {
            int startIndex = (pageNumber - 1) * resultsPerPage;
            return collection.Skip(startIndex).Take(resultsPerPage);
        }

        static public void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquared = Math.Pow(number, 2)
                               where nSquared > average
                               select number;

            Console.WriteLine("Average: {0}", numbers.Average());

            foreach (int number in aboveAverage)
            {
                Console.WriteLine("Query: Number: {0} Squared: {1}", number, Math.Pow(number, 2));
            }
        }
        static public void ZipLinq()
        {
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6 };
            string[] stringNumbers = { "One", "Two", "Three", "Four", "Five", "Six" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word);
        }

        static public void RepeatRangeLinq()
        {
            //Generate Collections Values [1-1000]
            IEnumerable<int> first1000 = Enumerable.Range(1, 1000);

            IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5);

        }

        static public void studentsLinq()
        {
            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Michael",
                    Grade = 90,
                    IsCertified = true,
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 80,
                    IsCertified = false,
                },
                new Student
                {
                    Id = 3,
                    Name = "David",
                    Grade = 95,
                    IsCertified = true,
                },
                new Student
                {
                    Id = 4,
                    Name = "Gabi",
                    Grade = 50,
                    IsCertified = true,
                },
                new Student
                {
                    Id = 5,
                    Name = "Jorge",
                    Grade = 80,
                    IsCertified = false,
                }
            };

            var certifiedStudents = from student in classRoom
                                    where student.IsCertified
                                    select student;

            var notCertifiedStudents = from student in classRoom
                                       where student.IsCertified == false
                                       select student;

            var approvedStudents = from student in classRoom
                                   where student.Grade >= 50 && student.IsCertified == true
                                   select student;

            var approvedStudentsNames = from student in classRoom
                                      where student.Grade >= 50 && student.IsCertified == true
                                      select student.Name;
        }

        static public void AllLinq()
        {
            var numbers = new List<int>() { 1,2,3,4,5};

            bool AllAreSmallerThan10 = numbers.All(x => x < 10);

            bool AllAreBiggerOrEqualThan2 = numbers.All(x => x >=2);

            var emptyList = new List<int>();

            bool allNumbersAreGreaterThan0 = numbers.All(x => x >= 0);
        }

        static public void aggregateQuerys()
        {
            int[] numbers = { 1,2,3,4,5,6,7,8,9,10};
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);

            string[] words = { "hello", "my", "name", "is", "Michael" };
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current);
        }

        static public void DistinctValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };
            IEnumerable<int> distictNumbers = numbers.Distinct( );
        }

        static public void GroupBy()
        {
            List<int> numbers = new List<int>() {1,2,3,4,5,6,7,8,9};

            var grouped = numbers.GroupBy(x => x%2==0);

            foreach(var group in grouped)
            {
                foreach(var item in group)
                {
                    Console.WriteLine(item);    
                }
            }

            var classRoom = new[]
{
                new Student
                {
                    Id = 1,
                    Name = "Michael",
                    Grade = 90,
                    IsCertified = true,
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 80,
                    IsCertified = false,
                },
                new Student
                {
                    Id = 3,
                    Name = "David",
                    Grade = 95,
                    IsCertified = true,
                },
                new Student
                {
                    Id = 4,
                    Name = "Gabi",
                    Grade = 50,
                    IsCertified = true,
                },
                new Student
                {
                    Id = 5,
                    Name = "Jorge",
                    Grade = 80,
                    IsCertified = false,
                }
            };

            var certifiedQuery = classRoom.GroupBy(student => student.IsCertified);

            foreach (var group in certifiedQuery)
            {
                Console.WriteLine("---------- {0} ------------", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }

        static public void relationsLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id=1,
                    Title="MyFirstPost",
                    Content="This is my first content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id=1,
                            Created = DateTime.Now,
                            Title="MyFirstComment",
                            Content="My content"
                        },
                        new Comment()
                        {
                            Id=2,
                            Created = DateTime.Now,
                            Title="MySecondComment",
                            Content="My other content"
                        }

                    }
                },
                new Post()
                {
                    Id=2,
                    Title="MySecondPost",
                    Content="This is my second content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id=3,
                            Created = DateTime.Now,
                            Title="MyFirstCommentInSecondPost",
                            Content="My content in second post"
                        },
                        new Comment()
                        {
                            Id=4,
                            Created = DateTime.Now,
                            Title="MySecondCommentInSecondPost",
                            Content="My other content in second post"
                        } 

                    }
                }
            };
               
            var commentsWithContent = posts.SelectMany(
                    post => post.Comments,
                        (post, comment) => new { PostId = post.Id, CommentContent = comment.Content });
        } 
    }
}