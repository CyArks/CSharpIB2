using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Program
    {
        class MathOperations
        {
            public static double Addieren(double a, double b)
            {
                if (a < 0 || b < 0)
                {
                    throw new ArgumentOutOfRangeException("Negative Zahlen sind nicht erlaubt.");
                }

                double result = a + b;
                if (double.IsPositiveInfinity(result) || double.IsNegativeInfinity(result))
                {
                    throw new OverflowException("Overflow bei Addition aufgetreten.");
                }

                return result;
            }

            public static double Subtrahieren(double a, double b)
            {
                return a - b;
            }

            public static double Multiplizieren(double a, double b)
            {
                if (a < 0 || b < 0)
                {
                    throw new ArgumentOutOfRangeException("Negative Zahlen sind nicht erlaubt.");
                }

                double result = a * b;
                if (double.IsPositiveInfinity(result) || double.IsNegativeInfinity(result))
                {
                    throw new OverflowException("Overflow bei Multiplikation aufgetreten.");
                }

                return result;
            }

            public static double Dividieren(double a, double b)
            {
                if (b == 0)
                {
                    throw new DivideByZeroException("Division durch Null ist nicht erlaubt.");
                }
                return a / b;
            }
        }

        static void Main()
        {
            try
            {
                double result = MathOperations.Addieren(1e300, 1e300);
                Console.WriteLine("Ergebnis der Addition: " + result);

                result = MathOperations.Multiplizieren(1e300, 1e300); // Except Overflow error 
                Console.WriteLine("Ergebnis der Multiplikation: " + result);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Argumentfehler: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Overflow-Fehler: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ein unerwarteter Fehler ist aufgetreten: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Die Berechnung ist abgeschlossen.");
            }
            Console.ReadLine();
        }
    }
}
