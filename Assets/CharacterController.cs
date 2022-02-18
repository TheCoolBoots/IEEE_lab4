using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed = 6;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float shotspeed = 15f;

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

        animator.SetFloat("speed", System.Math.Abs(moveX + moveY));

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = new Vector2(shotspeed, 0);
            animator.SetBool("shoot", true);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = new Vector2(-shotspeed, 0);
            animator.SetBool("shoot", true);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = new Vector2(0, shotspeed);
            animator.SetBool("shoot", true);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = new Vector2(0, -shotspeed);
            animator.SetBool("shoot", true);
        }
        else
        {
            animator.SetBool("shoot", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colliding");
    }
}
