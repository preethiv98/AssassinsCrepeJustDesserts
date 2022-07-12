using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip general;

    AudioSource audioSource;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(general);
        }
    }
}
