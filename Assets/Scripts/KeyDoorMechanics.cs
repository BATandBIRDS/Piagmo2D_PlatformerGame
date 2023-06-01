using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class KeyDoorMechanics : MonoBehaviour
{//Subject of DoorDestroyer.cs

    [SerializeField] int enoughCoinToOpenGoldenDoor = 15;
    AudioPlayer ap;
    GameSession gs;
 
    public static event Action RedDoor;
    public static event Action GreenDoor;
    public static event Action AllCoins;


    void Awake()
    {
        gs = FindAnyObjectByType<GameSession>();
        ap = FindObjectOfType<AudioPlayer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("coin"))
        {
            ap.PlayCoinClip();
            gs.AddOneMoreCoin();
            gs.UpdateCoinTxt();
            Destroy(other.gameObject);
            HaveAllCoins();
        }
        else if (other.CompareTag("redDiamond")) 
        { 
            RedDoor?.Invoke();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("greenDiamond")) 
        { 
            GreenDoor?.Invoke();
            Destroy(other.gameObject);
        }
    }

    void HaveAllCoins()
    {
        if(gs.GetCoinNum() == enoughCoinToOpenGoldenDoor)
        {
            AllCoins?.Invoke();
        }
    }
}
