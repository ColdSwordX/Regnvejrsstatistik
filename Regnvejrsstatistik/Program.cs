// Version 0.2.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regnvejrsstatistik
{
    class Program
    {
        public static List<string> ugeDage = new List<string>() { "Mandag", "Tirsdag","Onsdag", "Torsdag", "Fredag", "Lørdag", "Søndag" };
        public static double[] ugenDageVaerdier = new double[7];
        public static string[] ugeDageKommentar = new string[7];
        static void Main(string[] args)
        {
            while (true)
            {
                IndtastVaerdiger();
                Console.WriteLine(GennemsnitUdregnet());
                Console.WriteLine(MaksimumUdregnet());
                Console.WriteLine(MinimumUdregnet());

            }
        }
        static void IndtastVaerdiger()//håndtere indtastning af værdiger.
        {
            for (int i = 0; i < 7 ; i++)
            {
                Console.Clear();
                Console.WriteLine($"\n Indtast værdigen for hvor meget regn (xx,xx)mm der er om {ugeDage[i]}");
                bool erNummer = double.TryParse(Console.ReadLine(), out double nummer);
                while (!erNummer)
                {
                    Console.WriteLine("Du skal intaste et nummer!");
                    Console.WriteLine("Prøv igen");
                    erNummer = double.TryParse(Console.ReadLine(), out nummer);
                }
                Console.WriteLine($"{nummer}mm blev indsat på {ugeDage[i]}");
                ugenDageVaerdier[i] = nummer;
                IndtastKommentar(i);
                Console.ReadLine();
            }
        }
        static void IndtastKommentar(int ugeDagNummer)//håndtere indtastning af kommentar.
        {
            Console.WriteLine("\n Du kan skrive kommentar til dagen.");
            ugeDageKommentar[ugeDagNummer] = Console.ReadLine();
            Console.WriteLine("Kommentar tilføjet, tryk på en tast, for at forsætte.");
        }
        static double GennemsnitUdregnet()//Finder gennemsnittet.
        {
            int counter = 0;
            double Gennemsnit = 0;
            foreach (double vaerdier in ugenDageVaerdier)
            {
                counter++;
                Gennemsnit += vaerdier;
            }
            return Gennemsnit / counter;
        }
        static double MaksimumUdregnet()//Finder den højeste værdi.
        {
            double maksimum = 0;
            foreach (double vaerdier in ugenDageVaerdier)
            {
                if (maksimum < vaerdier)
                {
                    maksimum = vaerdier;
                }
            }
            return maksimum;
        }
        static double MinimumUdregnet()//Finder den laveste værdi.
        {
            double minimum = 1000;
            foreach (double vaerdier in ugenDageVaerdier)
            {
                if (minimum > vaerdier)
                {
                    minimum = vaerdier;
                }
            }
            return minimum;
        }
    }
}
