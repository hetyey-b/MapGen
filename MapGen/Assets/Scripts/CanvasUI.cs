using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public InputField seedText;
    public MapGenerator mapGenerator;
    public Text errorText;
    public const string seedErrorText = "Seed can only be an integer!";
    // Start is called before the first frame update
    void Start()
    {
        seedText.text = mapGenerator.seed.ToString();
    }

    public void HandleInputChange() {
        int parsedResult;

        if(int.TryParse(seedText.text, out parsedResult)) {
            errorText.text = "";
            mapGenerator.seed = int.Parse(seedText.text);
        } else {
            errorText.text = seedErrorText;
        }
    }

    void Update() {
        Vector2 inputV2;
        inputV2.x = Input.GetAxisRaw("Horizontal") * (-moveSpeed);
        inputV2.y = Input.GetAxisRaw("Vertical") * (-moveSpeed);

        mapGenerator.offset += inputV2;
        mapGenerator.GenerateMap();
    }
}
