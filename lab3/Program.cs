using FigureCollections;
using System;
using System.Collections;
using System.Collections.Generic;


namespace lab2Csh
{
    class FigureCheck : IMatrixCheckEmpty<Figure>
    {
        public Figure getEmptyElement()
        {
            return null;
        }
        public bool checkEmptyElement(Figure element)
        {
            
            if (element == null) return true;
            return false;
        }
    }


    abstract class Figure: IComparable
    {
        public string Type { get; set; }
        
        public abstract double Area();
        public override string ToString()
        {
            return this.Type + " площадью " + this.Area().ToString();
        }
        public int CompareTo(object fig)
        {
            Figure a = (Figure)fig;
            if (this.Area() < a.Area()) return -1;
            else if (this.Area() == a.Area()) return 0;
            else return 1;
        }
    }
     interface IPrint
        {
            void Print();
        }
     class Rectangle : Figure, IPrint {
        protected int _width;
        protected int _height;
            public int width { 
            get { return _width; }
            set {
                if (value > 0) { _width = value; }
                else { _width = 0; }
            }
            }
            public int height { 
            get { return _height; }
            set 
            {
                if (value > 0) { _height = value; }
                else { _height = 0; }
            } 
            }
            public Rectangle(int x, int y) {            
               height = x;                
               width = y;                
               this.Type = "Прямоугольник " ;
            }
            public override double Area()
            {
                return width * height;
            }
            public void Print() {
                Console.WriteLine(this.ToString());
            }
        }
    class Square : Rectangle {
        public Square(int a) : base (a, a) {
            this.Type = "Квадрат ";
        }
    }
    class Circle : Figure, IPrint {
        private int _radius;
        public int radius {
            get { return _radius; }
            set 
            {
                if (value > 0) { _radius = value; }
                else { _radius = 0; }
            }
        }
        public Circle(int a) {
            radius = a;
            Type = "Круг ";
        }
        public override double Area() {
            return Math.Round(radius * radius * Math.PI, 3);
        }
        public void Print() {
            Console.WriteLine(this.ToString());
        }
    
    
    }    
    class Program
    {
        static void Main(string[] args) {
            Rectangle first = new Rectangle(3, 2);
            
            Square second = new Square(4);
            
            Circle third = new Circle(2);
           
            ArrayList arr1 = new ArrayList();
            arr1.Add(first);
            arr1.Add(second);
            arr1.Add(third);
            Console.WriteLine("Необобщенная коллекция");
            foreach (object obj in arr1) Console.WriteLine(obj.ToString());
            arr1.Sort();
            foreach (object obj in arr1) Console.WriteLine(obj.ToString());
            List <Figure> arr2 = new List<Figure>();
            arr2.Add(first);
            arr2.Add(second);
            arr2.Add(third);
            Console.WriteLine("Обобщенная коллекция");
            foreach (Figure fig in arr2) Console.WriteLine(fig.ToString());
            arr2.Sort();
            foreach (Figure fig in arr2) Console.WriteLine(fig.ToString());
            

            Console.WriteLine("\nРабота с разреженной матрицей на 3 измерения");
            Matrix<Figure> figs = new Matrix<Figure>(3, 3, 3, new FigureCheck());
            figs[0, 0, 0] = first;
            figs[1, 1, 1] = second;
            figs[2, 2, 2] = third;
            Console.WriteLine(figs.ToString());
            

            Console.WriteLine("\n\nРабота со стеком");
            SimpleStack<Figure> figs2 = new SimpleStack<Figure>();
            figs2.Push(first);
            figs2.Push(second);
            figs2.Push(third);
            foreach (var o in figs2) Console.WriteLine(figs2.Pop());
            figs2.Push(first);
            figs2.Push(second);
            figs2.Push(third);
            figs2.Sort();
            Console.WriteLine("\nПосле сортировки:");
            foreach (var o in figs2) Console.WriteLine(figs2.Pop());





        }
    }
}
