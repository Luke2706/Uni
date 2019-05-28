using System;

namespace Praktikum02.Properties
{
    // Class for the Employeelist conatains the several methods eg + or -  which are performed during
    // the run of the program 
    class EmployeeList
    { 
        private Node _rootItem;

        public EmployeeList()
        {
            _rootItem = null;
        }
        public int Count()
        {
            int counter = 0;
            if (_rootItem == null) return counter;

            //iterate through the list and counts the items
            Node currentNode = _rootItem;
            while (currentNode.nextNode != null)
            {
                currentNode = currentNode.nextNode;
                counter += 1;
            }
            return counter + 1;
        }

        public static EmployeeList operator +(EmployeeList list, Employee newEmployee)
        {
            //Add the new item/employee. In case the list is empty the employee is set as the rootitem  
            if (list._rootItem == null)
            {
                list._rootItem = new Node(newEmployee, null);
            }
            else
            {
                //create a "new" node and iterate through it and at the end adds the item
                Node currentNode = list._rootItem;
                while (currentNode.nextNode != null)
                {
                    currentNode = currentNode.nextNode;
                }
                currentNode.nextNode = new Node(newEmployee, null);
            }
            return list;
        }

        public static EmployeeList operator -(EmployeeList list, Employee deleteEmployee)
        {
            //removes the item if its from the list but just the first time. 
            //In case the list is empty an exception is thrown
            if (list._rootItem == null)
            {
                throw new ArgumentNullException("List is empty. No - operation possible!");
            }
            else
            {
                //create a "new" node and iterate through it 
                Node currentNode = list._rootItem;
                while (currentNode.nextNode._employee != deleteEmployee)
                {
                    currentNode = currentNode.nextNode;
                }
                //deletes the item and adds the remaining list to the 'current' list
                Node save = currentNode.nextNode.nextNode;
                currentNode.nextNode = save;
            }

            return list;
        }

        public static EmployeeList operator +(EmployeeList list, EmployeeList newEmployeeList)
        {
            //Adds the new list to the existing list. In the case the new list is empty
            // the current list is returned 
            if (newEmployeeList._rootItem == null) return list;

            Node currentNode = newEmployeeList._rootItem;
            do
            {
                //iterate through the list and use the existing + operator
                //to add the items/worker of the new list to the existing list
                list += currentNode._employee;
                currentNode = currentNode.nextNode;
            } while (currentNode.nextNode != null);

            return list;
        }

        public static EmployeeList operator -(EmployeeList list, EmployeeList deleteEmployeeList)
        {
            if (deleteEmployeeList._rootItem == null) return list;
            
            Node currentNode = deleteEmployeeList._rootItem;
            do
            {
                //iterate through the list and use the existing - operator
                //to remove the items/worker from the 'Deletelist'
                list -= currentNode._employee;
                currentNode = currentNode.nextNode;
            } while (currentNode.nextNode != null);

            return list;
        }

        public static bool operator ==(EmployeeList list1, EmployeeList list2)
        {
            //verify that the list are not empty and have the same number of items
            if (list1._rootItem == null || list2._rootItem == null || list2.Count() != list1.Count())
                return false;

            Node node1 = list1._rootItem;
            Node node2 = list2._rootItem;
            int count = 0;

            //iterate through both lists and checks if the both list have the same employees 
            while (node1 != null)
            {
                while (node2 != null)
                {
                    if (node1._employee == node2._employee)
                    {
                        //item found in both list. counter +1
                        count += 1;
                        break;
                    }
                    node2 = node2.nextNode;
                }
                node1 = node1.nextNode;
                node2 = list2._rootItem;
            }

            //if the counter is the same as the number of the list. both list are the same
            if (count == list1.Count()) return true;
            return false;
        }


        public static bool operator !=(EmployeeList list1, EmployeeList list2)
        {
            //Just uses the == operator and put the the not operator in the return
            return !(list1 == list2);
        }

        //The several comparison methods. They all just use the count method and return the result
        public static bool operator <=(EmployeeList left, EmployeeList right)
        {
            return left.Count() <= right.Count();
        }

        public static bool operator >=(EmployeeList left, EmployeeList right)
        {
            return left.Count() >= right.Count();
        }

        public static bool operator <(EmployeeList left, EmployeeList right)
        {
            return left.Count() < right.Count();
        }

        public static bool operator >(EmployeeList left, EmployeeList right)
        {
            return left.Count() > right.Count();
        }

        // Own toString Method to ensure a nice output 
        public override string ToString()
        {
            string output = null;

            if (_rootItem != null)
            {
                Node n = _rootItem;
                do
                {
                    output += n._employee.ToString();
                    n = n.nextNode;
                } while (n != null);
            }
            return output;
        }
    }

    /// <summary>
    /// Class which is reasonable for the logic of the list. It's like a container which contains
    /// a employee and reference to the next node 
    /// </summary>
    class Node
    {
        public Employee _employee;
        public Node nextNode;
        public Node(Employee newEmployee, Node newNode)
        {
            this._employee = newEmployee;
            this.nextNode = newNode;
        }
    }
}