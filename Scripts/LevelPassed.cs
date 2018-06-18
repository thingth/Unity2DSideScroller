using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPassed : MonoBehaviour {

    public Text scoreText;
    public Text HscoreText;

    void Update()
    {
        scoreText.text = DataManagement.dataManagement.TotalScore.ToString("0");
        HscoreText.text = DataManagement.dataManagement.HighScore.ToString("0");
    }
}
