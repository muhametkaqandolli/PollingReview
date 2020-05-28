using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingReview
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] topics = new string[] { "Terrorism         ", "Economy           ", "Inequality        ", "Racism            ", "Stupid politicians" };
            int[,] responses = new int[5, 10];
            int response;
            double totalResponses = 0;
            double totalUser = 0;
            bool notFinished = true;
            double[] highestLowest = new double[5];

            while (notFinished)
            {
                totalUser += 1;
                Console.WriteLine("Please rate in scale 1-10 how big of a problem for the Kosovo are the following issues:");
                for (int r = 0; r < 5; r++)
                {
                    Console.Write(topics[r].Trim() + ": ");
                    response = Convert.ToInt32(Console.ReadLine());
                    responses[r, response - 1] += 1;

                }

                Console.WriteLine("Do you want to enter input from another user?(y-n)");
                if (Console.ReadLine().ToUpper().Equals("N"))
                    notFinished = false;

                Console.Clear();
            }

            Console.WriteLine("                    1  2  3  4  5  6  7  8  9  10  AVG");
            for (int r = 0; r < 5; r++)
            {
                Console.Write(topics[r] + "  ");
                for(int c = 0; c < 10; c++)
                {
                    Console.Write(responses[r, c] + "  ");
                    totalResponses += responses[r, c] * (c+1);
                }
                highestLowest[r] = totalResponses;
                Console.Write("{0:N2}", totalResponses / totalUser);
                Console.WriteLine();
                totalResponses = 0;
            }

            double highest = highestLowest[0];
            double lowest = highestLowest[0];
            int tempHighest = 0;
            int tempLowest = 0;

            for (int i = 0; i < 5; i++)
            {
                if (highestLowest[i] > highest)
                {
                    highest = highestLowest[i];
                    tempHighest = i;
                    
                }

                if (highestLowest[i] < lowest)
                {
                    lowest = highestLowest[i];
                    tempLowest = i;
                }
            }
            Console.WriteLine("Topic with the highest point total is {0}. It recieved {1} points.", topics[tempHighest], highest);
            Console.WriteLine("Topic with the highest point total is {0}. It recieved {1} points.", topics[tempLowest], lowest);
            Console.ReadLine();
        }
    }
}
