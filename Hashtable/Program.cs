using System;
using System.Collections.Generic;
using System.IO;
using SPA_2324_T1;

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


}
class Program
{
    // ovdje možete pisati dodatne metode ako je potrebno
    static void Ucitaj(HashTablica ht)
    {
        System.Console.WriteLine("Unesite ime dat: ");
        string imeDat = Console.ReadLine();
        if (!File.Exists(imeDat))
        {
            Console.WriteLine($"Datoteka '{imeDat}' nije pronađena u: {Directory.GetCurrentDirectory()}");
            return;
        }
        using (StreamReader sr = new(imeDat))
        {
            string linija = sr.ReadLine();
            while (linija != null)
            {
                string[] niz = linija.Split(';');
                Radnik r = new();

                r.ime = niz[0];
                r.godina_staza = int.Parse(niz[1]);
                r.stanje_racuna = double.Parse(niz[2]);
                r.grad = niz[3];

                if (ht.ContainsKey(r.ime))
                {
                    System.Console.WriteLine(r.ime);
                }
                else
                {
                    ht.Add(r.ime, r);
                }
                linija = sr.ReadLine();

            }
        }
    }

    static string Ispis(HashTablica ht)
    {
        string txt = "";
        foreach (string k in ht.Keys)
        {
            Radnik r = (Radnik)ht[k];
            txt += $"{r.ime} {r.godina_staza} {r.stanje_racuna} {r.grad}\n";
        }
        return txt;
    }


    static void Main(string[] args)
    {
        HashTablica ht = new();

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
                    Ucitaj(ht);
                    System.Console.WriteLine(ht.Count);
                    break;

                case "2":
                    System.Console.WriteLine(Ispis(ht));
                    break;

                case "3":
                    System.Console.WriteLine("Unesite ime grada: ");
                    string unos = Console.ReadLine();
                    ht.BrisiGrad(unos);

                    break;

                case "4":
                    System.Console.WriteLine("Unesite trazeno stanje racuna: ");
                    int br;
                    bool ok = int.TryParse(Console.ReadLine(), out br);
                    if (ok)
                    {
                        List<string> lista_Trazi = ht.TraziRadnika(br);
                        System.Console.WriteLine(lista_Trazi.Count);
                        foreach (string el in lista_Trazi)
                        {
                            Radnik rad = (Radnik)ht[el];
                            System.Console.WriteLine($"{rad.ime} {rad.stanje_racuna}");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Pogresan unos, trazi se cijeli broj!");
                    }
                    break;

                case "9":
                    break;

                default:
                    break;
            }
        } while (izbor != "9");
    }
}
