using System;

namespace Praktikum02.Properties
{
    public class Employee
    {
        private string _name;
        private DateTime _dateOfBirth;
        private DateTime _dateOfHire;
        private string _address;
        private int _salary;
        private string _skills;
        public Employee(string name, DateTime dateOfBirth, DateTime dateOfHire, string address, int salary)
        {
            this._name = name;
            this._dateOfBirth = dateOfBirth;
            this._dateOfHire = dateOfHire;
            this._address = address;
            this._salary = salary;
        }

        private bool Equals(Employee other)
        {
            //checks if the name and birth/hire date are the same. 
            return string.Equals(_name, other._name) && _dateOfBirth.Equals(other._dateOfBirth) &&
                   _dateOfHire.Equals(other._dateOfHire);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Employee) obj);
        }

        public string Name => _name;

        public DateTime DateOfBirth => _dateOfBirth;

        public DateTime DateOfHire => _dateOfHire;

        public string GetSkills()
        {
            if (_skills == null) return "no skills defined!";
            return _skills;
        }

        public string Adress
        {
            get => _address;
            set => _address = value;
        }

        public int Salary
        {
            get => _salary;
            set => _salary = value;
        }

        //Method can be ignored.
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _dateOfBirth.GetHashCode();
                hashCode = (hashCode * 397) ^ _dateOfHire.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Employee left, Employee right)
        {
            //Uses the Equals method of the Employee class
            return Equals(left, right);
        }

        public static bool operator !=(Employee left, Employee right)
        {
            //Uses the == operator with a ! in the return
            return !Equals(left, right);
        }

        public void AddSkill(string newSkill)
        {
            this._skills += $"{newSkill},";
        }
        
        // Own to String method for a clear output 
        public override string ToString()
        {
            return $"Worker Infos\nName: {_name} || Date of birth: {_dateOfBirth} || Date of hire: {_dateOfHire} || \n" +
                   $"Adress: {_address} || Salary: {_salary} || Skills: {GetSkills()} \n";
        }
    }
}