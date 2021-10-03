using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeedDefault = 5f;
    float moveSpeed;

    public Rigidbody2D rb;

    Vector2 movement;

    public IHandObject handObject;

    [SerializeField]
    Bucket bucket;

    Reactor reactor;
    public bool river;

    private Animator anim;
    bool moving;

    public float radius;
    public Vector3 itemPos;

    private void Start()
    {
        anim = GetComponent<Animator>();
        handObject = bucket;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (handObject != null)
            {
                handObject.UseObject(river);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(handObject != null)
            {
                DropObject();
            }
            else
            {
                TryPickObject();
            }
        }
    }

    void TryPickObject()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D possibleHandObject in objects)
        {
            if(possibleHandObject.CompareTag("HandObject"))
            {
                FindObjectOfType<AudioManager>().Play("Pick");
                handObject = possibleHandObject.GetComponent<IHandObject>();
                handObject.GameObject.transform.SetParent(this.transform);
                handObject.GameObject.transform.localPosition = itemPos;
                break;
            }
        }
    }

    void DropObject()
    {
        FindObjectOfType<AudioManager>().Play("Drop");
        handObject.GameObject.transform.SetParent(null);
        handObject.GameObject.transform.position = transform.position;
        handObject = null;
    }

    private void FixedUpdate()
    {
        if (movement.x != 0 && movement.y != 0)
        {
            moveSpeed = moveSpeedDefault / 1.4f;
        }
        else moveSpeed = moveSpeedDefault;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (movement.x == 0 && movement.y == 0)
        {
            if (moving == true)
            {
                moving = false;
                anim.SetBool("isRunning", false);
                FindObjectOfType<AudioManager>().Stop("Kävely");
            }
        }
        else
        {
            if (moving == false)
            {
                moving = true;
                FindObjectOfType<AudioManager>().Play("Kävely");
            }
            anim.SetBool("isRunning", true);
        }
    }


}
