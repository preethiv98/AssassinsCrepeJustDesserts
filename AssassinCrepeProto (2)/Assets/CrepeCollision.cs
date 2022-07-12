using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrepeCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
    
        if(collision.collider.tag == "Decor")
            Debug.Log("You have placed a " + collision.collider.name);

    }
    //Not sure on which collider to use for interaction between 2d and 3d objects together+
    void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log("2d Object placed");
    }
}
