using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MapGenerator : MonoBehaviour
{
    public enum DrawMode {NoiseMap, ColorMap};
    public DrawMode drawMode;

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;

    [Range(0,1)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public bool autoUpdate;

    public TerrainType[] regions;
    private Color[] colorMap;


    public Color[] getColorMap() { return colorMap; }

    public void setColor(Color color, int x, int y) {
        if(x >= mapWidth || y >= mapHeight) {
            return;
        }

        colorMap[CoordinateToColorMapIndex(x,y)] = color;
    }
    public void setColor(Color color, int colorMapIndex) {
        colorMap[colorMapIndex] = color;
    }

    public int CoordinateToColorMapIndex(int x, int y) {
        return y * mapWidth + x;
    }

    public void DisplayColorMap() {
        MapDisplay display = FindObjectOfType<MapDisplay>();
        
        display.DrawTexture(TextureGenerator.TextureFromColorMap(colorMap,mapWidth,mapHeight));
    }

    public void GenerateMap() {
        float[,] noiseMap = Noise.GenerateNoiseMap(seed,mapWidth,mapHeight,noiseScale,octaves,persistance,lacunarity,offset);

        colorMap = new Color[mapWidth * mapHeight];
        for(int y = 0; y < mapHeight; y++) {
            for(int x = 0; x < mapWidth; x++) {
                float currentHeight = noiseMap[x,y];
                
                for(int i = 0; i < regions.Length; i++) {
                    if(currentHeight <= regions[i].height) {
                        colorMap[CoordinateToColorMapIndex(x,y)] = regions[i].color;

                        break;
                    }
                }
            }
        }
        
        if(drawMode == DrawMode.NoiseMap) {
            MapDisplay display = FindObjectOfType<MapDisplay>();
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        } else {
            DisplayColorMap();
        }
    }

    void OnValidate() {
        if(mapWidth < 1) {
            mapWidth = 1;
        }
        if(mapHeight < 1) {
            mapHeight = 1;
        }
        if(lacunarity < 1) {
            lacunarity = 1;
        }
        if(octaves < 0) {
            octaves = 0;
        }
    }
}

[System.Serializable]
public struct TerrainType {
    public string name;
    public float height;
    public Color color;
}