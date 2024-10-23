using System;
using System.Collections.Generic;

namespace FlyweightPatternExample
{
    // Flyweight (intrinsic shared state)
    public class TreeType
    {
        public string Name { get; private set; }
        public string Color { get; private set; }

        public TreeType(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public void Display(int x, int y)
        {
            Console.WriteLine($"Displaying {Name} tree of color {Color} at coordinates ({x},{y}).");
        }
    }

    // Flyweight Factory
    public class TreeFactory
    {
        private static Dictionary<string, TreeType> _treeTypes = new Dictionary<string, TreeType>();

        public static TreeType GetTreeType(string name, string color)
        {
            string key = $"{name}_{color}";
            if (!_treeTypes.ContainsKey(key))
            {
                _treeTypes[key] = new TreeType(name, color);
            }
            return _treeTypes[key];
        }
    }

    // Context (extrinsic state: unique location for each tree)
    public class Tree
    {
        private int _x;
        private int _y;
        private TreeType _treeType;

        public Tree(int x, int y, TreeType treeType)
        {
            _x = x;
            _y = y;
            _treeType = treeType;
        }

        public void Display()
        {
            _treeType.Display(_x, _y);
        }
    }

    // Example client code
    class Program
    {
        static void Main(string[] args)
        {
            // Creating trees with shared attributes using Flyweight pattern
            Tree tree1 = new Tree(1, 2, TreeFactory.GetTreeType("Oak", "Green"));
            Tree tree2 = new Tree(3, 4, TreeFactory.GetTreeType("Pine", "Dark Green"));
            Tree tree3 = new Tree(5, 6, TreeFactory.GetTreeType("Oak", "Green"));

            // Display trees
            tree1.Display();
            tree2.Display(); 
            tree3.Display(); 

            // Notice that the Oak tree with the same color is reused
        }
    }
}