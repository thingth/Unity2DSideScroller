using UnityEngine;

public class CoinPick : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            Score.CurrentScore += 1;
            Destroy(gameObject);
        }
    }
}
