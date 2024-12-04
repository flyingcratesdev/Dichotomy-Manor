using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertRed : MonoBehaviour
{
    public InsertManager manager;
    public MeshRenderer render;
    public Material setColor;
    public void InsertBlock()
    {
        print("RED");
        render.material = setColor;
        manager.SetBlock(true);



    }
}
