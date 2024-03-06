using KricsfalusiDavid_valasztas;

Valasztas valasztas = new Valasztas();
valasztas.Beolvasas("szavazatok.txt");

valasztas.KepviseloSzam();

Console.Write("3. feladat: Adja meg egy képviselőjelölt vezetéknevét: ");
string vezeteknev = Console.ReadLine();
Console.Write("3. feladat: Adja meg egy képviselőjelölt utónevét: ");
string utonev = Console.ReadLine();
valasztas.SzavazatokSzama(vezeteknev, utonev);

valasztas.ReszvetelArany();
valasztas.PartokAranya();
valasztas.LegtobbSzavazat();
valasztas.KepviselokPerKerulet();

Console.ReadLine();