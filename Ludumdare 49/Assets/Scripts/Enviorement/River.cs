using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River/*forgeGames*/ : MonoBehaviour
{
    PlayerMovement player;
    Bucket bucket;
    public bool firstTime = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<PlayerMovement>();
            player.river = true;
            if (firstTime == true)
            {
                TutorialText.NextLine();
                firstTime = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.river = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
