using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class TurnOnTVScript : MonoBehaviour
{

    public GameObject tvRemote;    
    private Rigidbody remoteBody;

    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision Collision)
    {
        videoPlayer.Play();
    }
}
