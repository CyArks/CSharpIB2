using System;

namespace UML_Aufgabe
{
    internal class Room
    {
        private int roomNumber;
        private int roomCapacity;

        public Room(int roomNumber, int capacity) 
        { 
            this.roomNumber = roomNumber;
            this.roomCapacity = capacity;
        }

        public int getRoomNumber()
        {
            return roomNumber;
        }

        public int getRoomCapacity()
        {
            return roomCapacity;
        }
    }

    internal class Person
    {
        private string name;
        private DateTime birthday;

        public Person()
        {
            string? inputStream = null;

            do
            {
                Console.WriteLine("Please enter your name: ");
                inputStream = Console.ReadLine();
            } while (inputStream == null);

            this.name = inputStream;

            do
            {
                Console.WriteLine("Please enter your birtdate: ");
                inputStream = Console.ReadLine();

                if (inputStream == null) continue;

                try 
                {
                    this.birthday = DateTime.Parse(inputStream);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error while parsing birthday string to DateTime! Wrong format!");
                    Console.WriteLine(exception.Message);
                }

            } while (inputStream == null);

        }

        public Person(string name, string birthday) 
        {
            var parsedDate = DateTime.Parse(birthday);

            this.name = name;
            this.birthday = parsedDate.Date;
        }

        public int getAge()
        {
            DateTime dateTimeNow = DateTime.Now;

            if (birthday.Month == dateTimeNow.Month) if (birthday.Day <= dateTimeNow.Day)
            {
                return dateTimeNow.Year - birthday.Year + 1;
            }

            if (birthday.Month > dateTimeNow.Month)
            {
                return dateTimeNow.Year - birthday.Year + 1;
            }

            return dateTimeNow.Year - birthday.Year;
        }

        public string getName()
        {
            return name;
        }
    }

    internal class School
    {
        private string name;
        private string location;
        private List<Room> roomList;
        private List<Person> personList;

        public School(string name, string location) 
        {
            this.name = name;
            this.location = location;
            this.roomList = new List<Room>();
            this.personList = new List<Person>();
        }

        public string getLocation() 
        { 
            return location;
        }

        public void printAllPersons()
        {
            int i = 0;

            foreach (Person person in personList)
            {
                Console.WriteLine("Person[" + i + "]: " + person.getName());
                i++;
            }
        }

        public void addPerson(Person person)
        {
            personList.Add(person);
        }

        public void addRoom(Room room)
        {
            roomList.Add(room);
        }

    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Person student = new Person("Florian Manhartseder", "05.12.2004");
            Console.WriteLine("Student[" + student.getName() + "] is: " + Convert.ToString(student.getAge() + " years old."));

            Person newPers = new Person();
            Console.WriteLine("Student[" + student.getName() + "] is: " + Convert.ToString(student.getAge() + " years old."));

            Room ITClass = new Room(105, 24);
            Console.WriteLine("The room " + Convert.ToString(ITClass.getRoomNumber()) + " has a capacity of " + Convert.ToString(ITClass.getRoomCapacity()));

            School mySchool = new School("LBS4", "Schiessstattstraße 14");
            mySchool.addPerson(student);
            mySchool.addPerson(newPers);
            mySchool.addRoom(ITClass);
            mySchool.printAllPersons();
        }
    }

}
