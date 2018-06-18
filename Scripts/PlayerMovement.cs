using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D PlayerRB;
    public Animator anim;

    public int PlayerSpeed = 10;
    public int JumpPower = 2000;
    public bool IsGrounded;

    public float PlayerBottomDistance = 1.16f;

    private float moveX;

	void Update ()
    {
        PlayerMove();
        PlayerRaycast();

        if (gameObject.transform.position.y < -6.3)
        {
            SceneManager.LoadScene("Gameover");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void PlayerMove()
    {
        //Control
        moveX = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump") && IsGrounded == true)
        {
            Jump();
        }

        //Animation
        if (moveX == 0.0 && IsGrounded == true)
        {
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsJumping", false);
        }
        else if (moveX != 0.0 && IsGrounded == true)
        {
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsJumping", false);
        }
        else if (IsGrounded == false)
        {
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsJumping", true);
        }

        //Direction
        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //Physics
        PlayerRB.velocity = new Vector2(moveX * PlayerSpeed, PlayerRB.velocity.y);
    }

    void Jump()
    {
        PlayerRB.AddForce(Vector2.up * JumpPower);
        IsGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }

    void PlayerRaycast()
    {
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down);

        if (hitDown != null && hitDown.collider != null && hitDown.distance < PlayerBottomDistance && hitDown.collider.tag == "Enemy")
        {
            PlayerRB.AddForce(Vector2.up * 1500);
            Score.CurrentScore += 10;
        }
    }
}
