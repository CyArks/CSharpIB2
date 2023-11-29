using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Author:                  Florian Manhartseder
 * Description:             Uebungsaufgaben Input-Output -> C#
 * Creation-Date:           22.11.2023
 * Last-Changed:            22.11.2023
*/


namespace IO_Operations
{
    internal class Program
    {
        static void Zinsberechnnung(int laufzeit, double startkapital=0, double zinssatz=0)
        {
            // Bei Mitagbe von Startkapital und Zinssatz wird der User zu keiner Eingabe aufgefordert

            double endkapital = 0;

            // Startkapital einlesen
            try
            {
                if (startkapital == 0) {
                    Console.WriteLine("Bitte geben sie das Startkapital ein: ");
                    startkapital = Convert.ToDouble(Console.ReadLine());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Zinssatz einlesen
            try
            {
                if (zinssatz == 0) {
                    Console.WriteLine("Geben sie den Zinssatz ein: ");
                    zinssatz = Convert.ToDouble(Console.ReadLine());
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Endkapital berechnen
            try
            {
                endkapital = startkapital * Math.Pow((zinssatz / 100 + 1), laufzeit);
                Console.WriteLine("Endkapital: " + endkapital);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }

        static void PrintABBA()
        {
            int ASCII_A = 65;
            int ASCII_B = 66;

            Console.WriteLine(Char.ConvertFromUtf32(ASCII_A) + Char.ConvertFromUtf32(ASCII_B) + Char.ConvertFromUtf32(ASCII_B) + Char.ConvertFromUtf32(ASCII_A));
        }

        static void Gewinnberechnung()
        {
            double fixKosten = 0;
            double produktKosten = 0;
            double produktErloes = 0;
            int menge = 0;
            
            double gewinn = 0;

            // Get user input - catch any error
            try
            {
                Console.WriteLine("Geben Sie die fixen Kosten ein: ");
                fixKosten = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Geben Sie die Kosten fuer ein Produklt ein: ");
                produktKosten = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Geben Sie den Erloes fuer ein Produkt ein: ");
                produktErloes = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Wie viele Produkte sollten hergestellt werden?");
                menge = Convert.ToInt32(Console.ReadLine());


                // Gewinn berechnen
                gewinn = -fixKosten - produktKosten * menge + produktErloes * menge;
                Console.WriteLine("Der Gewinn betraegt: " + gewinn + "\n");

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        static void LinearSolver()
        {
            double a = 0, b = 0;
            double x = 0;

            // Get user input - catch any error
            try
            {
                Console.WriteLine("Geben sie einen Wert fuer a ein: ");
                a = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Geben sie einen Wert fuer b ein: ");
                b = Convert.ToDouble(Console.ReadLine());

                x = (-b) / a;
                Console.WriteLine("Die Loesung ist : " + x);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {
            Zinsberechnnung(3, 1500, 5);
            Gewinnberechnung();
            LinearSolver();
            PrintABBA();

            Console.ReadLine(); // Keeps the console window open
        }

       
    }
}

