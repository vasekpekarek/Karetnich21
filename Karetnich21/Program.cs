using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karetnich21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("\t>>> Oko bere <<<");
            Console.WriteLine();   
            int pocetVyherHrac = 0;
            int pocetVyherPC = 0;
            while (true)
            {
                Random nahodnaCisla = new Random();
                int kartyHrace = nahodnaCisla.Next(1, 12);
                int kartyPC = nahodnaCisla.Next(1, 12);
                DalsiKarta:
                Console.WriteLine("Chcete dalsi kartu? (ano/ne) Mate {0}", kartyHrace);
                string volba = Console.ReadLine();

                if (volba == "ano")
                {
                    kartyHrace += nahodnaCisla.Next(1, 12);
                    if (kartyPC < 15)
                    {
                        kartyPC += nahodnaCisla.Next(1, 12);
                    }
                    goto DalsiKarta;
                }
                else if (volba == "ne")
                {
                    if (kartyHrace <= 21 && (kartyPC >21 || kartyPC < kartyHrace))
                    {
                        Console.WriteLine("Vyhral jsi. Pocitac mel {0} bodu.", kartyPC);
                        pocetVyherHrac++;
                    }
                    else if (kartyPC <= 21 && (kartyHrace > 21 || kartyHrace < kartyPC))
                    {
                        Console.WriteLine("Prohral jsi. Pocitac mel {0} bodu.", kartyPC);
                        pocetVyherPC++;
                    }
                    else if (kartyPC > 21 && kartyHrace > 21)
                    {
                        Console.WriteLine("Oba hraci prohrali. Pocitac mel {0} bodu a ty jsi mel {1} bodu.", kartyPC, kartyHrace);
                    }
                    else if (kartyPC == kartyHrace)
                    {
                        Console.WriteLine("Nikdo nevyhral.");
                    }
                    Console.WriteLine("Hrac: {0}, PC: {1}", pocetVyherHrac, pocetVyherPC);
                }
                else
                {
                    Console.WriteLine("Spatny format.");
                    goto DalsiKarta;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
