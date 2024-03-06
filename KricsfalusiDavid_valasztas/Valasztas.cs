using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KricsfalusiDavid_valasztas
{
    internal class Valasztas
    {
        private List<Kepviselo> kepviselok;

        public Valasztas()
        {
            kepviselok = new List<Kepviselo>();
        }

        public void Beolvasas(string fajlnev)
        {
            try
            {
                foreach (var sor in File.ReadAllLines(fajlnev))
                {
                    var split = sor.Split(' ');
                    int valasztokerulet = int.Parse(split[0]);
                    int szavazatok = int.Parse(split[1]);
                    string vezeteknev = split[2];
                    string utonev = split[3];
                    string part = split[4] == "-" ? "Fuggetlen" : split[4];

                    kepviselok.Add(new Kepviselo(valasztokerulet, szavazatok, vezeteknev, utonev, part));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hiba a fájl olvasása közben: {e.Message}");
            }
        }

        public void KepviseloSzam()
        {
            int kepviseloSzam = kepviselok.Count;
            Console.WriteLine($"2. feladat: A helyhatósági választáson {kepviseloSzam} képviselőjelölt indult.");
        }

        public void SzavazatokSzama(string vezeteknev, string utonev)
        {
            Kepviselo kepviselo = kepviselok.Find(k => k.Vezeteknev == vezeteknev && k.Utonev == utonev);

            if (kepviselo != null)
            {
                Console.WriteLine($"3. feladat: {vezeteknev} {utonev} {kepviselo.Szavazatok} szavazatot kapott.");
            }
            else
            {
                Console.WriteLine("3. feladat: Ilyen nevű képviselőjelölt nem szerepel a nyilvántartásban!");
            }
        }

        public void ReszvetelArany()
        {
            int jogosultakSzama = 12345;
            double reszveteliArany = (double)kepviselok.Sum(k => k.Szavazatok) / jogosultakSzama * 100;

            Console.WriteLine($"4. feladat: A választáson {kepviselok.Sum(k => k.Szavazatok)} állampolgár, a jogosultak {reszveteliArany:F2}%-a vett részt.");
        }

        public void PartokAranya()
        {
            var partok = kepviselok.GroupBy(k => k.Part)
                                  .Select(g => new { Part = g.Key, Szavazatok = g.Sum(k => k.Szavazatok) })
                                  .OrderByDescending(g => g.Szavazatok);

            Console.WriteLine("5. feladat: Az egyes pártokra leadott szavazatok aránya az összes leadott szavazathoz:");
            foreach (var part in partok)
            {
                double arany = (double)part.Szavazatok / kepviselok.Sum(k => k.Szavazatok) * 100;
                Console.WriteLine($"{part.Part}= {arany:F2}%");
            }
        }
        
        public void LegtobbSzavazat()
        {
            int maxSzavazat = kepviselok.Max(k => k.Szavazatok);
            var legtobbSzavazatotKapok = kepviselok.Where(k => k.Szavazatok == maxSzavazat);

            Console.WriteLine("6. feladat: A legtöbb szavazatot kapott képviselő(k):");
            foreach (var kepviselo in legtobbSzavazatotKapok)
            {
                Console.WriteLine($"{kepviselo.Vezeteknev} {kepviselo.Utonev} ({kepviselo.Part})");
            }
        }

        public void KepviselokPerKerulet()
        {
            var keruletek = kepviselok.GroupBy(k => k.Valasztokerulet)
                                      .Select(g => g.OrderByDescending(k => k.Szavazatok).First())
                                      .OrderBy(g => g.Valasztokerulet);

            using (StreamWriter sw = new StreamWriter("kepviselok.txt"))
            {
                Console.WriteLine("7. feladat: Az egyes választókerületekben megválasztott képviselők:");
                foreach (var kepviselo in keruletek)
                {
                    Console.WriteLine($"{kepviselo.Valasztokerulet} {kepviselo.Vezeteknev} {kepviselo.Utonev} ({kepviselo.Part})");
                    sw.WriteLine($"{kepviselo.Valasztokerulet} {kepviselo.Vezeteknev} {kepviselo.Utonev} ({kepviselo.Part})");
                }
            }
        }
    }


}
