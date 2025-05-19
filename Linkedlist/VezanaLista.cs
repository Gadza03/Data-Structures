using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadatak_01
{
    class Student
    {
        public string ime, prezime, grupa;
        public int bodovi;
    }
    class VezanaLista : LinkedList<Student>
    {
        // napisati metodu Izlaz koja ne prima ništa
        // vraća string - svi podaci o svim studentima u listi

        
        public string Izlaz()
        {
            string txt = "";
            int i = 1;
            foreach (Student el in this)
            {
                txt += $"{i} {el.ime} {el.prezime} {el.grupa} ({el.bodovi})\n";
                i++;
            }
            return txt;
        }
        

        public void AddSort(Student s)
        {
            if (this.Count == 0)
            {
                this.AddLast(s);
                return;
            }
            LinkedListNode<Student> temp = this.First;

            while (temp != null)
            {
                if (temp.Value.bodovi < s.bodovi)
                {
                    this.AddBefore(temp, s);
                    return;
                }
                temp = temp.Next;
            }
            this.AddLast(s);



        }

        public void BrisiSve(VezanaLista vl)
        {
            this.Clear();
            return;
        }

        public void BrisiJednog(VezanaLista vl)
        {
            System.Console.WriteLine("Unesi redni broj studenta: ");
            int br;
            bool ok = int.TryParse(Console.ReadLine(), out br);

            int rb = br;
            Student s;
            try
            {
                s = vl.ElementAt(rb - 1);
                vl.Remove(s);
                System.Console.WriteLine($"Izbrisan je student/ica {s.ime} {s.prezime} {s.grupa}");
            }
            catch 
            {
                System.Console.WriteLine("Ne postoji broj!");                
            }
        }
    }
}