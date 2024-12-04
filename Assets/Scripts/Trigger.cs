using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public string keyName;
    public AudioSource music;
    public AudioClip musicClip;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void CheckKey(string key)
    {
        print(key);
        if(keyName.Equals(key))
        {
            
            music.clip = musicClip; 
            music.Play();
            Destroy(this.gameObject);

        }


    }
}
