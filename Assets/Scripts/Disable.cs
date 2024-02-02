using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    [Header("Set this to the gameObject you want to Disable")]
    public GameObject ObjectToDisable;

    private void OnTriggerEnter(Collider other)
    {
        ObjectToDisable.SetActive(false);
    }
}