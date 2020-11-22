using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning_2ra_Kod
{
    class Program
    {
        /* CLASS: Person
         * PURPOSE: CREAT A NEW CONTACT IN THE ADDRESS BOOK*/
        class Person
        {
            public string name, adress, telefon, Email;
            /* METHOD: PERSON
            * PURPOSE: CREATE A PERSON
            * PARAMETERS: PERSON NAME, PERSON ADDRESS, PERSON PHONE, PERSON EMAIL
            * RETURN VALUE: RETURN A PERSON BUILDING WITH 4 PARAMETERS*/
            public Person(string N, string A, string T, string E)
            {
                name = N; adress = A; telefon = T; Email = E;
            }
            /* METHOD: PRINT
            * PURPOSE: SHOW A PERSON INFORMATION
            * PARAMETERS: EMPTY
            * RETURN VALUE: SHOW A PERSON BY CLASS PERSON PROPERTIES*/            
        }
        static void Main(string[] args)
        {
            List<Person> addressList = new List<Person>();
            Console.WriteLine("Hej och vällkommen till Adressbok");
            Console.WriteLine("skriv sluta för att sluta");
            string fileAdressBok = @"C:\Users\souzet\Documents\Adressbok.txt";
            string command;
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
                    AddPerson(addressList);
                }
                else if (command == "visa")
                {
                    PrintPerson(addressList);
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

                    DeletPerson(addressList);
                }
                else
                {
                    Console.WriteLine("Okänt kommando: {0}", command);
                }
            }
            while (command != "sluta");
        }
        /* CONSTRUCTOR: AddPerson  STATIC
         * PURPOSE: ASK USER TO ENTER NEW PERSON INFO
         */
        static void AddPerson(List<Person> addressList)
        {
            Console.WriteLine(" Skriv den nya person");
            Console.Write(" ange namn:    ");
            string name = Console.ReadLine();
            Console.Write("  ange adress:    ");
            string telefon = Console.ReadLine();
            Console.Write("  ange telefon:   ");
            string adress = Console.ReadLine();
            Console.Write("  ange email   ");
            string email = Console.ReadLine();
            addressList.Add(new Person(name, adress, telefon, email));
        }
        /* METHOD: DeletPerson  STATIC
         * PURPOSE: DELETE AII INFO THAT USER INDICATE IT BY NAME
         * PARAMETERS: DELETE FROM List<Person>addressList
         * RETURN VALUE: UPPDATING List<Person>addressList
         */
        static void DeletPerson(List<Person> addressList)
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
        /* Method: PrintPerson   STATIC
         * PURPOSE: SHOW A PERSON INFORMATION 
         * PARAMETERS: EMPTY
         * RETURN VALUE: EMPTY
         */
        static void PrintPerson(List<Person> addressList)
        {
            for (int i = 0; i < addressList.Count(); i++)
            {
                Person T = addressList[i];
                Console.WriteLine("{0}, {1}, {2}, {3}" ,T.name, T.adress, T.telefon, T.Email);
            }
        }
        /* Method: ChangePerson   STATIC
         * PURPOSE: INSERT A NEW INFO TO CURRENT PERSON 
         * PARAMETERS: string ToChange WHICH PERSON WANTS USER TO DO CHANGE IN IT
         *             string FieldToChange THE FIELD IN PERSON THAT USER WANTS TO CHANGE
         *             string NewValue
         * RETURN VALUE: EMPTY
         */
        static void ChangePerson(List<Person> addressList)
        {
            Console.Write("Ange namn som du vill ändra:  ");
            string ToChange = Console.ReadLine();
            int find = -1;
            for (int i = 0; i < addressList.Count(); i++)
            {
                if (addressList[i].name == ToChange)
                    find = 1;
            }
            if (find == -1)
            {
                Console.WriteLine($"Kunde inte hitta {0}", ToChange);
            }
            else
            {
                Console.Write("Vad vill du ändra (namn, adress, telefon, email): ");
                string FToChange = Console.ReadLine();
                Console.Write("Änge den nya ändring på {0}: ", FToChange);
                string NewValue = Console.ReadLine();
                switch (FToChange)
                {
                    case "name":
                        addressList[find].name = NewValue;
                        break;
                    case "adress":
                        addressList[find].adress = NewValue;
                        break;
                    case "telefon":
                        addressList[find].telefon = NewValue;
                        break;
                    case "email":
                        addressList[find].Email = NewValue;
                        break;
                    default: break;
                }
            }
        }
    }
}
