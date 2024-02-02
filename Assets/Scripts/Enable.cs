using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
    [Header("Set this to the gameObject you want to Enable")]
    public GameObject ObjectToEnable;

    private void OnTriggerEnter(Collider other)
    {
        ObjectToEnable.SetActive(true);
    }
}