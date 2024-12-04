using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.VisualScripting.Member;

public class SpawnKey : MonoBehaviour
{
    public GameObject keyPrefab;
    public FPSController controller;
    public GameObject NormalCam;
    public GameObject CineCam;
    public Animator anim;
    public GameObject playerUI;
    AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    


    public void SetKeyActive()
    {
        source.Play();
        Invoke("WaitTime", 4);
        playerUI.SetActive(false);
        controller.canMove = false;
        keyPrefab.SetActive(true);
        NormalCam.SetActive(false);
        CineCam.SetActive(true);
        anim.Play("ClockZoom");



    }

    void WaitTime()
    {
        playerUI.SetActive(true);
        controller.canMove = true;
        NormalCam.SetActive(true);
        CineCam.SetActive(false);
        anim.Play("ClockIdle");

    }
}
