using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(TownGenerator))]
[CanEditMultipleObjects]
public class TownGeneratorEditor : Editor
{
    public override void OnInspectorGUI() {
        TownGenerator townGen = (TownGenerator)target;

        DrawDefaultInspector();

        if(GUILayout.Button("Generate")) {
            townGen.GenerateTown();
        }
    }
}
