using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorFader : MonoBehaviour
{
    private float r, g, b;
    const float STEP = 1 / 255;
    bool isLerping;
    Color color1, color2;
    public Color color;
    float lerpTimer = 0;

    void Start()
    {

    }

    void Update()
    {

        if (tag == "Object" || tag == "Pickup")
        {
            color = AdjustValues(this.GetComponent<Renderer>().material.color);
            this.GetComponent<Renderer>().material.color = color;
        }
        else if (tag == "Text" || tag == "HighScore")
        {
            color = AdjustValues(this.GetComponent<Text>().color);
            this.GetComponent<Text>().color = color;
        }


    }

    Color AdjustValues(Color baseColor)
    {
        lerpTimer += .01f;
        Color returnedColor = baseColor;

        if (isLerping)
        {
            if (baseColor == color2)
            {
                isLerping = false;
                lerpTimer = 0;
            }
            else
            {
                returnedColor = Color.Lerp(color1, color2, lerpTimer);
            }
        }
        else
        {
            if (baseColor == Color.red)
            {
                color1 = Color.red;
                color2 = Color.yellow;
            }
            else if (baseColor == Color.yellow)
            {
                color1 = Color.yellow;
                color2 = Color.green;
            }
            else if (baseColor == Color.green)
            {
                color1 = Color.green;
                color2 = Color.cyan;
            }
            else if (baseColor == Color.cyan)
            {
                color1 = Color.cyan;
                color2 = Color.blue;
            }
            else if (baseColor == Color.blue)
            {
                color1 = Color.blue;
                color2 = Color.magenta;
            }
            else if (baseColor == Color.magenta)
            {
                color1 = Color.magenta;
                color2 = Color.red;
            }
            isLerping = true;
        }


        return returnedColor;
    }
}
