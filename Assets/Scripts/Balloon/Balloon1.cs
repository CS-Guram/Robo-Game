using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon1 : MonoBehaviour
{
    [SerializeField] Vector3 force;
    [SerializeField] Sprite[] balloonSprites;
    private UIManager UIMgr;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        UIMgr = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        rb = GetComponent<Rigidbody2D>();
        // Connect sprite reneder object
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Rendam index
        spriteRenderer.sprite = balloonSprites[Random.Range(0, 6)];
        // For BalloonSpawner
        transform.position = new Vector3(Random.Range(-7.00f,7.00f),transform.position.y,transform.position.z);
        
        force = new Vector3(Random.Range(-100, 100),Random.Range(150, 250), 0);
        rb.AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "topWall")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "bullet")
        {
            UIMgr.AddScore();
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
