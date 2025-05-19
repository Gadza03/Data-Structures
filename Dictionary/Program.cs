using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Http.Headers;

/*
using (StreamReader sr = File.OpenText(imeDat))
    {
        string linija;
        while ((linija = sr.ReadLine()) != null)
        {
        }
    }
*/

namespace SPA_2324_T1
{
    class Program
    {
        // ovdje možete pisati dodatne metode ako je potrebno

        static void Ucitaj(Rjecnik rj)
        {
            System.Console.WriteLine("Unesite ime dat: ");
            string imeDat = Console.ReadLine();
            if (!File.Exists(imeDat))
            {
                System.Console.WriteLine("Ne postoji dat!");
                return;
            }
            using (StreamReader sr = new(imeDat))
            {
                string linija;
                while ((linija = sr.ReadLine()) != null)
                {
                    string[] niz = linija.Split(";");
                    Radnik r = new();
                    r.ime = niz[0];
                    r.godine_staza = int.Parse(niz[1]);
                    r.stanje_racuna = double.Parse(niz[2]);
                    r.grad = niz[3];

                    if (rj.ContainsKey(r.ime))
                    {
                        System.Console.WriteLine(r.ime);
                    }
                    else
                    {
                        rj.Add(r.ime,r);
                    }

                }

            }
        }


        static string Ispis(Rjecnik rj)
        {
            string txt = "";
            int i = 1;
            foreach (string el in rj.Keys)
            {
                Radnik r = rj[el];
                txt += $"{i}. {r.ime} {r.godine_staza} {r.stanje_racuna} {r.grad}\n";
                i++;
            }
            return txt;
        }


        static void BrisiGrad(Rjecnik rj)
        {
            System.Console.WriteLine("Unesite grad za brisanje: ");
            string unos = Console.ReadLine();
            List<string> brisi = new List<string>();
            foreach (string item in rj.Keys)
            {
                Radnik r = rj[item];
                if (r.grad.ToLower() == unos.ToLower())
                {
                    brisi.Add(unos);
                }
            }

            foreach (string el in brisi)
            {
                if (rj.ContainsKey(el))
                {
                    rj.Remove(el);
                }
            }
            System.Console.WriteLine(brisi.Count);
        }
        static void Main(string[] args)
        {   
            Rjecnik rijecnik = new();

            string izbor = "";
            do
            {
                Console.WriteLine("Izbornik:");
                Console.WriteLine("1. Unos");
                Console.WriteLine("2. Ispis");
                Console.WriteLine("3. Brisanje");
                Console.WriteLine("4. Pretraga");
                Console.WriteLine("9. Kraj");

                Console.WriteLine("Unesite izbor:");
                izbor = Console.ReadLine();

                switch (izbor)
                {
                    case "1":   
                        Ucitaj(rijecnik);
                        System.Console.WriteLine(rijecnik.Count);
                        break;

                    case "2":
                        System.Console.WriteLine(Ispis(rijecnik));

                        break;

                    case "3":
                        BrisiGrad(rijecnik);
                        break;

                    case "4":
                        System.Console.WriteLine("Unesite broj za pretragu: ");
                        int br;
                        bool ok = int.TryParse(Console.ReadLine(), out br);
                        List<string> lista;
                        if (ok)
                        {
                            lista = rijecnik.TraziBroj(br);
                        }
                        else
                        {
                            System.Console.WriteLine("Pogrsan unos!");
                            return;
                        }

                        foreach (string el in lista)
                        {
                            if (rijecnik.ContainsKey(el))
                            {
                                Radnik r = rijecnik[el];
                                System.Console.WriteLine($"{r.ime} {r.stanje_racuna}");
                            }
                        }
                        System.Console.WriteLine(lista.Count);
                        break;

                    case "9":
                        break;

                    default:
                        break;
                }
            } while (izbor != "9");
        }
    }
}