namespace CA230306
{
    internal class Egitest
    {
        public string HolKering { get; set; }
        public string Elnevezes { get; set; }
        public int Tavolsag { get; set; }
        public bool Direktirany { get; set; }
        public int Atmero { get; set; }
        public string? FelfedezoNeve { get; set; }
        public int? FelfedezesEve { get; set; }

        public Egitest(string sor)
        {
            var v = sor.Split(';');
            HolKering = v[0];
            Elnevezes = v[1];
            Tavolsag = int.Parse(v[2]);
            Direktirany = v[3] == "1";
            Atmero = int.Parse(v[4]);
            FelfedezoNeve = v[5] == "---" ? null : v[5];
            FelfedezesEve = v[6] == "0000" ? null : int.Parse(v[6]);
        }
    }
}
