using System.Collections;

namespace SPA_2324_T1
{
    // ovdje pišete sve potrebne klase!    
    class Radnik{
        public string ime, grad;
        public int godina_staza;
        public double stanje_racuna;

    }

class HashTablica : Hashtable
{

    public void BrisiGrad(string grad)
    {
        List<string> listaBrisi = new();
        foreach (string el in this.Keys)
        {
            Radnik rad = (Radnik)this[el];
            if (rad.grad == grad)
            {
                listaBrisi.Add(el);
            }
        }
        System.Console.WriteLine(listaBrisi.Count);
        foreach (string k in listaBrisi)
        {
            this.Remove(k);
        }
    }

    public List<string> TraziRadnika(int br)
    {
        List<string> listaTrazi =  new();
        foreach (string k in this.Keys)
        {
            Radnik r = (Radnik)this[k];
            if (r.stanje_racuna > br)
            {
                listaTrazi.Add(k);
            }
        }
        return listaTrazi;
    }
}
}