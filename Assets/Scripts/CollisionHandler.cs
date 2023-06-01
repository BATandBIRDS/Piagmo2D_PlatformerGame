using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{// For Enemies
    [SerializeField] float removeDelay = .5f;
    [SerializeField] ParticleSystem killingFX;

    AudioPlayer audioP;

    void Awake()
    {
        audioP = FindObjectOfType<AudioPlayer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Steel") { return; }
        KillEnemy();
    }

    void KillEnemy()
    {
        audioP.PlayExplosionClip();
        Instantiate(killingFX, transform.position, Quaternion.identity);
        Invoke("RemoveEnemy", removeDelay);
    }

    void RemoveEnemy()
    {
        Destroy(gameObject);
    }
}
