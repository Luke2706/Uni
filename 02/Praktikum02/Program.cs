using System;
using System.Collections.Generic;
using Praktikum02.Properties;

namespace Praktikum02
{
    internal class Program
    { 
    
        /// <summary>
        /// Main method. Several objects get created and test are made
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            
            Employee e1 = new Employee("Peter", new DateTime(1960, 12, 21),
                new DateTime(2004, 1, 1), "Hohfederstraße 40", 400000);

            Employee e2 = new Employee("Michael", new DateTime(1980, 06, 21),
                DateTime.Today, "Der schone Weg 7", 250000);


            Employee e3 = new Employee("Samuel", new DateTime(1975, 10, 30),
                new DateTime(2005, 10, 1),"Nuernbergerstraße 232", 600000);

            Employee e4 = new Employee("Andreas", new DateTime(2001, 10, 9),
                new DateTime(2010, 9, 1), "Hamburgerstraße 74", 1000000);

            Employee e5 = new Employee("Mustafa", new DateTime(1999, 6, 21),
                new DateTime(2016, 6, 1), "Nuernbergerstraße 232", 600000);
            
            Employee e2_2 = new Employee("Michael", new DateTime(1980, 06, 21),
                DateTime.Today, "Der schone Weg 7", 250000);

            
            //Compare two worker/employee objects

            Console.WriteLine($"Ist e2==e2_2? {e2==e2_2}");
            Console.WriteLine($"Ist e2==e1? {e2==e1}");
            
            EmployeeList list1 = new EmployeeList();
            EmployeeList list2 = new EmployeeList();
            EmployeeList list3 = new EmployeeList();
            EmployeeList list4 = new EmployeeList();

            //List operations

            Console.WriteLine($"list1: \n {list1}");
            list1 += e1;
            list1 += e2;
            list1 += e3;
            Console.WriteLine($"list1: \n {list1}");

            list2 += e1;
            list2 += e3;
            list2 += e2;

            list3 += e1;
            list3 += e4;
            list3 += e5;

            list4 += e5;
            list4 += e2;
            list4 += e4;

            Console.WriteLine($"Ist list1==list2?: {list1==list2}");
            Console.WriteLine($"Ist list1==list3?: {list1==list3}");
            list2 += e5;
            Console.WriteLine($"Ist list1<list2?: {list1<list2}");
            Console.WriteLine($"Ist list1>list2?: {list1>list2}");
            Console.WriteLine($"Ist list1<=list2?: {list1<=list2}");
            Console.WriteLine($"Ist list1>=list2?: {list1>=list2}");
            list2 -= e5;
            Console.WriteLine($"Ist list1==list2?: {list1==list2}");
            
            //Project operations
            
            Project p1 = new Project("Super Wichtig", e1, list1);
            Project p2 = new Project("XCV-T345", e3, list2);
            Project p3 = new Project("Super Wichtig", e1, list2);
            Project p4 = new Project("DLRH",e4, list3);
            Project p5 = new Project("ABC", e2, list4);


            Console.WriteLine($"Ist p1==p2: {p1==p2}?");
            Console.WriteLine($"Ist p1==p3: {p1==p3}?");
            Console.WriteLine($"p1 Manager: {p1.Manager}");
            p1 += e2;
            Console.WriteLine($"p1 Manager: {p1.Manager}");
            p1 += e1;
            p1 += list4;
            Console.WriteLine($"Ist p1>p2: {p1>p2}");
            Console.WriteLine($"Ist p1<p2: {p1<p2}");
            p3 += list4;
            Console.WriteLine($"Ist p1>=p3?: {p1>=p3}");
            p3 -= list4;
            Console.WriteLine($"Ist p1<=p3?: {p1<=p3}");

            
            Console.ReadLine();
            
        }
    }
}