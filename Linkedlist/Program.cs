using System;
using System.IO;

namespace Zadatak_01
{
    class Program
    {
        static Student Unos()
        {
            Student novi = new();
            System.Console.Write("Unesite ime: ");
            novi.ime = Console.ReadLine();

            System.Console.Write("Unesite prezime: ");
            novi.prezime = Console.ReadLine();

            System.Console.Write("Unesite grupu: ");
            novi.grupa = Console.ReadLine();

            System.Console.Write("Unesite bodovi: ");
            int br;
            bool ok = int.TryParse(Console.ReadLine(), out br);
            novi.bodovi = br;

            return novi;
        }


        static void Spremi(VezanaLista vl)
        {
            Console.Write("Upišite ime datoteke: ");
            string imeDat = Console.ReadLine();

            // spremi podatke u datoteku!
            using (StreamWriter se = new(imeDat))
            {
                foreach (Student el in vl)
                {
                    se.WriteLine($"{el.ime}#{el.prezime}#{el.grupa}#{el.bodovi}");
                }
            }

            Console.Clear();
            Console.WriteLine("Spremljeno!");
        }

        static void Ucitaj(VezanaLista vl)
        {
            // isprazni listu!
            vl.Clear();
            Console.Write("Upišite ime datoteke: ");
            string imeDat = Console.ReadLine();

            if (!File.Exists(imeDat))
            {
                Console.WriteLine($"Datoteka '{imeDat}' nije pronađena u: {Directory.GetCurrentDirectory()}");
                return;
            }

            // spremi podatke u datoteku
            using (StreamReader sr = new(imeDat))
            {
                string linija = sr.ReadLine();
                while (linija != null)
                {
                    string[] niz = linija.Split('#');
                    Student s = new();
                    s.ime = niz[0];

                    s.prezime = niz[1];

                    s.grupa = niz[2];

                    s.bodovi = int.Parse(niz[3]);
                    vl.AddSort(s);
                    linija = sr.ReadLine();
                }
            }

        }

        static void Main(string[] args)
        {
            VezanaLista studenti = new VezanaLista();

            string izbor = "";
            do
            {
                Console.WriteLine("IZBORNIK:");
                Console.WriteLine("0. Ispis");
                Console.WriteLine("1. Unos podataka");
                Console.WriteLine("2. Spremi u datoteku");
                Console.WriteLine("3. Učitaj iz datoteke");
                Console.WriteLine("4. Brisi sve");
                Console.WriteLine("5. Brisi jednog");
                Console.WriteLine("9. Kraj");

                Console.Write("---> ");
                izbor = Console.ReadLine();

                switch (izbor)
                {
                    case "0":
                        // ispis svih
                        System.Console.WriteLine(studenti.Izlaz());
                        break;
                    case "1":
                        //unos 1
                        studenti.AddSort(Unos());
                        break;
                    case "2":
                        // spremi
                        Spremi(studenti);
                        break;
                    case "3":
                        // učitaj
                        Ucitaj(studenti);
                        break;
                    case "4":
                        // učitaj
                        studenti.BrisiSve(studenti);
                        break;
                    case "5":
                        // učitaj
                        studenti.BrisiJednog(studenti);
                        break;
                    default:
                        //ne radi ništa
                        break;
                }
            } while (izbor != "9" && izbor != "");

            Console.WriteLine("Kraj...");
        }
    }
}