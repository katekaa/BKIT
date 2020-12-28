using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;

using System.Collections.Generic;


namespace entity
{
    
    class Program
    {
        static void Main(string[] args)
        {

            using (AppContext db = new AppContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Department dep1 = new Department { Name = "Исследования" };
                Department dep2 = new Department { Name = "Маркетинг" };
                Department dep3 = new Department { Name = "HR" };
                db.Departments.AddRange(dep1, dep2, dep3);

                Language lan0 = new Language { Lang = "русский" };
                Language lan1 = new Language {Lang = "английский" };
                Language lan2 = new Language { Lang = "немецкий" };
                Language lan3 = new Language { Lang = "французский" };
                db.Languages.AddRange(lan0, lan1, lan2, lan3);

                Employee emp1 = new Employee { Firstname = "Олег", Lastname = "Попов", Age = 35, Department = dep1 };
                Employee emp2 = new Employee { Firstname = "Мария", Lastname = "Абрикосова", Age = 30, Department = dep3 };
                Employee emp3 = new Employee { Firstname = "Иван", Lastname = "Ан", Age = 40, Department = dep3 };
                Employee emp4 = new Employee { Firstname = "Ольга", Lastname = "Алешина", Age = 35, Department = dep2 };
                db.Employees.AddRange(emp1, emp2, emp3, emp4); 

                Manager man1 = new Manager { Firstname = "Антон", Lastname = "Петров", Age = 38, Department = dep2 };
                Manager man2 = new Manager { Firstname = "Ирина", Lastname = "Пак", Age = 38, Department = dep1 };
                Manager man3 = new Manager { Firstname = "Дарья", Lastname = "Анисимова", Age = 40, Department = dep3 };
                man1.Languages.Add(lan1);
                man1.Languages.Add(lan3);
                man1.Languages.Add(lan0);
                man2.Languages.Add(lan0);
                man3.Languages.Add(lan1);
                man3.Languages.Add(lan0);
                man3.Languages.Add(lan2);
                db.Managers.AddRange(man1, man2, man3);
                
                db.SaveChanges();
                 
                var emps = db.Employees.ToList();
                var deps = db.Departments.ToList();
                var q1 = emps.Join(deps, employee => employee.DepartmentId, department => department.Id,
                    (employee, department) => new
                    {
                        Lastname = employee.Lastname,
                        FullName = employee.FullName,
                        Name = department.Name,
                    });
                Console.WriteLine("\n");

                //сотрудники по отделам
                foreach (var u in q1)
                {
                    Console.WriteLine(u.Name + ": " + u.FullName);
                }    
                
                foreach (var u in deps)
                {
                    var em = emps.Where(a => a.DepartmentId == u.Id);
                    Console.WriteLine("\n"+u.Name + ':');
                    foreach (var v in em)
                    {
                        Console.WriteLine(v.FullName);
                    }
                }
                Console.WriteLine("\n");

                //сотрудники на А
                Console.WriteLine("Список сотрудников с фамалиями на 'А':");
                var q2 = emps.Where(a => a.Lastname.StartsWith('А'));
                foreach (var u in q2 ) {
                    Console.WriteLine(u.FullName + '('+ u.Department.Name + ')');
                }

                Console.WriteLine("\n Список отделов с количеством сотрудников:");
                var q3 = from u in emps
                         group u by u.Department.Name into g
                         select new
                         {
                             g.Key,
                             Count = g.Count()
                         };
                foreach (var u in q3)
                {
                    Console.WriteLine("В отделе {0} работает(-ют) {1} сотрудника(-ов)", u.Key, u.Count);
                }
                Console.WriteLine("\n");

                //отделы с сотрудниками на А
                var q4 = from u in emps
                         group u by u.Department.Name into g
                         where g.All((a) => a.Lastname.StartsWith('А'))
                         select g.Key;
                Console.WriteLine("Список отделов, в которых у всех сотрудников фамилия начинается с буквы 'А': ");
                foreach (var u in q4) Console.WriteLine(u);
                Console.WriteLine("\n");

                //отделы с хотя бы 1 сотрудником на А
                var q5 = from u in emps
                         group u by u.Department.Name into g
                         where g.Any((a) => a.Lastname.StartsWith('А'))
                         select g.Key;
                Console.WriteLine("Список отделов, в которых хотя бы у одного сотрудника фамилия начинается с буквы 'А': ");
                foreach (var u in q5) Console.WriteLine(u);
                Console.WriteLine("\n");

                //все языки и их люди
                var q6 = db.Languages.Include(c => c.Managers).ToList();
                Console.WriteLine("Список всех языков и менеджеры, которые ими владеют: ");
                foreach (var u in q6)
                {
                    Console.WriteLine("\n"+u.Lang + ':');
                    foreach (Manager m in u.Managers)
                    {
                        Console.WriteLine(m.FullName);
                    }
                }
                Console.WriteLine("\n");

                //все менеджеры и их языки
                Console.WriteLine("Список всех менеджеров и языки, которыми они владеют: ");
                var q7 = db.Managers.Include(d => d.Languages).ToList();
                foreach (Manager u in q7)
                {
                    Console.WriteLine("\n" + u.FullName);
                    foreach (var v in u.Languages)
                    {
                        Console.WriteLine(v.Lang);
                    }
                }
                Console.WriteLine("\n");

                //менеджеры, влядеющие минимум двумя языками
                Console.WriteLine("Список менеджеров, владеющих двумя или более языками:");
                var q8 = from m in q7
                         where m.Languages.Count() > 1
                         select new
                         {
                             Id = m.Id,
                             FullName = m.FullName,
                             Count = m.Languages.Count()
                         };
                foreach (var u in q8)
                {
                    Console.WriteLine(u.FullName + " - " + u.Count);
                }



            }
        }
    }
}
    

