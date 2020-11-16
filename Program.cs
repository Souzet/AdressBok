using System;
using System.Collections.Generic;
using System.IO;
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
            public Person(string N, string A, string T, string E)
            {
                name = N; adress = A; telefon = T; Email = E;
            }
            public void Print()
            {
                Console.WriteLine(
                $"{name} adress:{adress}, tel:{telefon}, Email:{Email}");
            }
        }
        static void Main(string[] args)
        {
            List<Person> addressList = new List<Person>();
            Console.WriteLine("Hej och vällkommen till Adressbok");
            Console.WriteLine("skriv sluta för att sluta");
            string fileAdressBok = @"C:\Users\souzet\Documents\Adressbok.txt";

            string command; /*= Console.ReadLine();*/
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                if (command == "sluta")
                {
                    Console.WriteLine("Adjö");
                }
                else if (command == "load")
                {
                    Console.Write("Ange filnamn: ");
                    string adressBok = Console.ReadLine();
                    using (StreamReader file = new StreamReader(adressBok))
                    {
                        while (file.Peek() >= 0)
                        {
                            string line = file.ReadLine();
                            Console.WriteLine(line);
                            string[] words = line.Split('#');
                            Person P = new Person(words[0], words[1], words[2], words[3]);
                            addressList.Add(P);
                        }
                    }
                }
                else if (command == "ny person")
                {
                    Console.WriteLine("Skriv förnamn och efternamn: ");
                    string nameOne = Console.ReadLine();
                    Console.WriteLine("Skriv adress till " + nameOne);
                    string telOne = Console.ReadLine();
                    Console.WriteLine("Skriv tel. till " + nameOne);
                    string adressOne = Console.ReadLine();
                    Console.WriteLine("Skriv E-mail till " + nameOne);
                    string mailOne = Console.ReadLine();
                    Console.WriteLine(nameOne + adressOne + telOne + mailOne);
                    Person P = new Person(nameOne, adressOne, telOne, mailOne);
                    addressList.Add(P);
                }
                else if (command == "visa")
                {
                    for (int i = 0; i < addressList.Count(); i++)
                    {
                        addressList[i].Print();
                    }
                }

                else if (command == "spara")
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(fileAdressBok))
                        {
                            for (int i = 0; i < addressList.Count(); i++)
                            {
                                Person P = addressList[i];
                                sw.WriteLine($"{P.name}#{P.adress}#{P.telefon}#{P.Email}");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
                else if (command == "ta bort")
                {
                    Console.WriteLine(" Vilket namn vill du ta bort:   ");
                    string delete = Console.ReadLine();
                    int found = -1;
                    for (int i = 0; i < addressList.Count(); i++)
                    {
                        if (addressList[i].name == delete)
                        {
                            found = i;
                        }
                    }
                    if (found != -1)
                    {
                        addressList.RemoveAt(found);
                    }
                    else
                    {
                        Console.WriteLine($"Kunde inte hitta {delete}");
                    }
                }
                else
                {
                    Console.WriteLine("Okänt kommando: {0}", command);
                }
            }
            while (command != "sluta");

        }

    }
}
