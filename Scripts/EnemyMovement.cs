using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D EnemyRB;
    public Animator anim;

    public int EnemySpeed = 2;
    public int XMoveDir;

    private int delay = 10;
    private bool RightDirection = false;

    public Sprite dead;

    void Update ()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2 (XMoveDir, 0));
        EnemyRB.velocity = new Vector2(XMoveDir, 0) * EnemySpeed;

        if (hit != null && hit.collider != null && hit.distance < 0.8f)
        {
            FlipEnemy();
            if (hit.collider.tag == "Player")
            {
                Destroy(hit.collider.gameObject);
                SceneManager.LoadScene("Gameover");
            }
        }

        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (hitUp != null && hitUp.collider != null && hitUp.distance < 1.9f && hitUp.collider.tag == "Player")
        {
            GetComponent<SpriteRenderer>().sprite = dead;
            //Debug.Log(hitUp.distance);
            EnemySpeed = 0;
            XMoveDir = 0;
            Invoke("SelfDestroy", delay * Time.deltaTime);
        }
    }

    void FlipEnemy()
    {
        if (XMoveDir > 0)
        {
            XMoveDir = -1;
        }
        else
        {
            XMoveDir = 1;
        }
        RightDirection = !RightDirection;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
