using System;
using System.Collections.Generic;

namespace Toboggan_Trajectory
{
    public class MapTreverser
    {
        public MapTreverser()
        {

        }

        public int TraverseSlope(List<string> slope)
        {
            var countOfTrees = 0;
            var currentLat = 0;

            for (int i = 0; i < slope.Count; i++)
            {
                if (IsTreeAtLatitude(slope[i], currentLat))
                    countOfTrees++;

                currentLat += 3;
            }
            return countOfTrees;
        }

        public bool IsTreeAtLatitude(string line, int latitude)
        {
            var singleInputLat = latitude % line.Length;            
            return line[singleInputLat].Equals('#');
        }

    }
}
