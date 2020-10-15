using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace lab2Csh
{
    abstract class Figure: IComparable
    {
        public string Type { get; set; }
        
        public abstract double Area();
        public override string ToString()
        {
            return this.Type + " площадью " + this.Area().ToString();
        }
        public int CompateTo(object fig) {
            Figure a = Figure(fig);
            if (this.Area() < a.Area()) return -1;
            else if (this.Area() == a.Area()) return 0;
            else return 1; 
        }
    }
}
     interface IPrint
        {
            void Print();
        }
     class Rectangle : Figure, IPrint {
        
            public int width { get; set; }
            public int height { get; set; }
            public Rectangle(int x, int y) {            
                if (x > 0) height = x;
                else height = 0;
                if (y > 0) width = y;
                else width = 0;
                this.Type = "Прямоугольник со сторонами " + height.ToString() + " и " + width.ToString();
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
            this.Type = "Квадрат со стороной " + height.ToString();
        }
    }
    class Circle : Figure, IPrint {
        public int radius { get; set; }
        public Circle(int a) {            
            if (a > 0) radius = a;
            else radius = 0;
            Type = "Круг с радиусом " + radius.ToString();
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
            first.Print();
            Square second = new Square(4);
            second.Print();
            Circle third = new Circle(2);
            third.Print();
            Rectangle error = new Rectangle(-3, 4);
            error.Print();
        }
    }
}
