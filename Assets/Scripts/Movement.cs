using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isGrounded = true;
    Rigidbody2D rb;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Vector3 bulletForce;
    [SerializeField] ShootingSoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        speed = 15;
    }

void Shoot()
{
    GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
    
    Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
    
    // Multiply the bulletForce by the player's facing direction
    bulletRigidbody.AddRelativeForce(bulletForce * (isFacingRight ? 1f : -1f));

    Destroy(bullet, 3f);
    soundManager.PlaySound();
}


    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
    { 
        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (jumpPressed && isGrounded)
            Jump();
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        isGrounded = false;
        jumpPressed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

}
