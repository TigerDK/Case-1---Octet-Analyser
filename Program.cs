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

            // "begyndelse:" er et label, altså et bestemt sted i koden, som programmet kan hoppe tilbage til
        begyndelse:
            Console.Clear();
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

                Console.Clear();
                Console.WriteLine("Ugyldig oktet");
                Console.ReadKey();
                //goto begyndelse; sender programmet tilbage til stedet, hvor label'et "begyndelse:" står
                goto begyndelse;
            }
            else
            {
                // Aniver maksimal bredde på udskriften
                int udskrift_bred = 50;
                // Beregner hvor mange mellemrum der skal være i venstre side for at centrere udskriften
                int udskrift_center = (Console.WindowWidth - udskrift_bred) / 2;
                //new string laver en ny tekststreng med det angivne tegn, som bliver gentaget det antal gange, der er angivet
                string linje = new string('-', udskrift_bred);

                // \n laver et linjeskift efter teksten
                Console.Clear();
                // Flytter markøren, så udskriften starter ved den beregnede center-position
                Console.SetCursorPosition(udskrift_center, Console.CursorTop);
                Console.WriteLine(linje);

                Console.SetCursorPosition(udskrift_center, Console.CursorTop);
                Console.WriteLine("Konklusion");
                Console.SetCursorPosition(udskrift_center, Console.CursorTop);
                Console.WriteLine(linje);
                Console.SetCursorPosition(udskrift_center, Console.CursorTop);
                Console.WriteLine("Analyse af oktet {0}:\n", førstOkt);
                Console.SetCursorPosition(udskrift_center, Console.CursorTop);                                                    
                Console.WriteLine("IP-Klass: {0}\n", ipKlasse);
                Console.SetCursorPosition(udskrift_center, Console.CursorTop);
                Console.WriteLine("Default subnetmaske: {0}\n", subnetMaske);
                Console.SetCursorPosition(udskrift_center, Console.CursorTop);
                Console.WriteLine(linje);
                Console.SetCursorPosition(udskrift_center, Console.CursorTop);
                Console.WriteLine("Tryk for at afslutte\n");
                Console.SetCursorPosition(udskrift_center, Console.CursorTop);
                Console.WriteLine(linje);   
                
                Console.ReadKey();
                //goto begyndelse; sender programmet tilbage til stedet, hvor label'et "begyndelse:" står
                goto begyndelse;
            }
        }

        /* Vi valgte at bruge classes og public metoder for at gøre koden mere overskuelig
         * Metoderne kan have forskellige returtyper, fx string, int eller void
         * Det gør det nemmere at opdele koden og rette i bestemte dele uden at ændre hele programmet
         */
        class IP
        {
            public string FindKlasse(int førstOkt)
            {
                string ip_klasse = "";

                /* a class >= 1 && <= 126
                 * Loopback == 127
                 * b class >= 128 && <= 191 
                 * c class >= 192 && <= 223 
                 * (0-127 A, 128-191 B, 192-223 C, 224-239 D, 240-255 E)
                 */

                // if statement for at finde IP-Klassen
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

                // Returnerer den opdaterede string efter if-statementet, så værdien kan bruges uden for metoden
                return ip_klasse;
            }
            public string FindSubnetMask(int førstOkt)
            {

                string subnetdefault;
                // if statement for at finde default subnetmaske                                                    
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

                // Returnerer den opdaterede string efter if-statementet, så værdien kan bruges uden for metoden
                return subnetdefault;

            }
        }
    }
}