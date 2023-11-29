using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Person
    {
        private int _age { get; set; }
        private int _height { get; set; }
        private string _name { get; set; }
        private Account _BankAccount { get; set; }

        public Person(int age, int height, string name)
        {
            this._age = age;
            this._height = height;
            this._name = name;
        }

        // Constructor
        public Person() { }

        // Destructor
        ~Person() { }

        public int setAge(int age)
        {
            if (age >= 0 && age <= 120)
            {
                _age = age;
                return 0;
            }
            else
            {
                throw new Exception("Age not in range (0-120)!");
            }
        }

        public int getAge() { return _age;}

        public int setName(string name) 
        {
            if (name.Length <= 75 && name.Length >= 3)
            {
                _name = name;
                return 0;
            }
            else return 1;
        }

        public string getName() { return _name;}

        public int setHeight(int height)
        {
            if (height >= 40 && height <= 250)
            {
                _height = height;
                return 0;
            }
            else return 1;
        }

        public int getHeight() { return _height;}

        public void setAccount(Account bankAccount)
        {
            _BankAccount = bankAccount;
        }

        public Account GetAccount() { return _BankAccount;}

    }
}
