using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverGenerator : MonoBehaviour
{
    public MapGenerator mapGenerator;

    Vector2 riverCoordinates;
    public int waterRegionIndex;
    public int shoreRegionIndex;

    public int maxHeightRegionIndex;

/*    bool hasNeighbour(int x, int y, int neighbourRegionIndex, Color[] colorMap) {
        /*
        -1,-1   0,-1    1,-1    
        -1,0    0,0     1,0
        -1,1    0,1     1,1
        */
        
        return (colorMap[mapGenerator.])
    }*/

    public void GenerateRivers() {
        //Find random shore region next to water region, make it the first element
        Color[] colorMap = mapGenerator.getColorMap();

        int randIndex = Random.Range(0,colorMap.Length);

        while(!(colorMap[randIndex] == mapGenerator.regions[shoreRegionIndex].color)) {
            randIndex = Random.Range(0,colorMap.Length);
        }

        //Pick a direction away from the water

        //Move in that direction, till one of your neighbours is at least a level higher

        //Move to the higher neighbour

        //Repeat until you reach a max height region region
    }
}
