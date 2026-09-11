namespace Case_1___Oktet_Analyser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int førstOkt;
            string input;

            /* [] betyder at man arbejder med flere værdier i et array
             * FX:
             * string[] ipDele = { "192", "168", "1", "50" };
             * ipDele[0] = "192"
             * ipDele[1] = "168"
             * ipDele[2] = "1"
             * ipDele[3] = "50"
             */
            // Her afgøre vi, at denne string arbejder med et array
            string[] ipDele;

        begyndelse:

            Console.WriteLine("Oktet Analyser");

            Console.Write("Indtast første oktet eller fuld IP-adresse: ");
            input = Console.ReadLine();

            //Her giver vi brugeren mulighed for at skrive enten en fuld IP-adresse eller kun den første oktet
            // .Contains er en funktion, der bruges til at finde bestemte tegn, ord eller sætninger i en string
            if (input.Contains("."))
            {
                /*Her splitter vi inputtet op ved hvert punktum. Da ipDele er et string array
                 * bliver de forskellige dele af ip adressen gemt som separate værdier i arrayet
                 */
                ipDele = input.Split('.');
                /* Her konverterer vi den første del fra string til et objekt, så værdien kan gemmes i "førstOkt"
                 * Det er også her, vi vælger hvilken del af arrayet der skal bruges
                 * ipDele[0] = første del af arrayet
                 * ipDele[1] = anden del
                 * ipDele[2] tredje del
                 * Osv.
                */
                førstOkt = Convert.ToInt32(ipDele[0]);
            }
            else
            {
                // Vis der ikke er noget '.' der med ikke en fuld IP-adresse går den videre som en Oktet
                førstOkt = Convert.ToInt32(input);
            }

            // Her laver vi et objekt af IP-klassen, så vi kan bruge funktionerne inde i klassen
            IP ip = new IP();

            // Dette kalder dataen som er i Class, de forskellige pulic strings
            string ipKlasse = ip.FindKlasse(førstOkt);
            string subnetMaske = ip.FindSubnetMask(førstOkt);

            // ! tjekker om betingelsen er false, som vi bruger til at tjekke om oktetten er ugyldig
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

        /* Vi valgte at bruge Class og public strings..........
         * 
         */
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