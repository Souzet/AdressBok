using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBok
{
    class Program
    {
        class Person
        {
            public string name, adress, telefon, Email;
            string AdressBok = @"‪C: \Users\souzet\Documents\Adressbok.txt";

            public Person(string N, string A, string T, string E)
            {
                 name = N; adress = A; telefon = T; Email = E;
            }
            public void Print()
            {
                Console.WriteLine(
                $"{name} adress:{adress}, tel:{telefon}, Email:{Email}");
            }            
            //public string AdressBok()
        }

        static void Main(string[] args)
        {
            Console.WriteLine(" Hej och vällkommen till Adressboken");
            Console.WriteLine("skriv sluta för att sluta");
            string command; /*= Console.ReadLine();*/
            do
            {
                Console.WriteLine("> ");
                command = Console.ReadLine();
                if (command == "sluta")
                {
                    Console.WriteLine("Adjö");
                }

            }
            while

        }

        //Person One = new Person("Souzet Tadros, Nelinsgatan 1, 60345 Norrköping, souzettadros@gmail.com");
        //One.Print();














    }
}
