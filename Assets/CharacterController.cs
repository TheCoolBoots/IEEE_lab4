using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed = 6;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer sprite;

    public bool shoot = false;

    void Start()
    {
        
    }

    void Update()
    {
        /*        if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    rigidbody2.position = new Vector2(rigidbody2.position.x, rigidbody2.position.y + moveSpeed);
                    Debug.Log("move up");
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    rigidbody2.position = new Vector2(rigidbody2.position.x, rigidbody2.position.y - moveSpeed);
                }
                else
                {
                    rigidbody2.position = new Vector2(rigidbody2.position.x, rigidbody2.position.y);
                }*/



        float x = Input.GetAxisRaw("Horizontal");
        float moveX = x * moveSpeed;

        if (moveX < -.1)
        {
            sprite.flipX = true;
        }
        else if(moveX > .1)
        {
            sprite.flipX = false;
        }



        float y = Input.GetAxisRaw("Vertical");
        float moveY = y * moveSpeed;
        rb.velocity = new Vector2(moveX, moveY);

        animator.SetFloat("xSpeed", System.Math.Abs(moveX));
        animator.SetFloat("ySpeed", System.Math.Abs(moveY));
    }
}
