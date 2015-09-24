using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerControl : MonoBehaviour
{
    public GameObject scoreText;
    Image hexImage;
    public float fillAmount = 1, Multiplier = 5;
    void Start()
    {
        hexImage = this.GetComponent<Image>();
    }

    void Update()
    {
        hexImage.color = scoreText.GetComponent<ColorFader>().color;
        fillAmount -= (Time.deltaTime / Multiplier);
        if (fillAmount < 0)
        {
            fillAmount = 0;
            Camera.main.GetComponent<SpawnControl>().SetGameOver();
        }
        hexImage.fillAmount = fillAmount;
    }

    public void AddTime()
    {
        fillAmount += .4f;
        if (fillAmount > 1)
        {
            fillAmount = 1;
        }
    }
    public void AddTime(float amount)
    {
        fillAmount += amount;
        if (fillAmount > 1)
        {
            fillAmount = 1;
        }
    }
}
