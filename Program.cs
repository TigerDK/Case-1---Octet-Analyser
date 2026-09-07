namespace Case_1___Octet_Analyser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int oktet;
            int ip;

            int subnetmask;
            int subnetdefault;
            int subnetcustom;


            Console.WriteLine("Oktet Analyser");
            Console.Write("Indtast din første oktet:");
            oktet = Convert.ToInt32(Console.ReadLine());







        }
        class IP
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



        }
    }
}
