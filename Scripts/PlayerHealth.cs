using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public bool IsAlive = true;
    public float delayDur = 3f;
    public int Life = 3;
    
    void Update ()
    {
    	//TODO let player be able to play until life <= 0 before goto GameOver Scene
	if (gameObject.transform.position.y < -6.3 || Life <= 0 || GameTimer.TimeLeft < 0.1f)
        {
            IsAlive = false;
            Invoke("GameOver", delayDur);
        }
        /*else if (Life > 0)
        {
            IsAlive = true;
            Invoke("Restart", delayDur);
        }*/
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    void Restart()
    {
        Life -= 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
