using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUpScript : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForPickup = 100;

    bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player"&&!wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSessionScript>().AddScore(pointsForPickup);
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
        
    }
}
