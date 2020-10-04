using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEggOnCrack : MonoBehaviour
{
    public GameObject egg;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Egg_FBX")
        {
            Debug.Log("Collided with bowl!");
            Destroy(egg);
        }
    }
}
