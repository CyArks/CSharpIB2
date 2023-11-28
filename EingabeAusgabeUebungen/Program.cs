using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EingabeAusgabeUebungen
{
    internal class Program
    {
        class Date
        {
            public int year;
            public int month;
            public int day;

            public Date() { }

            public Date(int _day, int _month, int _year)
            // Init Method for the Date class
            {

                try
                {
                    if (_day <= 0)
                    {
                        throw new Exception("Ungueltiger Wert fuer den Tag!");
                    }
                    if (_day > 31)
                    {
                        throw new Exception("Ungueltiger Wert fuer den Tag!");
                    }

                    if (_month <= 0)
                    {
                        throw new Exception("Ungueltiger Wert fuer den Monat!");
                    }
                    if (_month > 12)
                    {
                        throw new Exception("Ungueltiger Wert fuer den Monat!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Fehler: " + e.Message);
                    Console.WriteLine("versuchen Sie es erneut!");
                    datumEingeben();
                }

                day = _day;
                month = _month;
                year = _year;
            }

            public Date datumEingeben()
            // Asks the user to input a date in a specific format and then checks if it is a possible date
            {
                char[] delimiters = { '.' };

                Console.WriteLine("Geben Sie ein Datum im Format 'dd.mm.yyyy' ein: ");

                string[] dates = Console.ReadLine().Split(delimiters);

                /* Test code to see if string array is inited as it should be!
                foreach (var c in dates)
                {
                    Console.WriteLine(c);
                }
                */

                try
                {
                    Date myDate = new Date(Convert.ToInt32(dates[0]), Convert.ToInt32(dates[1]), Convert.ToInt32(dates[2]));
                    Console.WriteLine("Das eingegebene Datum: " + myDate.day + "." + myDate.month + "." + myDate.year);
                    return myDate;
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Ungueltige Eingabe: {ex.Message}");
                    return null;
                }
            }

            public bool testSchaltjahr()
            {
                if (year % 4 == 0)
                {
                    if (year % 100 != 0)
                    {
                        return true;
                    }
                    else if (year % 100 == 0)
                    {
                        if (year % 400 == 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        class Password
        {
            public char[] password = new char[4];
            public char[] upperPassword = new char[4];

            public Password()
            // Init Password Method -> Asks the user to input a password
            {
                Console.WriteLine("Bitte geben Sie hintereinander 4 Zeichen (Ihr Passwort) ein: ");

                try
                {
                    for (int i = 0; i < 4; i++)
                    {
                        password[i] = Convert.ToChar(Console.ReadLine());

                        // Convertieren zu string um upper Methode verwenden zu können und anschließendes zurück konvertieren in char
                        upperPassword[i] = Convert.ToChar(Convert.ToString(password[i]).ToUpper());
                        Console.WriteLine("Eigegebener char: " + password[i]);
                    }

                    int tries = 0;
                    bool loggedIn = false;

                    while (tries < 3)
                    {
                        tries++;
                        loggedIn = Login();
                        if (!loggedIn)
                        {
                            Console.WriteLine("Es wurde das falsche Passwort eingegeben, versuchen Sie es erneut. Versuche uebrig: " + (3 - tries));
                        }
                        else
                        {
                            Console.WriteLine("Passwort richtig!");
                            break;
                        }

                    }
                    if (tries >= 3) if (!loggedIn)
                        {
                            throw new Exception("Zu viele Fehlversuche!");
                        }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Fehler: " + e.Message);
                }
            }

            public bool contains(char c)
            // Method to check if a char is in the upperPassword array
            {
                bool contains = false;

                for (int i = 0; i < 4; i++)
                {
                    if (upperPassword[i] == c) contains = true;
                }

                if (contains) return true;
                else return false;
            }

            public bool Login()
            {
                // bool isCorrect = false;

                // Check if the passowrd aligns with the hardcoded password and the given password rules
                if (contains('P')) if (contains('R')) if (contains('O')) if (contains('G'))
                            {
                                return true;
                            }
                return false;

                /*
                for (int i = 0; i < 4; i++)
                {
                    if (upperPassword[i] == 'P')
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (upperPassword[j] == 'R')
                            {
                                for (int k = 0; k < 4; k++)
                                {
                                    if (upperPassword[k] == 'O')
                                    {
                                        for (int l = 0; l < 4; l++)
                                        {
                                            if (upperPassword[l] == 'G')
                                            {
                                                Console.WriteLine("LOGIN korrekt");
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return false
                */
            }
        }

        static void Main(string[] args)
        {
            // Datum Klasse, wird leer initialisiert, mit Klassenmethode datumEingeben wird User aufgefordert ein Datum einzugeben
            Date myDate = new Date();
            myDate.datumEingeben();

            if (myDate.testSchaltjahr())
            {
                Console.WriteLine("Das eingegebene Jahr ist ein Schaltjahr!\n");
            }
            else Console.WriteLine("Das eingegebene Jahr ist kein Schaltjahr!\n");

            Password myPW = new Password();      // Passwort Klasse welche im init den User nach dem Passwort fragt

            Console.WriteLine("\nPress any button to exit the programm!");
            Console.ReadLine();

        }

    }
}
