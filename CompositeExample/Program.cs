using System;
using System.Collections.Generic;

namespace CompositePatternExample
{
    // Component interface
    public interface IEmployee
    {
        void ShowDetails();
    }

    // Leaf class (individual employee)
    public class Developer : IEmployee
    {
        private string _name;
        private string _position;

        public Developer(string name, string position)
        {
            _name = name;
            _position = position;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"{_name} works as a {_position}.");
        }
    }

    // Composite class (manager with subordinates)
    public class Manager : IEmployee
    {
        private string _name;
        private string _position;
        private List<IEmployee> _subordinates = new List<IEmployee>();

        public Manager(string name, string position)
        {
            _name = name;
            _position = position;
        }

        public void AddSubordinate(IEmployee employee)
        {
            _subordinates.Add(employee);
        }

        public void ShowDetails()
        {
            Console.WriteLine($"{_name} works as a {_position} and manages:");
            foreach (var subordinate in _subordinates)
            {
                subordinate.ShowDetails();
            }
        }
    }

    // Example client code
    class Program
    {
        static void Main(string[] args)
        {
            // Creating individual employees (leaf nodes)
            IEmployee dev1 = new Developer("John", "Backend Developer");
            IEmployee dev2 = new Developer("Alice", "Frontend Developer");

            // Creating manager (composite node)
            Manager manager = new Manager("Michael", "Team Lead");
            manager.AddSubordinate(dev1);
            manager.AddSubordinate(dev2);

            // Display details of manager and subordinates
            manager.ShowDetails();
        }
    }
}