// <copyright file="Methods.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG3_2018_2_PA4B8U
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Dorm.Logic;
    using Dorm.Web;

    /// <summary>
    /// Method generator for main
    /// </summary>
    public class Methods
    {
        /// <summary>
        /// Creates a menu for the user
        /// </summary>
        /// <param name="logika">Logic used in the menu</param>
        public static void Menu(ILogic logika)
        {
            Web web = new Web();
            int choice = 0;
            do
            {
                Console.WriteLine("Obudai Egyetem Kollégiumi Rendszer");
                Console.WriteLine("Válasszon a lehetőségek közül:");
                Console.WriteLine("1. Listázás");
                Console.WriteLine("2. Hozzáadás");
                Console.WriteLine("3. Törlés");
                Console.WriteLine("4. Módosítás");
                Console.WriteLine("5. Egyszerű lekérdezések");
                Console.WriteLine("6. Java részlet");
                Console.WriteLine("7. Kilépés");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        List<string> datalist = logika.Listing(SmallMenus());
                        foreach (var item in datalist)
                        {
                            Console.WriteLine(item);
                        }

                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        int num2 = SmallMenus();
                        switch (num2)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Adja meg a neptun kódját:");
                                string neptunkod = Console.ReadLine();
                                while (neptunkod.Length != 6)
                                {
                                    Console.WriteLine("Adja meg a neptun kódját:");
                                    neptunkod = Console.ReadLine();
                                }

                                Console.WriteLine("Adja meg a diák nevét:");
                                string nev = Console.ReadLine();
                                Console.WriteLine("Adja meg az email címét:");
                                string emailcim = Console.ReadLine();
                                Console.WriteLine("Adja meg a születési dátumát (dd-MON-yyyy mint 03-JAN-1998):");
                                string szuldat = Console.ReadLine();
                                Console.WriteLine("Adja meg a telefonszámát (pl.: 06201234567)");
                                string telszam = Console.ReadLine();
                                Console.WriteLine("Adja meg a szoba ID-ját");
                                string szobaid = Console.ReadLine();
                                while (szobaid.Length != 6)
                                {
                                    Console.WriteLine("Adja meg a szoba ID-ját");
                                    szobaid = Console.ReadLine();
                                }

                                string[] studinfo = new string[6];
                                studinfo[0] = neptunkod;
                                studinfo[1] = nev;
                                studinfo[2] = emailcim;
                                studinfo[3] = szuldat;
                                studinfo[4] = telszam;
                                studinfo[5] = szobaid;
                                if (logika.Adding(studinfo) == true)
                                {
                                    Console.WriteLine("Sikeresen hozzáadva");
                                }
                                else
                                {
                                    Console.WriteLine("Sikertelen hozzáadás");
                                }

                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case 2:
                                Console.Clear();

                                Console.WriteLine("Adja meg a szoba ID-ját");
                                string szobaid2 = Console.ReadLine();
                                while (szobaid2.Length != 6)
                                {
                                    Console.WriteLine("Adja meg a szoba ID-ját");
                                    szobaid2 = Console.ReadLine();
                                }

                                string szobaszam = szobaid2.Substring(3);
                                Console.WriteLine("Adja meg a szoba kapacitását:");
                                string agy = Console.ReadLine();
                                Console.WriteLine("Adja meg a koli ID-ját a szobának");
                                string kollid = Console.ReadLine();
                                while (kollid.Length != 3)
                                {
                                    Console.WriteLine("Adja meg a koli ID-ját a szobának");
                                    kollid = Console.ReadLine();
                                }

                                string[] roominfo = new string[4];
                                roominfo[0] = szobaid2;
                                roominfo[1] = szobaszam;
                                roominfo[2] = agy;
                                roominfo[3] = kollid;
                                if (logika.Adding(roominfo))
                                {
                                    Console.WriteLine("Sikeresen hozzáadva");
                                }

                                Console.ReadLine();
                                Console.Clear();

                                break;
                            case 3:
                                Console.Clear();

                                Console.WriteLine("Adja meg a koli ID-ját");
                                string kollid2 = Console.ReadLine();
                                while (kollid2.Length != 3)
                                {
                                    Console.WriteLine("Adja meg a koli ID-ját");
                                    kollid2 = Console.ReadLine();
                                }

                                Console.WriteLine("Adja meg a koli nevét");
                                string kollnev = Console.ReadLine();
                                Console.WriteLine("Adja meg a koli címét");
                                string cim = Console.ReadLine();
                                Console.WriteLine("Adja meg a férőhelyek számát:");
                                string ferohely = Console.ReadLine();
                                Console.WriteLine("Adja meg a koli telefonszámát:");
                                string kolitelszam = Console.ReadLine();

                                string[] dorminfo = new string[5];
                                dorminfo[0] = kollid2;
                                dorminfo[1] = kollnev;
                                dorminfo[2] = cim;
                                dorminfo[3] = ferohely;
                                dorminfo[4] = kolitelszam;
                                if (logika.Adding(dorminfo))
                                {
                                    Console.WriteLine("Sikeresen hozzáadva");
                                }

                                Console.ReadLine();
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Rossz válasz");
                                break;
                        }

                        break;

                    case 3:
                        int num3 = SmallMenus();
                        switch (num3)
                        {
                            case 1:
                                Console.WriteLine("Adja meg a tanuló neptunkódját:");
                                string neptunkod = Console.ReadLine();
                                while (neptunkod.Length != 6)
                                {
                                    Console.WriteLine("Adja meg a tanuló neptunkódját:");
                                    neptunkod = Console.ReadLine();
                                }

                                bool vissza = logika.Deleting(neptunkod);
                                if (vissza)
                                {
                                    Console.WriteLine("Sikeres hozzáadás");
                                }

                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case 2:
                                Console.WriteLine("Adja meg a szoba ID-ját");
                                string szobaid = Console.ReadLine();
                                while (szobaid.Length != 6)
                                {
                                    Console.WriteLine("Adja meg a szoba ID-ját");
                                    szobaid = Console.ReadLine();
                                }

                                bool vissza1 = logika.Deleting(szobaid);
                                if (vissza1)
                                {
                                    Console.WriteLine("Sikeres hozzáadás");
                                }

                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case 3:
                                Console.WriteLine("Adja meg a koli ID-ját a szobának");
                                string kollid = Console.ReadLine();
                                while (kollid.Length != 3)
                                {
                                    Console.WriteLine("Adja meg a koli ID-ját a szobának");
                                    kollid = Console.ReadLine();
                                }

                                bool vissza2 = logika.Deleting(kollid);
                                if (vissza2)
                                {
                                    Console.WriteLine("Sikeres hozzáadás");
                                }

                                Console.ReadLine();
                                Console.Clear();
                                break;
                            default:
                                break;
                        }

                        break;

                    case 4:
                        switch (SmallMenus())
                        {
                            case 1:
                                Console.WriteLine("Adja meg a módosítandó tanuló Neptunkódját:");
                                string key = Console.ReadLine();
                                if (logika.CheckKey(key, 1) == false)
                                {
                                    Console.WriteLine("Adatok módosítása");

                                    Console.WriteLine("Adja meg a diák nevét:");
                                    string nev = Console.ReadLine();
                                    Console.WriteLine("Adja meg az email címét:");
                                    string emailcim = Console.ReadLine();
                                    Console.WriteLine("Adja meg a születési dátumát (dd-MON-yyyy):");
                                    string szuldat = Console.ReadLine();
                                    Console.WriteLine("Adja meg a telefonszámát (pl.: 06201234567)");
                                    string telszam = Console.ReadLine();
                                    Console.WriteLine("Adja meg a szoba ID-ját");
                                    string szobaid = Console.ReadLine();
                                    while (szobaid.Length != 6)
                                    {
                                        Console.WriteLine("Adja meg a szoba ID-ját");
                                        szobaid = Console.ReadLine();
                                    }

                                    string[] studinfo = new string[6];
                                    studinfo[0] = key;
                                    studinfo[1] = nev;
                                    studinfo[2] = emailcim;
                                    studinfo[3] = szuldat;
                                    studinfo[4] = telszam;
                                    studinfo[5] = szobaid;

                                    logika.Modifying(studinfo);
                                }

                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case 2:
                                Console.WriteLine("Adja meg a szoba ID-ját");
                                string szobaid2 = Console.ReadLine();
                                if (logika.CheckKey(szobaid2, 2) == false)
                                {
                                    string szobaszam = szobaid2.Substring(4);
                                    Console.WriteLine("Adja meg a szoba kapacitását:");
                                    string agy = Console.ReadLine();
                                    Console.WriteLine("Adja meg a koli ID-ját a szobának");
                                    string kollid = Console.ReadLine();
                                    while (kollid.Length != 3)
                                    {
                                        Console.WriteLine("Adja meg a koli ID-ját a szobának");
                                        kollid = Console.ReadLine();
                                    }

                                    string[] roominfo = new string[4];
                                    roominfo[0] = szobaid2;
                                    roominfo[1] = szobaszam;
                                    roominfo[2] = agy;
                                    roominfo[3] = kollid;

                                    logika.Modifying(roominfo);
                                }

                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case 3:
                                Console.WriteLine("Adja meg a modositando kollegium azonositoját:");
                                string kollid2 = Console.ReadLine();
                                if (logika.CheckKey(kollid2, 3) == false)
                                {
                                    Console.WriteLine("Adja meg a koli nevét");
                                    string kollnev = Console.ReadLine();
                                    Console.WriteLine("Adja meg a koli címét");
                                    string cim = Console.ReadLine();
                                    Console.WriteLine("Adja meg a férőhelyek számát:");
                                    string ferohely = Console.ReadLine();
                                    Console.WriteLine("Adja meg a koli telefonszámát:");
                                    string kolitelszam = Console.ReadLine();

                                    string[] dorminfo = new string[4];
                                    dorminfo[0] = kollid2;
                                    dorminfo[1] = kollnev;
                                    dorminfo[2] = cim;
                                    dorminfo[3] = ferohely;
                                    dorminfo[4] = kolitelszam;

                                    logika.Modifying(dorminfo);
                                }

                                Console.ReadLine();
                                Console.Clear();
                                break;
                            default:
                                break;
                        }

                        break;

                    case 5:
                        Console.WriteLine("Melyik lekérdezést szeretné futtatni?");
                        Console.WriteLine("1. Ki a legöregebb regisztrált diák?");
                        Console.WriteLine("2. Kollégiumok kilistázása férőhely szerint");
                        Console.WriteLine("3. Melyik tanuló melyik koliban lakik");
                        int lek = int.Parse(Console.ReadLine());
                        switch (lek)
                        {
                            case 1:
                                string oregdiak = logika.OldStud();
                                Console.WriteLine(oregdiak);
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case 2:
                                List<string> lista = logika.DormByPlace();
                                foreach (var item in lista)
                                {
                                    Console.WriteLine(item);
                                }

                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case 3:
                                bool kesz = logika.StudentInDorm();
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            default:
                                break;
                        }

                        break;

                    case 6:
                        web.JavaThings();
                        Console.Clear();
                        break;

                    case 7:
                        Console.WriteLine("Viszlát");
                        break;

                    default:
                        Console.WriteLine("\n Rossz válasz");
                        System.Threading.Thread.Sleep(100);
                        Console.Clear();
                        break;
                }
            }
            while (choice != 7);
        }

        /// <summary>
        /// Ask the user which table should the program do the changes
        /// 1 for Students, 2 for Rooms, 3 for Dorms
        /// </summary>
        /// <returns>returns the users table choice</returns>
        public static int SmallMenus()
        {
            Console.WriteLine("Melyik táblát szeretnéd használni?");
            Console.WriteLine("1. Tanulók");
            Console.WriteLine("2. Szobák");
            Console.WriteLine("3. Kollégiumok");
            int num = int.Parse(Console.ReadLine());
            return num;
        }
    }
}
