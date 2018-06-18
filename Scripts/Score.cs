using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public Transform targetP;
    public static int CurrentScore;

    public Text scoreText;

    void Awake()
    {
        CurrentScore = 0;
    }

    void Update()
    {
        if (targetP == null)
        {
            targetP = GameObject.FindGameObjectWithTag("Player").transform;
        }
        scoreText.text = CurrentScore.ToString("0");
    }
}
