using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joshhsTutorialScript : MonoBehaviour
{
    public Transform tutorialSpawn;
    public Transform gorillaPlayer;
    private Collider[] colliders;
    private void Start()
    {
        colliders = FindObjectsOfType<Collider>();

        if (!PlayerPrefs.HasKey("Tutorial"))
        {
            foreach (Collider x in colliders)
            {
                x.enabled = false;
            }
            gorillaPlayer.position = tutorialSpawn.position;
            gorillaPlayer.rotation = tutorialSpawn.rotation;
            Debug.Log("Completed tutorial!");
            PlayerPrefs.SetString("Tutorial", "Completed");
            foreach (Collider c in colliders)
            {
                c.enabled = true;
            }
        }
    }
}
