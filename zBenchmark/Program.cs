using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace zBenchmark
{
    class Program
    {
        class TestClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public static void Main(string[] args)
        {
            for(int i = 0; i < 100; i++)
                Jagged2DBench();
        }

        public static void Jagged2DBench()
        {
            Random rand = new Random();
            int[][] jagged = new int[5000][];
            for (int i = 0; i < jagged.Length; i++)
            {
                jagged[i] = new int[5000];
                for (int j = 0; j < 5000; j++)
                    jagged[i][j] = rand.Next();
            }

            int[] readIndexes = new int[5000];
            for (int i = 0; i < 5000; i++)
            {
                readIndexes[i] = rand.Next(5000);
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int j = 0; j < 1000; j++) {
                for (int i = 0; i < 5000; i += 2)
                {
                    int read = readIndexes[i];
                    int read2 = readIndexes[i + 1];
                    int value = jagged[read][read2];
                }
            }
            sw.Stop();
            Console.WriteLine("Jagged read performance: " + sw.Elapsed.TotalMilliseconds + "ms.");

            jagged = null;
            int[,] two = new int[5000, 5000];
            for (int i = 0; i < 5000; i++)
                for (int j = 0; j < 5000; j++)
                    two[i, j] = rand.Next();
            sw.Restart();
            for (int j = 0; j < 1000; j++)
            {
                for (int i = 0; i < 5000; i += 2)
                {
                    int read = readIndexes[i];
                    int read2 = readIndexes[i + 1];
                    int value = two[read, read2];
                }
            }
            sw.Stop();
            Console.WriteLine("2D read performance: " + sw.Elapsed.TotalMilliseconds + "ms.");
            Console.ReadLine();
        }

        public static void FindBench()
        {
            Random rand = new Random();
            List<TestClass> list0 = new List<TestClass>();
            for (int i = 0; i < 1000000; i++)
                list0.Add(new TestClass()
                {
                    Id = rand.Next(),
                    Name = RandomString(rand, 120)
                });

            string r = RandomString(rand, 121);
            Stopwatch sw = new Stopwatch();

            sw.Start();
            foreach (TestClass c in list0)
                if (c.Name == r)
                    break;
            sw.Stop();
            Console.WriteLine("Foreach loop took " + (sw.Elapsed.TotalMilliseconds * 1000000) + "ns.");

            sw.Restart();
            for (int i = 0; i < list0.Count; i++)
            {
                TestClass cls = list0[i];
                if (cls.Name == r)
                    break;
            }
            sw.Stop();
            Console.WriteLine("For loop took " + (sw.Elapsed.TotalMilliseconds * 1000000) + "ns.");

            sw.Restart();
            list0.Find(x => x.Name == r);
            sw.Stop();
            Console.WriteLine("Find took " + (sw.Elapsed.TotalMilliseconds * 1000000) + "ns.");

            Console.WriteLine("All tests complete...");
            Console.ReadLine();
        }

        private const string CHARS = "abcdefhhijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890.";
        public static string RandomString(Random random, int len = 16)
        {
            string r = "";
            for (int i = 0; i < len; i++)
            {
                r += CHARS[random.Next(CHARS.Length)];
            }
            return r;
        }
    }
}
