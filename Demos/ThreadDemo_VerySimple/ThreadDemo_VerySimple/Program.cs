using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo_VerySimple
{
    class Program
    {
        public static void thread()
        {
            Console.WriteLine("Ez a szálprogram!");
            Thread.Sleep(1000);
            Console.WriteLine("Letelt az 1 másodperc a szálban!");
            Thread.Sleep(5000);
            Console.WriteLine("Letelt az 5 másodperc a szálban!");
            Console.WriteLine("Szál vége!");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("A főprogram itt indul!");
            Thread t = new Thread(thread); t.Start(); //szál indítása
            Thread.Sleep(2000); //A főprogram áll.
            Console.WriteLine("Letelt a 2 másodperc a főprogramban, a szálat felfüggesztjük!");
            t.Suspend(); // a szál megáll
            Thread.Sleep(2000); //a főprogram megáll
            Console.WriteLine("Letelt az újabb 2 másodperc a főprogramban, a szál végrehajtását folytatjuk!");
            t.Resume();  // szal újraindul
            t.Join();   // megvárjuk a szál befejeződést, a főprogram is áll
            Console.WriteLine("Program vége!");

            Console.ReadKey();
        }
    }
}
