using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public LayerMask groundMask;

    private bool isOnGround;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        CheckJump();

        CheckOnGround();

        // player movement
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }

    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void CheckOnGround()
    {
        Vector2 direction = Vector2.down;
        float distance = 1f;

        //Debug.DrawRay(transform.position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, groundMask);
        if (hit.collider != null)
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }
}
