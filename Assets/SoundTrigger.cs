using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<FPSController>())
        {
            source.clip = clip;
            source.Play();
        }
    }
}
