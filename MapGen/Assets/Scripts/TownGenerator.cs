using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TownGenerator : MonoBehaviour
{
    public MapGenerator mapGenerator;
    public Color townColor;

    public int townCount;

    public int townRegionIndex;

    MapDisplay display;

    void Start() {
        display = FindObjectOfType<MapDisplay>();
    }
    public void GenerateTown() {     
        Color[] colorMap = mapGenerator.getColorMap();

        int randIndex = Random.Range(0,colorMap.Length);

        while(!(colorMap[randIndex] == mapGenerator.regions[townRegionIndex].color)) {
            randIndex = Random.Range(0,colorMap.Length);
        }

        mapGenerator.setColor(townColor, randIndex);
        mapGenerator.DisplayColorMap();
    }
}
