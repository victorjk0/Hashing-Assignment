using System;
using System.Text;

namespace Hashing_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 1;

            Console.WriteLine("Choose Algorithms from the list below");



            foreach (object item in Enum.GetValues(typeof(Algorithms)))
            {
                Console.WriteLine("{0}  {1}",num, item);
                num++;
            }



            HMacHandler hmHandler = new HMacHandler();

            Console.Write("Choose Number: ");

            string choice = Console.ReadLine();

            hmHandler.HMacSelector(choice);


            Algorithms algo = (Algorithms)Enum.Parse(typeof(Algorithms), choice);


            Console.Clear();

            Console.Write("Message to hash: ");
            string cmes = Console.ReadLine();

            Console.Write("Key For Validation: ");
            string ckey = Console.ReadLine();

            byte[] mes = Encoding.ASCII.GetBytes(cmes);
            byte[] key = Encoding.ASCII.GetBytes(ckey);

            Console.WriteLine("{0} HMAC is: {1}", algo, hmHandler.ReturnHmac(hmHandler.ComputeMAC(mes, key)));
        }
    }
}
