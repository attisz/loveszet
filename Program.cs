using System;

namespace sajat_megoldas
{
    class Program
    {
        static void Main(string[] args)
        {
            int startMillis = DateTime.Now.Millisecond;

            int[] inputs = Array.ConvertAll(Console.ReadLine().Split(' ', 2), Int32.Parse);
            int numberOfRacer = inputs[0];
            int maxPoints = inputs[1];

            int[] points = Array.ConvertAll(Console.ReadLine().Split(' ', numberOfRacer), Int32.Parse);
            int[] scores = new int[maxPoints + 1];

            int place = 1;
            scores[points[0]] = 1;

            Console.WriteLine("{0} {1}", 1, 1);

            int middleMillis = DateTime.Now.Millisecond;

            for (int i = 1; i < numberOfRacer; i++)
            {
                int lastPoint = points[i - 1];
                int point = points[i];

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
            }

            Console.Error.WriteLine("cycle run time: {0}", middleMillis - startMillis);
            Console.Error.WriteLine("full run time: {0}", DateTime.Now.Millisecond - startMillis);
        }
    }
}
