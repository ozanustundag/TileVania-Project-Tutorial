using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D myRigidbody2D;
    PlayerMovementScript player;

    [SerializeField] float bulletSpeed = 20f;
    float xSpeed;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovementScript>();
        xSpeed = player.transform.localScale.x*bulletSpeed;
    }

    void Update()
    {
        myRigidbody2D.velocity = new Vector2(xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
