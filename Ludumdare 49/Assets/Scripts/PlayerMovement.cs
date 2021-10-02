using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeedDefault = 5f;
    float moveSpeed;

    public Rigidbody2D rb;

    Vector2 movement;

    IHandObject handObject;

    [SerializeField]
    Bucket bucket;
    private void Start()
    {
        handObject = bucket;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        if (movement.x != 0 && movement.y != 0)
        {
            moveSpeed = moveSpeedDefault / 1.4f;
        }
        else moveSpeed = moveSpeedDefault;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
