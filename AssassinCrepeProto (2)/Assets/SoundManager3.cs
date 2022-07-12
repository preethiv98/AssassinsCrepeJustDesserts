using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager3 : MonoBehaviour
{
    public AudioClip mix;

    AudioSource audioSource;
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(mix);
        }
    }
}
