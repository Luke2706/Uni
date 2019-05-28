using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Praktikum02.Properties;

namespace Praktikum02
{
    class Project
    {
        private string _titel;
        private Employee _manager;
        private EmployeeList _workerList;
 
        public Project(string titel, Employee manager, EmployeeList workerList)
        {
            this._titel = titel;
            this._manager = manager;
            this._workerList = workerList;
        }

        public string Titel => _titel;
        public Employee Manager => _manager;

        //The property of the workerlist should return a actual copy of the list. Therefore it creates
        //a new empty list, adds the current list and returns the 'new' list
        public EmployeeList WorkerList
        {
            get
            {
                EmployeeList copyList = new EmployeeList();
                copyList += _workerList;
                return copyList;
            }
        }
        
        public static Project operator +(Project projectName, EmployeeList newEmployeeList)
        {
            //Adds the new list to the existing list. Logic defined in the EmloyeeList class
            projectName._workerList += newEmployeeList;
            return projectName;
        }

        public static Project operator -(Project projectName, EmployeeList deleteEmployeeList)
        {
            //Deletes the list from the existing list. Logic defined in the EmployeeList class
            projectName._workerList -= deleteEmployeeList;
            return projectName;
        }

        public static Project operator +(Project projectName, Employee newManager)
        {
            projectName._manager = newManager;
            return projectName;
        }

        public static bool operator !=(Project project1, Project project2)
        {
            //Uses the logic of the == operator and puts a not in return
            return !(project1 == project2);
        }

        public static bool operator ==(Project project1, Project project2)
        {
            //if the project has no title false is returned 
            if (project1._titel == null || project2._titel == null) return false;

            //Uses the == operator of the Employee and EmployeeList class.
            return (project1._titel == project2._titel && project1._manager == project2._manager &&
                    project1._workerList == project2._workerList);
        }

        //Uses the several comparison methods from the EmployeeList class
        public static bool operator <=(Project project1, Project project2)
        {
            return project1._workerList <= project2._workerList;
        }

        public static bool operator >=(Project project1, Project project2)
        {
            return project1._workerList >= project2._workerList;
        }

        public static bool operator <(Project project1, Project project2)
        {
            return project1._workerList < project2._workerList;
        }

        public static bool operator >(Project project1, Project project2)
        {
            return project1._workerList > project2._workerList;
        }
    }
}