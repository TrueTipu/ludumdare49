using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River/*forgeGames*/ : MonoBehaviour
{
    PlayerMovement player;
    Bucket bucket;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player = collision.GetComponent<PlayerMovement>();
            if(player.handObject.ObjectName == "Bucket")
            {
                player.handObject.ChargeObject();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
