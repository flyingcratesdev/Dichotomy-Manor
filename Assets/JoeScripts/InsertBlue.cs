using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertBlue : MonoBehaviour
{
    public InsertManager manager;
    public MeshRenderer render;
    public Material setColor;

    public void InsertBlock()
    {
        render.material = setColor;
        manager.SetBlock(false);



    }
}
