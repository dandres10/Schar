using System;

namespace Delegado
{
    public class Program: DelegateExample
    {
        public static void Main(string[] args)
        {
            

            bool resultado = false;

            resultado = DoSomething(() =>
            {
                int cal = 2 / 2;
                int cal2 = cal;
            });

            Console.ReadKey();
        }
    }
}