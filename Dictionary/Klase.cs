namespace SPA_2324_T1
{
    // ovdje pišete sve potrebne klase!    
    class Radnik
    {
        public string ime, grad;
        public int godine_staza;
        public double stanje_racuna;
    }

    class Rjecnik : Dictionary<string,Radnik>
    {
        public List<string> TraziBroj(int br)
        {
            List<string> trazi = new();
            foreach (string item in this.Keys)
            {
                Radnik r = this[item];
                if (r.stanje_racuna > br)
                {
                    trazi.Add(r.ime);
                }
            }

            return trazi;
        }
    }
}