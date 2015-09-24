using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnControl : MonoBehaviour
{
    public Canvas inGame, GameOver;
    public GameObject particles;
    public Text ScoreLabel, HighScore, FinalScore;
    int score;
    const float ANGLESTEP = 6.75f, DISTANCE = 15.3f;
    float[] yPositions = new float[] { 2.423977f, 0.8602456f, -0.7363977f, -2.33395f };
    Ray cameraRay;
    RaycastHit hit;
    void Start()
    {
        Time.timeScale = 1;
        score = 0;
        HighScore.text = string.Format("High Score: {0}", PlayerPrefs.GetInt("HighScore"));
    }
    void Update()
    {
        cameraRay = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(cameraRay.origin, cameraRay.direction * 20, Color.yellow);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(cameraRay, out hit, 20f))
            {
                if (hit.collider.tag == "Pickup")
                {
                    Instantiate(particles, hit.transform.position, new Quaternion(0, 90, 0, 0));
                    Pickup other = hit.collider.GetComponent<Pickup>();
                    Debug.Log("Beginning ReInit");
                    other.ReInitializeSelf();
                    score++;
                }
            }
        }

        ScoreLabel.text = string.Format("Score: {0}", score);
    }
    public void SetGameOver()
    {
        inGame.enabled = false;
        GameOver.enabled = true;
        Time.timeScale = 0;
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
        FinalScore.text = string.Format("Your Score: {0}", score);
    }

    public void Quit()
    {
        Application.LoadLevel(1);
    }
    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
