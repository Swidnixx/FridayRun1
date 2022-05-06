using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float forceScale = 10;
    public float liftingForce = 10;
    private Rigidbody2D rb;
    private BoxCollider2D playerCollider;
    private bool doubleJumpFlag;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsGrounded())
            {
                Vector2 force = new Vector2(0, forceScale);
                //rb.AddForce(force);
                rb.velocity = force;

                doubleJumpFlag = false;
            }
            else if(!doubleJumpFlag)
            {
                Vector2 force = new Vector2(0, forceScale);
                rb.velocity = force;

                doubleJumpFlag = true;
            }
        }

        if(Input.GetMouseButton(0) && rb.velocity.y < 0)
        {
            rb.AddForce(Vector2.up * Time.deltaTime * liftingForce);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            PlayerDeath();
        }

        if(collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.CoinCollected();
        }
    }

    private void PlayerDeath()
    {
        GameManager.instance.GameOver();
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position + (Vector3)playerCollider.offset,

            playerCollider.bounds.size,
            0f,
            Vector2.down,
            0.1f,
            LayerMask.GetMask("Ground")
            );

        return hit.collider != null;
    }
}
