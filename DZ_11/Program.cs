using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_11
{
    internal class Program
    {
        abstract class Edition
        {
            public string Title { get; set; }
            public string AuthorSurname { get; set; }

            public abstract void DisplayInfo();
            public abstract bool IsSearchedEdition(string searchedAuthorSurname);
        }

        class Book : Edition
        {
            public int Year { get; set; }
            public string Publisher { get; set; }

            public override void DisplayInfo()
            {
                Console.WriteLine($"Book: {Title}, Author: {AuthorSurname}, Year: {Year}, Publisher: {Publisher}");
            }

            public override bool IsSearchedEdition(string searchedAuthorSurname)
            {
                return AuthorSurname == searchedAuthorSurname;
            }
        }

        class Article : Edition
        {
            public string JournalName { get; set; }
            public int JournalNumber { get; set; }
            public int Year { get; set; }

            public override void DisplayInfo()
            {
                Console.WriteLine($"Article: {Title}, Author: {AuthorSurname}, Journal: {JournalName}, Number: {JournalNumber}, Year: {Year}");
            }

            public override bool IsSearchedEdition(string searchedAuthorSurname)
            {
                return AuthorSurname == searchedAuthorSurname;
            }
        }

        class Ebook : Edition
        {
            public string Link { get; set; }
            public string Summary { get; set; }

            public override void DisplayInfo()
            {
                Console.WriteLine($"Ebook: {Title}, Author: {AuthorSurname}, Link: {Link}, Summary: {Summary}");
            }

            public override bool IsSearchedEdition(string searchedAuthorSurname)
            {
                return AuthorSurname == searchedAuthorSurname;
            }
        }
        abstract class BaseClass
        {
            protected int[] arr;

            public BaseClass(int size)
            {
                arr = new int[size];
            }

            public int Size
            {
                get { return arr.Length; }
            }

            public abstract void DisplayArray();

            public int this[int index]
            {
                get
                {
                    if (index >= 0 && index < arr.Length)
                        return arr[index];
                    else
                        throw new IndexOutOfRangeException();
                }
                set
                {
                    if (index >= 0 && index < arr.Length)
                        arr[index] = value;
                    else
                        throw new IndexOutOfRangeException();
                }
            }
        }
        class DerivedClass : BaseClass
        {
            public DerivedClass(int size) : base(size)
            {
            }

            public override void DisplayArray()
            {
                Console.WriteLine("Array elements:");
                foreach (int val in arr)
                {
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }
        abstract class Figure : IComparable<Figure>
        {
            public abstract double CalculateArea();
            public abstract double CalculatePerimeter();
            public abstract void DisplayInfo();

            public int CompareTo(Figure other)
            {
                return CalculateArea().CompareTo(other.CalculateArea());
            }
        }

        class Rectangle : Figure
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }

            public override double CalculateArea()
            {
                return Width * Height;
            }

            public override double CalculatePerimeter()
            {
                return 2 * (Width + Height);
            }

            public override void DisplayInfo()
            {
                Console.WriteLine($"Rectangle: Width = {Width}, Height = {Height}, Area = {CalculateArea()}, Perimeter = {CalculatePerimeter()}");
            }
        }

        class Circle : Figure
        {
            public double Radius { get; set; }

            public Circle(double radius)
            {
                Radius = radius;
            }

            public override double CalculateArea()
            {
                return Math.PI * Radius * Radius;
            }

            public override double CalculatePerimeter()
            {
                return 2 * Math.PI * Radius;
            }

            public override void DisplayInfo()
            {
                Console.WriteLine($"Circle: Radius = {Radius}, Area = {CalculateArea()}, Perimeter = {CalculatePerimeter()}");
            }
        }

        class Triangle : Figure
        {
            public double SideA { get; set; }
            public double SideB { get; set; }
            public double SideC { get; set; }

            public Triangle(double sideA, double sideB, double sideC)
            {
                SideA = sideA;
                SideB = sideB;
                SideC = sideC;
            }

            public override double CalculateArea()
            {
                double s = (SideA + SideB + SideC) / 2;
                return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
            }

            public override double CalculatePerimeter()
            {
                return SideA + SideB + SideC;
            }

            public override void DisplayInfo()
            {
                Console.WriteLine($"Triangle: Side A = {SideA}, Side B = {SideB}, Side C = {SideC}, Area = {CalculateArea()}, Perimeter = {CalculatePerimeter()}");
            }
        }
        abstract class Function : IComparable<Function>
        {
            public abstract double Evaluate(double x);
            public abstract void DisplayInfo();

            public int CompareTo(Function other)
            {
                return GetCoefficient().CompareTo(other.GetCoefficient());
            }

            protected abstract double GetCoefficient();
        }

        class Line : Function
        {
            public double A { get; set; }
            public double B { get; set; }

            public Line(double a, double b)
            {
                A = a;
                B = b;
            }

            public override double Evaluate(double x)
            {
                return A * x + B;
            }

            public override void DisplayInfo()
            {
                Console.WriteLine($"Line: y = {A}x + {B}");
            }

            protected override double GetCoefficient()
            {
                return A;
            }
        }

        class Kub : Function
        {
            public double A { get; set; }
            public double B { get; set; }
            public double C { get; set; }

            public Kub(double a, double b, double c)
            {
                A = a;
                B = b;
                C = c;
            }

            public override double Evaluate(double x)
            {
                return A * Math.Pow(x, 3) + B * x + C;
            }

            public override void DisplayInfo()
            {
                Console.WriteLine($"Kub: y = {A}x^3 + {B}x + {C}");
            }

            protected override double GetCoefficient()
            {
                return A;
            }
        }

        class Hyperbola : Function
        {
            public double A { get; set; }

            public Hyperbola(double a)
            {
                A = a;
            }

            public override double Evaluate(double x)
            {
                return A / x;
            }

            public override void DisplayInfo()
            {
                Console.WriteLine($"Hyperbola: y = {A}/x");
            }

            protected override double GetCoefficient()
            {
                return A;
            }
        }
        static void Main(string[] args)
        {
            Edition[] catalog = new Edition[]
        {
            new Book { Title = "Book 1", AuthorSurname = "Smith", Year = 2022, Publisher = "Publisher 1" },
            new Article { Title = "Article 1", AuthorSurname = "Johnson", JournalName = "Journal 1", JournalNumber = 1, Year = 2021 },
            new Ebook { Title = "Ebook 1", AuthorSurname = "Smith", Link = "https://example.com/ebook1", Summary = "Ebook summary" },
            new Book { Title = "Book 2", AuthorSurname = "Williams", Year = 2020, Publisher = "Publisher 2" }
        };

            Console.WriteLine("Catalog:");
            foreach (var edition in catalog)
            {
                edition.DisplayInfo();
            }

            Console.Write("Enter author surname to search: ");
            string searchedAuthorSurname = Console.ReadLine();

            Console.WriteLine($"Editions by author '{searchedAuthorSurname}':");
            foreach (var edition in catalog)
            {
                if (edition.IsSearchedEdition(searchedAuthorSurname))
                {
                    edition.DisplayInfo();
                }
            }

            Console.ReadLine();

            DerivedClass obj = new DerivedClass(5);


            obj[0] = 10;
            obj[1] = 20;
            obj[2] = 30;
            obj[3] = 40;
            obj[4] = 50;


            obj.DisplayArray();


            Console.WriteLine("Element at index 2: " + obj[2]);
            obj[2] = 100;
            obj.DisplayArray();

            Console.ReadLine();



            Console.Write("Enter the number of figures: ");
            int n = int.Parse(Console.ReadLine());

            Figure[] figures = new Figure[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter figure {i + 1} (r for Rectangle, c for Circle, t for Triangle):");
                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "r":
                        Console.Write("Enter width: ");
                        double width = double.Parse(Console.ReadLine());
                        Console.Write("Enter height: ");
                        double height = double.Parse(Console.ReadLine());
                        figures[i] = new Rectangle(width, height);
                        break;
                    case "c":
                        Console.Write("Enter radius: ");
                        double radius = double.Parse(Console.ReadLine());
                        figures[i] = new Circle(radius);
                        break;
                    case "t":
                        Console.Write("Enter side A: ");
                        double sideA = double.Parse(Console.ReadLine());
                        Console.Write("Enter side B: ");
                        double sideB = double.Parse(Console.ReadLine());
                        Console.Write("Enter side C: ");
                        double sideC = double.Parse(Console.ReadLine());
                        figures[i] = new Triangle(sideA, sideB, sideC);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        i--;
                        break;
                }
            }

            Console.WriteLine("\nFigures:");
            foreach (Figure figure in figures)
            {
                figure.DisplayInfo();
            }

            Array.Sort(figures);

            Console.WriteLine("\nFigures sorted by area:");
            foreach (Figure figure in figures)
            {
                figure.DisplayInfo();
            }

            Console.ReadLine();


            Console.Write("Enter the number of functions: ");
            n = int.Parse(Console.ReadLine());

            Function[] functions = new Function[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter function {i + 1} (l for Line, k for Kub, h for Hyperbola):");
                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "l":
                        Console.Write("Enter a: ");
                        double a = double.Parse(Console.ReadLine());
                        Console.Write("Enter b: ");
                        double b = double.Parse(Console.ReadLine());
                        functions[i] = new Line(a, b);
                        break;
                    case "k":
                        Console.Write("Enter a: ");
                        a = double.Parse(Console.ReadLine());
                        Console.Write("Enter b: ");
                        b = double.Parse(Console.ReadLine());
                        Console.Write("Enter c: ");
                        double c = double.Parse(Console.ReadLine());
                        functions[i] = new Kub(a, b, c);
                        break;
                    case "h":
                        Console.Write("Enter a: ");
                        a = double.Parse(Console.ReadLine());
                        functions[i] = new Hyperbola(a);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        i--;
                        break;
                }
            }

            Console.Write("Enter the value of x: ");
            double x = double.Parse(Console.ReadLine());

            Console.WriteLine("\nFunctions:");
            foreach (Function function in functions)
            {
                function.DisplayInfo();
                Console.WriteLine($"Value at x = {x}: {function.Evaluate(x)}");
            }
            Array.Sort(functions);

            Console.WriteLine("\nFunctions sorted by coefficient a:");
            foreach (Function function in functions)
            {
                function.DisplayInfo();
                Console.WriteLine($"Value at x = {x}: {function.Evaluate(x)}");
            }

            Console.ReadLine();
        }
    }
}