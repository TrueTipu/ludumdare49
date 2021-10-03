using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IFixableThing
{

    PlayerMovement player;

    //public GameObject effect;


    public void Fix()
    {
        Debug.Log("fixed");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<PlayerMovement>();
            player.handObject.FixableThing = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                if (player.handObject != null)
                {
                    player.handObject.FixableThing = null;
                }
            }
        }
    }
}
