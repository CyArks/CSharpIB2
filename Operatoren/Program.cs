using System;
using System.Net;
using System.Net.Sockets;

namespace CSharpOperatoren
{
    internal class Program
    {
        // Aufgabe  4.2 Rest berechnen 
        static int DivRest(int val1, int val2)
        {
            int prod = val1 / val2;
            int rest = val1 - prod * val2;

            Console.WriteLine("Der Rest der Division " + val1 + " / " +  val2 + " ist: " + rest);

            return rest;
        }

        // Aufgabe 4.3
        static void BitShiftMultiplier()
        {
            Console.WriteLine("Geben Sie eine ganze Zahl ein welche mit 2, 4 und 32 multipliziert werden soll: ");
            int eingabeZahl = 0;

            eingabeZahl = Convert.ToInt32(Console.ReadLine()); 

            // *2
            Console.WriteLine("Ergebniss (" + eingabeZahl + " * 2): " + (eingabeZahl << 1));

            // *4 
            Console.WriteLine("Ergebniss (" + eingabeZahl + " * 4): " + ( eingabeZahl << 2));

            // *32 
            Console.WriteLine("Ergebniss (" + eingabeZahl + " * 32): " + (eingabeZahl << 5));
            Console.WriteLine("\n\n");

        }

        // Class IPAddress für Aufgabe 4.4
        class _IPAddress
        {
            public decimal base10AdressP1 { get; set; }
            public decimal base10AdressP2 { get; set; }
            public decimal base10AdressP3 { get; set; }
            public decimal base10AdressP4 { get; set; }
            public string base2AdressP1 { get; set; }
            public string base2AdressP2 { get; set; }
            public string base2AdressP3 { get; set; }
            public string base2AdressP4 { get; set; }

            public _IPAddress() { }

            public _IPAddress(decimal P1, decimal P2, decimal P3, decimal P4) 
            {
                base10AdressP1 = P1;
                base10AdressP2 = P2;
                base10AdressP3 = P3;
                base10AdressP4 = P4;

                // Convert to binary in 8-Bit Format
                base2AdressP1 = Convert.ToString((int)P1, 2).PadLeft(8, '0');
                base2AdressP2 = Convert.ToString((int)P2, 2).PadLeft(8, '0');
                base2AdressP3 = Convert.ToString((int)P3, 2).PadLeft(8, '0');
                base2AdressP4 = Convert.ToString((int)P4, 2).PadLeft(8, '0');
            }

            public _IPAddress(string binaryP1, string binaryP2, string binaryP3, string binaryP4)
            {
                base2AdressP1 = binaryP1;
                base2AdressP2 = binaryP2;
                base2AdressP3 = binaryP3;
                base2AdressP4 = binaryP4;

                // Convert from binary to decimal
                base10AdressP1 = Convert.ToDecimal(Convert.ToInt32(binaryP1, 2));
                base10AdressP2 = Convert.ToDecimal(Convert.ToInt32(binaryP2, 2));
                base10AdressP3 = Convert.ToDecimal(Convert.ToInt32(binaryP3, 2));
                base10AdressP4 = Convert.ToDecimal(Convert.ToInt32(binaryP4, 2));
            }
        
            // Constructor Methode to ask the user to input an IPAdress
            public void askIPAdress()
            {
                try
                {
                    Console.WriteLine("Geben Sie den 1. Teil der IP-Adresse ein: ");
                    base10AdressP1 = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Geben Sie den 2. Teil der IP-Adresse ein: ");
                    base10AdressP2 = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Geben Sie den 3. Teil der IP-Adresse ein: ");
                    base10AdressP3 = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Geben Sie den 4. Teil der IP-Adresse ein: ");
                    base10AdressP4 = Convert.ToDecimal(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ungültige Eingabe, bitte geben Sie die IP Adresse einzeln ein: " + e);
                }
            }

            // Methode to print the objects base 10 IP-Adress to the console
            public void printBase10Adress()
            {
                Console.WriteLine("IP-Adress(Base 10): " + base10AdressP1 + "." + base10AdressP2 + "." + base10AdressP3 + "." + base10AdressP4);
            }

            // Methode to print the objects base 2 IP-Adress to the console
            public void printBase2Adress()
            {
                Console.WriteLine("IP-Adress(Base 2): " + Convert.ToString(base2AdressP1) + "." + Convert.ToString(base2AdressP2) + "." + Convert.ToString(base2AdressP3) + "." + Convert.ToString(base2AdressP4));
            }


            // Fetches the current Adapters IPv4 Adress
            public _IPAddress getCurIP()
            {
                var localHost = Dns.GetHostEntry(Dns.GetHostName());
                _IPAddress myIPAdress = new _IPAddress();

                foreach (var ip in localHost.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        myIPAdress.base10AdressP1 = ip.ToString()[0-2];
                        myIPAdress.base10AdressP2 = ip.ToString()[3-5];
                        myIPAdress.base10AdressP3 = ip.ToString()[6-8];
                        myIPAdress.base10AdressP4 = ip.ToString()[9-11];

                        return myIPAdress;
                    }
                }
                throw new Exception("No network adapters with an IPv4 address in the system!");
            }
            
            /*
            public IPAddress getNetworkadress(IPAddress adress, IPAddress networkmask)
            {
                IPAddress networkAdress = new IPAdress((int) adress.adressP1 & networkmask.adressP1, ;
                return networkAdress;
            }
            */
        }

        // Class Subnet für Aufgabe 4.4
        class Subnet
        {
            public Subnet() { }

            public Subnet(decimal P1, decimal P2, decimal P3, decimal P4)
            {
                base10SubAdressP1 = P1;
                base10SubAdressP2 = P2;
                base10SubAdressP3 = P3;
                base10SubAdressP4 = P4;

                // Convert dec to byte
                base2SubAdressP1 = Convert.ToByte(P1);
                base2SubAdressP2 = Convert.ToByte(P2);
                base2SubAdressP3 = Convert.ToByte(P3);
                base2SubAdressP4 = Convert.ToByte(P4);
            }

            public decimal base10SubAdressP1 { get; set; }
            public decimal base10SubAdressP2 { get; set; }
            public decimal base10SubAdressP3 { get; set; }
            public decimal base10SubAdressP4 { get; set; }
            public byte base2SubAdressP1 { get; set; }
            public byte base2SubAdressP2 { get; set; }
            public byte base2SubAdressP3 { get; set; }
            public byte base2SubAdressP4 { get; set; }

            public void askSubnet()
            {
                Console.WriteLine("Geben Sie den 1. Teil der Subnet Adresse ein (Dezimal): ");
                base10SubAdressP1 = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Geben Sie den 2. Teil der Subnet Adresse ein (Dezimal): ");
                base10SubAdressP2 = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Geben Sie den 3. Teil der Subnet Adresse ein (Dezimal): ");
                base10SubAdressP3 = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Geben Sie den 4. Teil der Subnet Adresse ein (Dezimal): ");
                base10SubAdressP4 = Convert.ToDecimal(Console.ReadLine());
            }

            // ToDo: print subnet base 2 and base 10

            public void printSubnet()
            {
                Console.WriteLine("Subnet-Adress: " + base10SubAdressP1 + "." + base10SubAdressP2 + "." + base10SubAdressP3 + "." + base10SubAdressP4);
            }
        }

        // Aufgabe 4.4
        static void Subnetting()
        {
            _IPAddress AD1 = new _IPAddress();
            _IPAddress AD2 = new _IPAddress();
            Subnet SN1 = new Subnet();

            // Eingabe der Adressen + Kontroll Ausgabe
            Console.WriteLine("Bitte geben Sie die erste Adresse ein: ");
            AD1.askIPAdress();
            Console.WriteLine("Ihre Eingabe: ");
            AD1.printBase10Adress();
            AD1.printBase2Adress();
            Console.WriteLine("\n");

            Console.WriteLine("Bitte geben Sie die zweite Adresse ein: ");
            AD2.askIPAdress();
            Console.WriteLine("Ihre Eingabe: ");
            AD2.printBase10Adress();
            AD2.printBase2Adress();
            Console.WriteLine("\n");

            Console.WriteLine("Geben Sie die Subnet Maske ein: ");
            SN1.askSubnet();
            Console.WriteLine("Ihre Eingabe: ");
            SN1.printSubnet();
            Console.WriteLine("\n");

            _IPAddress firstNWA = new _IPAddress(
            Convert.ToString(Convert.ToInt32(AD1.base2AdressP1, 2) & Convert.ToInt32(SN1.base2SubAdressP1), 2),
            Convert.ToString(Convert.ToInt32(AD1.base2AdressP2, 2) & Convert.ToInt32(SN1.base2SubAdressP2), 2),
            Convert.ToString(Convert.ToInt32(AD1.base2AdressP3, 2) & Convert.ToInt32(SN1.base2SubAdressP3), 2),
            Convert.ToString(Convert.ToInt32(AD1.base2AdressP4, 2) & Convert.ToInt32(SN1.base2SubAdressP4), 2));

            _IPAddress secondNWA = new _IPAddress(
            Convert.ToString(Convert.ToInt32(AD2.base2AdressP1, 2) & Convert.ToInt32(SN1.base2SubAdressP1), 2),
            Convert.ToString(Convert.ToInt32(AD2.base2AdressP2, 2) & Convert.ToInt32(SN1.base2SubAdressP2), 2),
            Convert.ToString(Convert.ToInt32(AD2.base2AdressP3, 2) & Convert.ToInt32(SN1.base2SubAdressP3), 2),
            Convert.ToString(Convert.ToInt32(AD2.base2AdressP4, 2) & Convert.ToInt32(SN1.base2SubAdressP4), 2));

            // Ausgabe der Subnetz Adressen
            Console.WriteLine("Die 1. Netzadresse (Base 10) lautet: ");
            firstNWA.printBase10Adress();
            Console.WriteLine("\n");

            Console.WriteLine("Die 1. Netzadresse (Base 2) lautet: ");
            firstNWA.printBase2Adress();
            Console.WriteLine("\n");

            Console.WriteLine("Die 2. Netzadresse (Base 10) lautet: ");
            secondNWA.printBase10Adress();
            Console.WriteLine("\n");

            Console.WriteLine("Die 2. Netzadresse (Base 2) lautet: ");
            secondNWA.printBase2Adress();
            Console.WriteLine("\n");

            // Ausgabe vergleich der Netzwerkadressen
            if (firstNWA.base10AdressP1 == secondNWA.base10AdressP1 && firstNWA.base10AdressP2 == secondNWA.base10AdressP1 &&
                firstNWA.base10AdressP3 == secondNWA.base10AdressP3 && firstNWA.base10AdressP4 == secondNWA.base10AdressP4)
            {
                Console.WriteLine("Die eingegebenen Adressen befinden sich im gleichen Subnet!");
            }
            else Console.WriteLine("Die eingegebenen Adressen befinden sich nicht im gleichem Subnet!");

        }

        static void Main(string[] args)
        {
            DivRest(11, 3);         // Return should be 2
            BitShiftMultiplier();   // Multiplies an input with 2, 4 and 32
            Subnetting();           // Calcs a Networkadress with IPAdress and Subnet Adress -> Tells the user if the two input ip adresses are in the same subnet
             
            Console.ReadLine();
        }

    }
}
