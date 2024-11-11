using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public AudioClip radioClip;
    public AudioSource source;


    void Start()
    {
        source.clip = radioClip;


    }

    public void PlayClip()
    {
    source.Play();
    
    
    }
}
