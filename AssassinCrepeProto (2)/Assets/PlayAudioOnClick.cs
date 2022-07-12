using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnClick : MonoBehaviour
{
    public AudioClip sound;

    AudioSource audioSource;
   public void PlayAudio()
    {
        
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sound);
        
    }
}
