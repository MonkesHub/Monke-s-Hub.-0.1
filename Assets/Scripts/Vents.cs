using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vents : MonoBehaviour
{
    public GameObject vent;

    private void OnTriggerEnter(Collider other) 
    {
        vent.SetActive(false);
    }

    private void OnTriggerExit(Collider other) 
    {
        vent.SetActive(true);
    }
}
