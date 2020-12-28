using System;
using System.Reflection;


namespace lab6
{
    delegate string Find(char a, string[] s);
    class Program
    {        
        static string searchS(char a, string[] s) {            
            if (Array.Exists(s, element => element.Trim().StartsWith(a)||  element.Trim().StartsWith(a.ToString().ToUpper()) )) return "Есть слова, начинающиеся на '" + a.ToString() +"'.";
            else return "Нет слов, начинающихся на '" + a.ToString() + "'.";
        }
        static string searchE(char a, string[] s)
        {
            
            if (Array.Exists(s, element => element.EndsWith(a) ||element.EndsWith(a.ToString().ToUpper()) )) return "Есть слова, оканчивающиеся на '" + a.ToString() + "'.";
            return "Нет слов, оканчивающихся на '" + a.ToString() + "'.";
        }
        static string search(char a, string[] s)
        {            
            foreach (string str in s) {
                if (str.ToLower().Contains(a)) return "Есть слова, содержащие '" + a.ToString() + "'.";
            }
            return "Нет слов, содержащих '" + a.ToString() + "'.";
        }
        static void inf(string i, char a, string [] s, Find FindPar) {
            Console.WriteLine("\nСписок слов:");
            foreach (string str in s) { 
                Console.WriteLine(str.Trim()); 
            }
            Console.WriteLine( i + '\n' + FindPar(a, s));
        }
        //использует обобщенный делегат, делит массив пополам
        static void inf2(string i, char a, string[] s, Func<char, string[], string> FindPar) {
            Console.WriteLine("\nСписок слов:");
            Array.Resize(ref s, (int)s.Length/2);
            foreach (string str in s)
            {
                Console.WriteLine(str.Trim());
            }
            Console.WriteLine(i + '\n' + FindPar(a, s));
        }

        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;            
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }
            return Result;
        }
       
        static void Main(string[] args)
        {
            //ЧАСТЬ 1
            string[] words = { "  romE ", "mouse", "hEy", "DARK", " ice   " };
            string[] words2 = { "house", "bang", "Room", " light" };
            char a;
            Console.WriteLine("Введите букву:");
            a=Char.ToLower((char)Console.Read());
            inf("поиск по началу", a, words, searchS);
            inf("поиск", a, words, search);
            inf("поиск по концу", a, words2, searchE);            
            inf("поиск по концу ", a, words2, (char a, string [] s) =>
                                       {
                                         if (Array.Exists(s, element => element.EndsWith(a) || element.EndsWith(a.ToString().ToUpper()))) return "Есть слова, оканчивающиеся на '" + a.ToString() + "' .";
                                         return "Нет слов, оканчивающихся на '" + a.ToString() + "'.";
                                                            });
            inf2("поиск по началу", a, words, searchS);
            inf2("поиск по началу", a, words, (char a, string[] s) =>
            {
                if (Array.Exists(s, element => element.Trim().StartsWith(a) || element.Trim().StartsWith(a.ToString().ToUpper()))) return "Есть слова, начинающиеся на '" + a.ToString() + "' .";
                else return "Нет слов, начинающихся на '" + a.ToString() + "'.";
            });

            //ЧАСТЬ 2
            Class1 ex = new Class1();
            ex.v1 = 8;
            Type info = ex.GetType();
            Console.WriteLine("\nИнформация о типе:");
            Console.WriteLine("\nКонструкторы:");
            foreach (var x in info.GetConstructors())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nМетоды:");
            foreach (var x in info.GetMethods())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nСвойства:");
            foreach (var x in info.GetProperties())
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\nСвойства, помеченные атрибутом:");
            foreach (var x in info.GetProperties())
            {
                object attrObj;
                if (GetPropertyAttribute(x, typeof(Attr), out attrObj))
                {
                    Attr attr = attrObj as Attr;
                    Console.WriteLine(x.Name + " - " + attr.descr);
                }
            }
            object Res1 = info.InvokeMember("testSt", BindingFlags.InvokeMethod, null, ex, null);
            Console.WriteLine("Вызов метода testSt \n" + Res1);
            object Res2 = info.InvokeMember("testIn", BindingFlags.InvokeMethod, null, ex, null);
            Console.WriteLine("Вызов метода testIn \n" + Res2.ToString());
        }
    }
}
