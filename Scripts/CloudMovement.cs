using UnityEngine;

public class CloudMovement : MonoBehaviour {

    public float MoveDir = -0.05f;
	
	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(MoveDir, 0);
	}
}
