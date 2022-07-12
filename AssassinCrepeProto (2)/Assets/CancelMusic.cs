using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelMusic : MonoBehaviour
{
    
    void Awake()
    {
       

        GameObject music = GameObject.FindWithTag("music");
        Destroy(music);
       
    }
}
