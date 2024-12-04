using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HintReturn : MonoBehaviour
{
    public Button switchButton;
    public string ManorPlayRedo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonPress()
    {
        SceneManager.LoadScene(ManorPlayRedo);
    }
}
