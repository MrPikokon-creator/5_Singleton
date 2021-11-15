using System;
using System.Threading;

namespace Singleton
{
    public class Program
    {
        private static void Call()
        {
            ChocolateBoiler boiler = ChocolateBoiler.getInstance();
            
            boiler.Fill();
            boiler.Boil();
            boiler.Drain();
        }
        
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Call();
            Call();
            
            //new Thread(new ThreadStart(Call)).Start();
            //new Thread(new ThreadStart(Call)).Start();

            Console.ReadKey();
        }
    }
}
