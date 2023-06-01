using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Mover : MonoBehaviour
{
    [SerializeField] float moveSpeedFactorBG = .1f;
    
    Vector2 moveInputBG;
    Material material;

    PlayerMovement playerMovement;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        moveInputBG = new Vector2(playerMovement.GetPlayerVelocity() * moveSpeedFactorBG, 0);
        material.mainTextureOffset += moveInputBG;
    }
}
