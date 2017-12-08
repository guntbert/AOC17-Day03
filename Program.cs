using System;

namespace Day03 {
    class Program {
        struct Coordinates {
            public int tier; // Stufe: 0..
            public int index; // innerhalb einer Stufe: 1..            
        }
        static void Main (string[] args) {
            int i = 1;
            Console.WriteLine ($"{i}: {GetCoordinates(i)}");
            i = 5;
            Console.WriteLine ($"{i}: {GetCoordinates(i)}");
            i = 10;
            Console.WriteLine ($"{i}: {GetCoordinates(i)}");
        }

        /// <summary>
        /// gibt zu einem Element der Folge die Koordinaten 
        /// in der Form: Stufe(tier) und index zurück
        /// </summary>
        /// <param name="sequenceNumber"></param>
        /// <returns></returns>
        static Coordinates GetCoordinates (int sequenceNumber) {
            Coordinates coordinates = new Coordinates ();
            int newRemainder = sequenceNumber - 1;
            int oldRemainder;
            int tier = 1;
            do {
                oldRemainder = newRemainder;
                newRemainder -= PositionCount (tier);
                ++tier;

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
    }
}