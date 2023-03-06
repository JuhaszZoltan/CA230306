using CA230306;
using System.Text;

Feladat01();
Feladat02();
Feladat03();

Console.ReadKey(true);

static void Feladat01()
{
    Random rnd = new();
    Console.Write("1. feladat: ");
    for (int j = 0; j < 6; j++)
    {
        int n = rnd.Next(3, 11);
        for (int i = 0; i < n; i++) Console.Write('*');
        Console.Write(' ');
    }
}
static void Feladat02()
{
    Console.WriteLine("\n\n2. feladat:");
    Console.Write("Írja be a szöveget: ");
    string szoveg = Console.ReadLine();

    szoveg = szoveg.ToLower();

    string ek = "áéíóöőúüű";
    string em = "aeiooouuu";
    for (int i = 0; i < ek.Length; i++)
        szoveg = szoveg.Replace(ek[i], em[i]);

    string specs = ",:;.!?";
    foreach (char sc in specs)
        szoveg = szoveg.Replace(sc, '\0');

    string[] szavak = szoveg.Split();
    szoveg = szavak[0];
    for (int i = 1; i < szavak.Length; i++)
    {
        szoveg += $"{szavak[i][0]}".ToUpper();
        szoveg += szavak[i][1..];
    }

    Console.WriteLine($"camelCase változat: {szoveg}");
}
static void Feladat03()
{
    List<Egitest> egitestek = new();
    using StreamReader sr = new("..\\..\\..\\src\\egitestek.txt", Encoding.UTF8);
    while (!sr.EndOfStream) egitestek.Add(new Egitest(sr.ReadLine()));

    Console.WriteLine($"\n3.1. feladat: {egitestek.Count} égitest van az állományban");

    //int f32 = 0;
    //foreach (var e in egitestek)
    //    if (e.HolKering == "Nap")
    //        f32++;
    int f32 = egitestek.Count(e => e.HolKering == "Nap");
    Console.WriteLine($"3.2. feladat: {f32} égitest kering a Nap körül");

    //int f33 = 0;
    //for (int i = 1; i < egitestek.Count; i++)
    //    if (egitestek[i].Tavolsag < egitestek[f33].Tavolsag)
    //        f33 = i;
    //Console.WriteLine($"3.3. feladat: {egitestek[f33].Elnevezes} " +
    //$"kering a legközelebb a bolygólyához");

    Egitest f33 = egitestek.MinBy(e => e.Tavolsag);
    Console.WriteLine($"3.3. feladat: {f33.Elnevezes} " +
    $"kering a legközelebb a bolygólyához");

    //List<string> f34 = new();
    //foreach (var e in egitestek)
    //    if (!e.Direktirany) f34.Add(e.Elnevezes);

    var f34 = egitestek
        .Where(e => !e.Direktirany)
        .Select(e => e.Elnevezes);
    Console.WriteLine("3.4. feladat: a Földével ellentétes keringési irányú égitestek:");
    foreach (var en in f34) Console.WriteLine($"\t- {en}");

    Console.Write("3.5. feladat: írja be az égitest nevét: ");
    string f35 = Console.ReadLine();
    //int i = 0;
    //while (i < egitestek.Count && egitestek[i].Elnevezes != f35) i++;
    //if (i < egitestek.Count)
    //{
    //    if (egitestek[i].FelfedezoNeve is not null && egitestek[i].FelfedezesEve is not null)
    //    {
    //        Console.WriteLine($"\tfelfedező neve: {egitestek[i].FelfedezoNeve}");
    //        Console.WriteLine($"\tfelfedezés éve: {egitestek[i].FelfedezesEve}");
    //    }
    //    else Console.WriteLine($"\ta(z) {f35} szerepel a listában\n" +
    //        $"\tde felfedezésének körülményeiről nincs adat");
    //}
    //else Console.WriteLine($"\ta(z) {f35} nem szerepel a listában");

    var f35e = egitestek.FirstOrDefault(e => e.Elnevezes == f35);
    if (f35e is null) Console.WriteLine("nincs találat");
    else if (f35e.FelfedezesEve is null && f35e.FelfedezoNeve is null)
        Console.WriteLine("benne van, de nem tudjuk");
    else Console.WriteLine($"{f35e.FelfedezoNeve}\n{f35e.FelfedezesEve}");
}