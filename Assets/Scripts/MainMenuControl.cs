using UnityEngine;
using System.Collections;

public class MainMenuControl : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        Application.LoadLevel(2);
    }
}
