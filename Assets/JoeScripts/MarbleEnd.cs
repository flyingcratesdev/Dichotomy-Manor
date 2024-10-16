using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleEnd : MonoBehaviour
{
    public GameObject answer;
    public MarbleControl interactor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Ball>())
        {
            answer.SetActive(true);
            interactor.ExitMaze();

        }
    }
}
