using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonhorror : MonoBehaviour
{
    public buttonmanager buttonmanager;
    public bool Pressed;
    public Material PressedMaterial;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(!Pressed)
        {
            Pressed = true;
            buttonmanager.PressedButton();
            meshRenderer.material = PressedMaterial;
        }
    }
}
