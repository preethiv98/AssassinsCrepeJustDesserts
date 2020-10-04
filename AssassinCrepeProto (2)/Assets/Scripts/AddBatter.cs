using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBatter : MonoBehaviour
{
    public GameObject batter;
    public GameObject crepe;
    void Start()
    {
        StartCoroutine(Wait());
    }

    
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(2);
        crepe.SetActive(true);
        batter.SetActive(false);
    }
}
