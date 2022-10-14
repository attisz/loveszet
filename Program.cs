using System;
using System.Collections.Generic;

namespace sajat_megoldas
{
    class Program
    {
        static int numberOfRacer;

        static void Main(string[] args)
        {
            int startMillis = DateTime.Now.Millisecond;

            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(' ', 2), Int32.Parse);
            numberOfRacer = inputs[0];
            int maxPoints = inputs[1];
            int[] scores = new int[maxPoints + 1];

            int middleMillis = DateTime.Now.Millisecond;

            int place = 1;
            int point = ReadNextNumber();
            int lastPoint = point;
            scores[point] = 1;

            Console.WriteLine("{0} {1}", 1, 1);

            for (int i = 1; i < numberOfRacer; i++)
            {
                point = ReadNextNumber();

                if (point < lastPoint)
                {
                    for (int j = lastPoint; j > point; j--)
                    {
                        place += scores[j];
                    }
                }
                if (point > lastPoint)
                {
                    for (int j = lastPoint + 1; j <= point; j++)
                    {
                        place -= scores[j];
                    }
                }
                Console.WriteLine("{0} {1}", place, ++scores[point]);
                lastPoint = point;
            }

            Console.Error.WriteLine("cycle run time: {0}", middleMillis - startMillis);
            Console.Error.WriteLine("full run time: {0}", DateTime.Now.Millisecond - startMillis);
        }

        static int ReadNextNumber()
        {
            string s = "";
            char c = 'a';

            while (c != ' ' && c != '\n')
            {
                c = (char)Console.Read();
                s = s + c;
            }

            return Int32.Parse(s);
        }
    }
}
