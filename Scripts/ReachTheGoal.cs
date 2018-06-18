using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReachTheGoal : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("LevelPassed");

            Debug.Log("Current highest score is: " + DataManagement.dataManagement.HighScore);

            DataManagement.dataManagement.TotalScore = Score.CurrentScore = Score.CurrentScore + (int)(GameTimer.TimeLeft * 10);

            if (DataManagement.dataManagement.TotalScore > DataManagement.dataManagement.HighScore)
            {
                DataManagement.dataManagement.HighScore = DataManagement.dataManagement.TotalScore;
                Debug.Log("Total score: " + DataManagement.dataManagement.TotalScore);
                Debug.Log("Congratulation! You exceed the highest score. New high score is: " + DataManagement.dataManagement.HighScore);
            }

            DataManagement.dataManagement.SaveData();
        }
    }
}
