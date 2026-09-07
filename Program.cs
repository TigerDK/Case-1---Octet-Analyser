namespace Case_1___Octet_Analyser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int førstOkt;

        begyndelse:

            Console.WriteLine("Oktet Analyser");
            Console.Write("Indtast din første oktet:");
            førstOkt = Convert.ToInt32(Console.ReadLine());

            IP ip = new IP();

            string ipKlasse = ip.FindKlasse(førstOkt);
            string subnetMaske = ip.FindSubnetMask(førstOkt);

            // false statement ved brug af !

            if (!(førstOkt >= 1 && førstOkt <= 255))
            {
                Console.WriteLine("Ugyldig oktet");
                Console.ReadKey();
                Console.Clear();

                goto begyndelse;
            }
            else
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("             Konklusion");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Din oktet {0} svarer til", førstOkt);
                Console.WriteLine();
                Console.WriteLine("IP-Klass: {0}", ipKlasse);
                Console.WriteLine();
                Console.WriteLine("Default subnetmaske: {0}", subnetMaske);
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("          Tryk for at afslutte");
                Console.WriteLine("--------------------------------------------");
            }


        }
        class IP
        {
            public string FindKlasse(int førstOkt)
            {
                string ip_klasse = "";

                /* a class <= 0 && >= 127 
                 * b class <= 128 && >= 191 
                 * c class <= 192 && >= 223 
                 * (0-127 A, 128-191 B, 192-223 C, 224-239 D, 240-255 E)
                 */

                if (førstOkt >= 1 && førstOkt <= 126)
                {
                    ip_klasse = "A Klasse";
                }
                else if (førstOkt == 127)
                {
                    ip_klasse = "Loopback";
                }
                else if (førstOkt >= 128 && førstOkt <= 191)
                {
                    ip_klasse = "B Klasse";
                }
                else if (førstOkt >= 192 && førstOkt <= 223)
                {
                    ip_klasse = "C Klasse";
                }
                else if (førstOkt >= 224 && førstOkt <= 255)
                {
                    ip_klasse = "D eller E Klasse";
                }

                return ip_klasse;
            }
            public string FindSubnetMask(int førstOkt)
            {
                string subnetdefault;

                if (førstOkt >= 1 && førstOkt <= 126)
                {
                    subnetdefault = "255.0.0.0";
                }
                else if (førstOkt >= 128 && førstOkt <= 191)
                {
                    subnetdefault = "255.255.0.0";
                }
                else if (førstOkt >= 192 && førstOkt <= 223)
                {
                    subnetdefault = "255.255.255.0";
                }
                else if (førstOkt == 127)
                {
                    subnetdefault = "Loopback har ingen standard subnetmaske";
                }
                else
                {
                    subnetdefault = "har ikke en subnetmaske";
                }

                return subnetdefault;

            }
        }
    }
}