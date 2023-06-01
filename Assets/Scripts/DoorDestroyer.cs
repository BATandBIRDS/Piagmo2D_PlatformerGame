using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestroyer : MonoBehaviour
{// Observer of KeyDoorMechanics.cs
    
    [SerializeField] ParticleSystem explosionFX;
    [SerializeField] bool isRed;
    [SerializeField] bool isGreen;
    [SerializeField] bool isGold;

    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (isRed) { KeyDoorMechanics.RedDoor += DestroyDoor; }
        if (isGreen) { KeyDoorMechanics.GreenDoor += DestroyDoor; }
        if (isGold) { KeyDoorMechanics.AllCoins += DestroyDoor; }
    }

    void OnDestroy()
    {
        if (isRed) { KeyDoorMechanics.RedDoor -= DestroyDoor; }
        if (isGreen) { KeyDoorMechanics.GreenDoor -= DestroyDoor; }
        if (isGold) { KeyDoorMechanics.AllCoins -= DestroyDoor; }
    }

    void DestroyDoor()
    {
        if (gameObject == null) { return; }
        audioPlayer.PlayExplosionClip();
        Instantiate(explosionFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
