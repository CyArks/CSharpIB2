using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Init a new Person object and set the properties via the setter methods
            Person myPerson = new Person();
            myPerson.setName("Florian");
            myPerson.setAge(19);
            myPerson.setHeight(183);

            // Init a new bank Account and set the Account property of the Person object
            Account myAccount = new Account("AT34 3400 2000 00002 9775", 111, 0.75);
            myPerson.setAccount(myAccount);

            // Print some of the properties
            Console.WriteLine("Name: " + myPerson.getName());
            Console.WriteLine("Age: " + myPerson.getAge());
            Console.WriteLine("Height: " + myPerson.getHeight());
            Console.WriteLine("Saldo: " + myPerson.GetAccount().getSaldo());
            Console.WriteLine("\n\n");

            // ------------------------------------------------------------------

            // Init a second Person for demonstrating the payment process
            Person secPerson = new Person();
            secPerson.setName("Simone");
            secPerson.setAge(23);
            secPerson.setHeight(153);

            Account secAccount = new Account("AT56 3800 2400 00002 6770", 750, 0.55);
            secPerson.setAccount(secAccount);

            // Print some of the properties
            Console.WriteLine("Name: " + secPerson.getName());
            Console.WriteLine("Age: " + secPerson.getAge());
            Console.WriteLine("Height: " + secPerson.getHeight());
            Console.WriteLine("Saldo: " + secPerson.GetAccount().getSaldo());
            Console.WriteLine("\n\n");

            // ------------------------------------------------------------------

            // Make a payment
            secPerson.GetAccount().makePayment(myPerson.GetAccount(), 25);
            Console.WriteLine("Saldo (" + secPerson.getName() + ") - " + secPerson.GetAccount().getKontoID() + ": \t" + secPerson.GetAccount().getSaldo() + " Euro");
            Console.WriteLine("Saldo (" + myPerson.getName() + ") - " + myPerson.GetAccount().getKontoID() + ": \t" + myPerson.GetAccount().getSaldo() + " Euro");
            Console.WriteLine("\n\n");

            // Call the spellSaldo function to spell the saldo
            Console.WriteLine(myPerson.getName() + " has a Saldo of: ");
            myPerson.GetAccount().SpellSaldo();

            Console.ReadLine();


        }
    }
}
