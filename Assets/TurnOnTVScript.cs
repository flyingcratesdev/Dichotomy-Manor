using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class TurnOnTVScript : MonoBehaviour
{

    public GameObject tvRemote;    
    public Rigidbody remoteBody;

    public VideoPlayer vp;
    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        remoteBody = tvRemote.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision Collision)
    {
        vp.Play();
    }
}
