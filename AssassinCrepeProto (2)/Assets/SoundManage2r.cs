using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManage2r : MonoBehaviour
{
    public AudioClip general;
    public AudioClip release;

    AudioSource audioSource;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(general);
        }
        if (Input.GetMouseButtonUp(0))
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(release);
        }
    }
}
