using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class Item : ScriptableObject
{
    public Sprite visualItem;
    public string nameItem;
    public bool isBook;
    public string[] bookText;
    public Vector3 localPosition;
    public Vector3 localRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
