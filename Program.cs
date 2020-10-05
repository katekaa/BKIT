using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading;
using System.Xml;

namespace stud1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Честнова Екатерина Александровна ИУ5-32Б");
            int a, b, c;
            double D1, D21, D22;
            bool result, square=false, final = true;
            if (args.Length > 0)
            {
                
                result = int.TryParse(args[0], out a);
                while (!result)
                {
                    Enter(ref result, ref a, 'a');
                }
                result = int.TryParse(args[1], out b);
                while (!result)
                {
                    Enter(ref result, ref b, 'b');
                }
                result = int.TryParse(args[2], out c);
                while (!result)
                {
                    Enter(ref result, ref c, 'c');
                }


            }

            else
            {
                Console.WriteLine("Введите коэффициенты a, b, c");
                Console.WriteLine("коэффициент a:");
                result = int.TryParse(Console.ReadLine(), out a);
                while (!result)
                {
                    Enter(ref result, ref a, 'a');
                }
                Console.WriteLine("коэффициент b:");
                result = int.TryParse(Console.ReadLine(), out b);
                while (!result)
                {
                    Enter(ref result, ref b, 'b');
                }
                Console.WriteLine("коэффициент c:");
                result = int.TryParse(Console.ReadLine(), out c);
                while (!result)
                {
                    Enter(ref result, ref c, 'c');
                }
            }
            if (a == 0) { a = b; b = 0; square = true; }
            D1 = b * b - (4 * a * c);
            if (D1 > 0)
            {                
                if (square)
                {
                    Outp();
                    Console.WriteLine("{0},  {1} ", (-b + Math.Sqrt(D1)) / (2 * a), (-b - Math.Sqrt(D1)) / (2 * a));
                    Console.ResetColor();
                }
                else
                {
                    D21 = (-b + Math.Sqrt(D1)) / (2 * a);
                    D22 = (-b - Math.Sqrt(D1)) / (2 * a);
                    if (D21 >= 0 || D22 >= 0)
                    {
                        Outp();
                        if (D21 > 0) Console.WriteLine("{0},  {1} ", Math.Sqrt(D21), -Math.Sqrt(D21));
                        if (D22 > 0) Console.WriteLine("{0},  {1} ", Math.Sqrt(D22), -Math.Sqrt(D22));
                        Console.ResetColor();
                    }

                    if (D21 == 0 || D22 == 0) OneRoot();
                    if (D21 < 0 && D22 < 0) final = false;
                }
            }
            else if (D1 == 0)
            {
                
                if (square && (a != 0))
                {
                    Outp();
                    Console.WriteLine((-b) / (2 * a));
                    Console.ResetColor();
                }
                else if (!square)
                {
                    D21 = (-b) / (2 * a);
                    if (D21 > 0)
                    {
                        Outp();
                        Console.WriteLine("{0},  {1} ", Math.Sqrt(D21), -Math.Sqrt(D21));
                        Console.ResetColor();
                    }
                    else if (D21 == 0)
                    {
                        Console.WriteLine("Корни уравнения: ");
                        OneRoot();
                    }
                    else final = false;
                }
                else final = false;
            }
            else final = false;
            if (!final)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет корней.");
                Console.ResetColor();
            }

        }
        static void Enter(ref bool res, ref int param, char a)
        {
            Console.WriteLine("Некорректное значение коэффициента " + a + ". Введите целое число");
            res = int.TryParse(Console.ReadLine(), out param);
        }
        static void OneRoot()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("0");
            Console.ResetColor();
        }
        static void Outp() {
            Console.WriteLine("Корни уравнения: ");
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}