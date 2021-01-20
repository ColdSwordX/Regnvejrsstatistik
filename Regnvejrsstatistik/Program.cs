// Version 1.0.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regnvejrsstatistik
{
    class Program
    {
        public static List<string> ugeDage = new List<string>() { "Mandag", "Tirsdag", "Onsdag", "Torsdag", "Fredag", "Lørdag", "Søndag" };
        public static double[] ugenDageVaerdier = new double[7];
        public static string[] ugeDageKommentar = new string[7];
        static void Main(string[] args)
        {
            IndtastVaerdiger();
            bool live = true;
            while (live)
            {
                UdskrivMenu();
                live = Menu();
                Console.ReadLine();
            }
        }
        static void UdskrivMenu()//Udskriver alle menu pungter.
        {
            Console.Clear();
            Console.WriteLine("Her har du en lille menu.");
            Console.WriteLine("0: Exit program.");
            Console.WriteLine("1: udskriv alle værdiger.");
            Console.WriteLine("2: Udskriv Gennemsnit.");
            Console.WriteLine("3: udskriv Maksimum-værdien.");
            Console.WriteLine("4: udskriv minimum-værdien.");
        }
        static bool Menu()//Menu
        {
            bool choise = true;
            double nummer = ErDetEtTal(Console.ReadLine());
            switch (nummer)
            {
                case 0:
                    choise = false;
                    break;
                case 1:
                    UdskrivAllevaerdier();
                    break;
                case 2:
                    Console.WriteLine("\n" + GennemsnitUdregnet());
                    break;
                case 3:
                    Console.WriteLine("\n" + MaksimumUdregnet());
                    break;
                case 4:
                    Console.WriteLine("\n" + MinimumUdregnet());
                    break;
            }
            return choise;
        }
        static void IndtastVaerdiger()//håndtere indtastning af værdiger.
        {
            for (int i = 0; i < 7; i++)
            {
                Console.Clear();
                Console.WriteLine($"\n Indtast værdigen for hvor meget regn (xx,xx)mm der er om {ugeDage[i]}");
                double nummer = ErDetEtTal(Console.ReadLine());
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
        static void UdskrivAllevaerdier()//Udskriver alle værdier 
        {
            for (int i = 0; i < ugenDageVaerdier.Length; i++)
            {
                Console.WriteLine($"-\t {ugeDage[i]}\t\t {ugenDageVaerdier[i]}mm");
                Console.WriteLine($"{ugeDageKommentar[i]} ");
            }
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
        static double ErDetEtTal(string indtastet)//Finder ud af om det er et tal. Hvis det IKKE er, tvinges brugeren til at skrive et.
        {
            bool erNummer = double.TryParse(indtastet, out double nummer);
            while (!erNummer)
            {
                Console.WriteLine("Du skal intaste et nummer!");
                Console.WriteLine("Prøv igen");
                erNummer = double.TryParse(Console.ReadLine(), out nummer);
            }
            return nummer;
        }
    }
}
