using System;
using System.Collections.Generic;

namespace sajat_megoldas
{
    class Program
    {
        static List<int> points = new List<int>();
        static int numberOfRacer;

        static void Main(string[] args)
        {
            int startMillis = DateTime.Now.Millisecond;

            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(' ', 2), Int32.Parse);
            numberOfRacer = inputs[0];
            int maxPoints = inputs[1];

            int[] scores = new int[maxPoints + 1];

            int place = 1;
            int point = ReadNextNumber();
            int lastPoint = point;
            scores[point] = 1;

            Console.WriteLine("{0} {1}", 1, 1);

            int middleMillis = DateTime.Now.Millisecond;

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

        static int idx = 0;

        static int ReadNextNumber()
        {
            if (points.Count == 0)
            {
                string[] split = Console.ReadLine().Split(' ', numberOfRacer);
                foreach (var s in split)
                {
                    points.Add(Int32.Parse(s));
                }
            }
            return points[idx++];
        }
    }
}
