using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEgg : MonoBehaviour
{
    [SerializeField]
    private GameObject egg;

    [SerializeField]
    private Transform SpawnPosition;

    private GameObject objectEgg;

    public void SpawnObject()
    {
        objectEgg = Instantiate(egg, SpawnPosition.position, SpawnPosition.rotation);
        
        objectEgg.GetComponent<UpdateCursor>().enabled = true;
        egg = objectEgg;
    }
}
