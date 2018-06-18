using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public static float TimeLeft;
    public Text timerText;

    void Start()
    {
        TimeLeft = 100;
    }

    void Update()
    {
        TimeLeft -= Time.deltaTime;
        timerText.text = TimeLeft.ToString("0");

        if (TimeLeft < 0.1f)
        {
            SceneManager.LoadScene("Gameover");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
