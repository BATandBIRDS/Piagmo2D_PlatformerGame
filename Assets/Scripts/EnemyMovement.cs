using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    [SerializeField] bool hasToFlip = true;

    BoxCollider2D boxCollider2D;
    Rigidbody2D rb;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        moveSpeed = -moveSpeed;
        TurnBack();
    }

    void TurnBack()
    {
        if (!hasToFlip) { return; }
        transform.localScale = new Vector2(transform.localScale.x * -1, 1);
    }
}
