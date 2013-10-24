using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tsr
{
    class Program
    {

       static int[] primes = new int[0];
       static int[] seq = new int[0];

        static void prime()
        {
            bool b = false;
          
            for (int i = 0; i < seq.Length; i++)
            {
                double d = Math.Sqrt(seq[i]);
                for (int j = 2; j <= Convert.ToInt32(d); j++)
                {
                    if (seq[i] % j == 0)
                        b = true;
                }
                if (b == false)
                {
                    Array.Resize<int>(ref primes, primes.Length + 1);
                    primes[primes.Length - 1] = seq[i];
                }
                else
                    b = false;
            }
        }

        static void func(int i)
        {
            Console.WriteLine(i.ToString());
            Array.Resize<int>(ref seq, seq.Length + 1);
            seq[seq.Length - 1] = i;
            if (i != 1)
            {
                if (i % 2 == 0)
                {
                    i /= 2;
                    func(i);
                }
                else
                {
                    i = i * 3 + 1;
                    func(i);
                }
            }
        }

        static void Do(int z)
        {
            func(z);
            prime();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            for (int i = 0; i < primes.Length; i++)
                Console.WriteLine(primes[i].ToString());
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine((primes.Length).ToString());
            System.IO.StreamWriter file = new System.IO.StreamWriter("output.txt",true);
            file.WriteLine("**********************************************************************************************");
            file.WriteLine("STARTING NUMBER: " + z.ToString());
            file.WriteLine("NUMBER OF SEQUNCE ITERATIONS: " + seq.Length.ToString());
            file.WriteLine("NUMBER OF PRIMES: " + primes.Length.ToString());
            file.WriteLine("**********************************************************************************************");
            file.WriteLine("");
            file.Close();

            System.IO.StreamWriter f = new System.IO.StreamWriter("outputPrimes.csv", true);
            f.WriteLine(z.ToString()+","+primes.Length.ToString());
            f.Close();

            f = new System.IO.StreamWriter("outputIterations.csv", true);
            f.WriteLine(z.ToString() + "," + seq.Length.ToString());
            f.Close();

            primes = new int[0];
            seq = new int[0];
        }

        static void Main(string[] args)
        {
            System.IO.File.Delete("output.txt");
            System.IO.File.Delete("outputPrimes.csv");
            System.IO.File.Delete("outputIterations.csv");
            System.IO.StreamWriter f = new System.IO.StreamWriter("outputPrimes.csv");
            f.WriteLine("int,primes");
            f.Close();
            f = new System.IO.StreamWriter("outputIterations.csv");
            f.WriteLine("int,ite");
            f.Close();
            for (int i = 1; i <= 10000; i++)
                Do(i);
           // Console.ReadLine();
        }
    }
}
