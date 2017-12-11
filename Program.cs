using System;

namespace Day03 {
    class Program {
        struct Coordinates {
            public int tier; // Stufe: 0..
            public int index; // innerhalb einer Stufe: 1..            
        }
        static void Main (string[] args) {
            int i = 1;
            System.Console.WriteLine("1: expect:0-1-0");
            Console.WriteLine ($"{i}: {GetCoordinates(i).tier}-{GetCoordinates(i).index} - {manhattanDistanceFromCenter(GetCoordinates(i))}");
            i = 5;
            System.Console.WriteLine("5: expect:1-4-2");
            Console.WriteLine ($"{i}: {GetCoordinates(i).tier}-{GetCoordinates(i).index} - {manhattanDistanceFromCenter(GetCoordinates(i))}");
            i = 10;
            System.Console.WriteLine("10: expect:2-1-3");
            Console.WriteLine ($"{i}: {GetCoordinates(i).tier}-{GetCoordinates(i).index} - {manhattanDistanceFromCenter(GetCoordinates(i))}");
        }

        /// <summary>
        /// gibt zu einem Element der Folge die Koordinaten 
        /// in der Form: Stufe(tier) und index zurück
        /// </summary>
        /// <param name="sequenceNumber"></param>
        /// <returns></returns>
        static Coordinates GetCoordinates (int sequenceNumber) {
            Coordinates coordinates = new Coordinates ();
            int newRemainder = sequenceNumber - 2;
            int oldRemainder;
            int tier = -1;
            do {
                ++tier;
                oldRemainder = newRemainder;
                newRemainder -= PositionCount (tier);
            } while (newRemainder > 0);
            coordinates.tier = tier;
            coordinates.index = oldRemainder;
            return new Coordinates { tier = tier, index = oldRemainder };
            //return coordinates;
        }
        /// <summary>
        /// gibt die Anzahl der Positionen in einer Stufe tier zurück
        /// </summary>
        /// <param name="tier"></param>
        /// <returns></returns>
        private static int PositionCount (int tier) {
            if (tier == 0) {
                return 1;
            } else {
                return 8 * tier;
            }
        }

        private static int manhattanDistanceFromCenter(Coordinates position)
        {
            if(position.tier==0)
                return 0;
            else
            {
                int n = position.tier;
                int i = position.index;
                int reduzIndex=i%(2*n);
                int indexCenterOfLine=n-1;
                int distanceToCenterOfLine=Math.Abs(reduzIndex-indexCenterOfLine);
                return n+distanceToCenterOfLine;
            }
        }
    }
}
