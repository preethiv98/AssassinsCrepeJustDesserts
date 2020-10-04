using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoratingCheck : MonoBehaviour

{
    private bool playerInBounds;
    public static double gameScore = 0;

    void OnTriggerStay2D(Collider2D decor)
    {

       if (decor.gameObject.name == "blueberry" || decor.gameObject.name == "strawberry")
       {
            playerInBounds = true;
             Debug.Log("test success");

       }
    }

    void OnTriggerExit2D(Collider2D decor)
    {
        if (decor.gameObject.name == "blueberry" || decor.gameObject.name == "strawberry")
        {
            playerInBounds = false;
            Debug.Log("test fail");
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && playerInBounds)
        {
            gameScore = gameScore + 1;
            Debug.Log(gameScore);
        }
    }
}
