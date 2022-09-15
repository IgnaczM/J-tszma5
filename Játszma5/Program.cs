using System;
using System.Collections.Generic;
using System.IO;


namespace Játszma5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<bool> lista = new List<bool>();
            string[] sorok = File.ReadAllLines("labdamenetek5.txt");

            for (int i = 0; i < sorok.Length; i++)
            {
                lista.Add(sorok[i] == "A");
            }

            Console.WriteLine("3.feladat: Labdamenetek száma: {0}", lista.Count);

            int db = 0;

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i])
                {
                    db++;
                }
            }
            Console.WriteLine("4.feladat: Az adogato játkos {0:.0000000000%} nyerte meg a labdamenetejet.", (double)db / lista.Count);

            int winstreak = 0;
            int aktWinStreak = 0;

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i])
                {
                    aktWinStreak++;
                }
                else
                {
                    if (winstreak < aktWinStreak)
                    {
                        winstreak = aktWinStreak;
                    }
                    aktWinStreak = 0;
                }
            }

            Console.WriteLine("5.feladat: Leghosszab sorozat {0}", winstreak);



            játék PróbaJáték = new játék(new List<bool>() { false, true, false, true, true }, "Mahut", "Isner");
            PróbaJáték.Hozzáad(true);
            Console.WriteLine("7.feladat: A próbajáték");
            Console.WriteLine("\tÁllás:{0}",PróbaJáték.allasSzoveg());
            Console.WriteLine("\tBefejezodott a játék:");
            if (PróbaJáték.JátékVége())
            {
                Console.Write("igen");
            }
            else
            {
                Console.WriteLine("nem");
            }



            List<játék> meccs = new List<játék>();

            int q = 0;
            while (q<lista.Count)
            {
                játék temp;
                if (meccs.Count%2==0)
                {
                    temp = new játék(new List<bool>() { }, "Isner", "Mahut");

                }
                else
                {
                    temp = new játék(new List<bool>() { }, "Mahut", "Isner");

                }

                while (!temp.JátékVége())
                {
                    temp.Hozzáad(lista[q]);

                    q++;
                }
                meccs.Add(temp);
            }

           
        }


    }


    class játék
    {

        List<bool> allas = new List<bool>();
        string adogato, fogado;
        public játék( List<bool> allas,string adogato,string fogado)
        {
            this.allas = allas;
            this.adogato = adogato;
            this.fogado = fogado;
        }

        public void Hozzáad(bool labdaMenet)
        {
            allas.Add(labdaMenet);
        }
        public int NyertLabdamenetekSzáma(string nyertes)
        {
            int db = 0;
            for (int i = 0; i < allas.Count; i++)
            {
                if (nyertes=="A" && allas[i])
                {
                    db++;
                }
                else if (nyertes== "F" && !allas[i])
                {
                    db++;
                }
            }
            return db;
        }
        public bool JátékVége()
        {
            int nyertAdogató, nyertFogadó, külömbség;
            nyertAdogató = NyertLabdamenetekSzáma("A");
            nyertFogadó = NyertLabdamenetekSzáma("F");
            külömbség = Math.Abs(nyertAdogató - nyertFogadó);
            return (nyertAdogató >= 4 || nyertFogadó >= 4) && (külömbség >= 2);
        }
        public string allasSzoveg()
        {
            string vissza = "";
            for (int i = 0; i < allas.Count; i++)
            {
                if (allas[i])
                {
                    vissza += "A";
                }
                else
                {
                    vissza += "F";
                }
            }
            return vissza;

        }

    }

    

   
}
