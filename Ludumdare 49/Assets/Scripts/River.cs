using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River/*forgeGames*/ : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
