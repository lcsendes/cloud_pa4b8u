using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dorm.Web
{
    public class Web
    {
        public void JavaThings()
        {
            Console.WriteLine("Mielött elkezdi beírni az adatokat győződjön meg róla, " +
                "hogy a Java project fut, különben nem megy ez a fele az alkalmazásnak");
            Console.WriteLine("Adja meg a hallgató nevét");
            string nev = Console.ReadLine();
            nev = StringConverter(nev);
            Console.WriteLine("Adja meg a kedven állatát");
            string allat = Console.ReadLine();
            Console.WriteLine("Adja meg a kedvenc számát");
            string szam = Console.ReadLine();
            Console.WriteLine("Adja meg a fogkeféje színét");
            string szin = Console.ReadLine();

            string url = "http://" + $"localhost:8080/EmailGenerator/Kezelo?name={nev}&favAni={allat}&luckyNum={szam}&tBrush={szin}";

            XDocument xdoc = XDocument.Load(url);

            List<string> lista = xdoc.Descendants("person").Select(x => x.Element("email").Value).ToList();

            Console.WriteLine("A generál e-mail címek:");
            foreach (string item in lista)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        private string StringConverter(string nev)
        {
            string ujnev = "";
            for (int i = 0; i < nev.Length; i++)
            {
                if (nev[i] == ' ')
                {
                    ujnev += '.';
                }
                else
                {
                    if (nev[i] == 'Á' || nev[i] == 'á' )
                    {
                        ujnev += 'a';
                    }
                    else if (nev[i] == 'É' || nev[i] == 'é' )
                    {
                        ujnev += 'e';
                    }
                    else if (nev[i] == 'Í' || nev[i] == 'í' )
                    {
                        ujnev += 'i';
                    }
                    else if (nev[i] == 'Ó' || nev[i] == 'ó' )
                    {
                        ujnev += 'o';
                    }
                    else if (nev[i] == 'Ö' || nev[i] == 'ö' )
                    {
                        ujnev += 'o';
                    }
                    else if (nev[i] == 'Ő' || nev[i] == 'ő' )
                    {
                        ujnev += 'o';
                    }
                    else if (nev[i] == 'Ú' || nev[i] == 'ú' )
                    {
                        ujnev += 'u';
                    }
                    else if (nev[i] == 'Ü' || nev[i] == 'ü' )
                    {
                        ujnev += 'u';
                    }
                    else if (nev[i] == 'Ű' || nev[i] == 'ű' )
                    {
                        ujnev += 'u';
                    }
                    else
                    {
                        ujnev += nev[i];
                    }
                }
            }
            return ujnev.ToLower();
        }
        
    }
}
