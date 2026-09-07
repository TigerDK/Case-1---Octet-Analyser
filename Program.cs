namespace Case_1___Octet_Analyser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int oktet;
            int ip;
            int førstOkt;



            Console.WriteLine("Oktet Analyser");
            Console.Write("Indtast din første oktet:");
            førstOkt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Din oktet er {0}", førstOkt);








        }
        class IP
        {
            public void FindKlasse(int førstOkt)
            {
                int ip_class;
                int ip_class_a;
                int ip_class_b;
                int ip_class_c;
                int ip_loop_back = 127;
                
                /* a class <= 0 && >= 127 
                 * b class <= 128 && >= 191 
                 * c class <= 192 && >= 223 
                 * (0-127 A, 128-191 B, 192-223 C, 224-239 D, 240-255 E)
                 */
                begyndelse:
                if (førstOkt >= 1 && førstOkt <= 126)
                {
                    Console.Clear();
                    Console.WriteLine("Din indtasted oktet {0} ligger i A-klassen", førstOkt);
                }
                else if (førstOkt >= 128 && førstOkt <= 191)
                {
                    Console.Clear();
                    Console.WriteLine("Din indtasted oktet {0} ligger i B-klassen", førstOkt);
                }
                else if (førstOkt >= 192 && førstOkt <= 223)
                {
                    Console.Clear();
                    Console.WriteLine("Din indtasted oktet {0} ligger i C-klassen", førstOkt);
                }
                else if (førstOkt == 127)
                {
                    Console.Clear();
                    Console.WriteLine("Din indtasted oktet {0} er en loopback og ikke en brugbar oktet", førstOkt);

                }
                else if (førstOkt >= 224 && førstOkt <= 255)
                {
                    Console.Clear();
                    Console.WriteLine("Din indtasted oktet {0} er enten en D eller E Klasse", førstOkt);
                    Console.Clear();
                    Console.WriteLine("Tryk for at indtaste en ny oktet");
                    Console.Clear();
                    Console.ReadKey();
                    goto begyndelse;

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Din indtasted oktet {0} er en ugyldig oktet Tryk for at prøv igen", førstOkt);
                    Console.ReadKey();
                    Console.Clear();
                    goto begyndelse;
                }



            }
            public void FindSubnetMask(int oktet)
            {
                int subnetdefault;
                int subnetcustom;

            }

        }
    }
}
