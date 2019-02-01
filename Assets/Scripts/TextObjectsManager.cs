using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextObjectsManager : MonoBehaviour
{
    public GameObject textLayerPrefab;
    public int textLayers = 256;

    void Start()
    {
        for (int i=0;i<textLayers;i++) {
            GameObject textLayer = Instantiate(textLayerPrefab, gameObject.transform);
            textLayer.name = "Text" +(textLayers-1-i);
        }
    }

    private void Update()
    {
        // Reset all texts
        foreach (Transform child in transform) {
            Text text = child.gameObject.GetComponent<Text>();
            if (text?.text == "!") {
                text.text = "";
            }
        }
    }
}
