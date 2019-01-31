using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Menezis {
    public class Rayman2Text {

        public string textContent;
        public Color textColor;
        public bool isCentered = false;

        private Rayman2Text() {}

        public static Rayman2Text ParseString(string raymanText)
        {
            Rayman2Text parsedText = new Rayman2Text();

            Regex colorRegex = new Regex("/o[0-9]{3}:");
            MatchCollection colorMatches = colorRegex.Matches(raymanText);

            if (colorMatches.Count > 0) {
                string colorCode = colorMatches[0].Value.Substring(2, 3); // For now only do first color code

                switch (colorCode) {
                    case "200": parsedText.textColor = new Color(0.98f, 0.275f, 0.275f); break; // Reddish
                    case "400": parsedText.textColor = new Color(1f, 1f, 0.471f); break; // Yellowish
                    case "600": parsedText.textColor = new Color(0.431f, 0.745f, 1f); break; // Blueish
                    default: parsedText.textColor = Color.white; break;
                }
            }

            foreach (Match match in colorMatches) {
                raymanText = raymanText.Replace(match.Value, ""); // Remove color codes from string
            }

            if (raymanText.StartsWith("/C:") || raymanText.StartsWith("/c:")) {
                parsedText.isCentered = true;
            }
            raymanText = raymanText.Replace("/C:", ""); // centering
            raymanText = raymanText.Replace("/c:", ""); // centering

            raymanText = raymanText.Replace("/L:", "\n");
            raymanText = raymanText.Replace("/l:", "\n");

            parsedText.textContent = raymanText;

            return parsedText;
        }

        // fn_p_stJFFTXTProcedure
        public static void DrawText(int textIndex, Vector3 position, string text, byte alpha)
        {
            // Coordinates are based on a 1000x1000 canvas:
            // 0,0 is top left
            // 1000,1000 is bottom right

            Canvas canvas = GameObject.Find("TextCanvas").GetComponent<Canvas>();

            Transform textTransform = canvas.transform.Find("Text" + textIndex);
            if (textTransform == null) {
                throw new System.Exception("No text object for index " + textIndex);
            }
            GameObject textObject = textTransform.gameObject;
            Text textComponent = textObject.GetComponent<Text>();
            textComponent.fontSize = 12 + (int)(position.z * 3f);

            textTransform.localPosition = new Vector3(-640 + (position.x / 1000) * 1280, 480 + (-position.y / 1000) * 960, 0);

            Rayman2Text r2Text = ParseString(text);

            textComponent.text = r2Text.textContent;

            if (r2Text.isCentered) {
                // Align upper center
                textTransform.localPosition = new Vector3(0, textTransform.localPosition.y, 0) - new Vector3(0, textComponent.preferredHeight/2, 0);
            } else {
                // Align upper left
                textTransform.localPosition = textTransform.localPosition - new Vector3(-textComponent.preferredWidth / 2, textComponent.preferredHeight / 2, 0);
            }

            textComponent.color = new Color(r2Text.textColor.r, r2Text.textColor.g, r2Text.textColor.b, ((float)alpha) / 255);
        }
    }
}
