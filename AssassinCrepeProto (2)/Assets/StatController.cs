using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour
{
    public GameStats stat;
    // Start is called before the first frame update
    void Start()
    {
        stat = GameObject.Find("StatController").GetComponent<GameStats>();
        //GameObject.Find("StatController").GetComponent<GameStats>() = stat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
