using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class navtogveaway : MonoBehaviour
{
    // The NavMeshAgent component attached to this game object
    public NavMeshAgent agent;

    public string tagString = "chasetag";

    void Start()
    {
        //MADE BY SHREK
        //DO NOT DELITE THIS IF YOU MAKE A TUTORIAL FROM THIS SCRIPT GIVE ME CREDIT PLZ
    }

    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            agent.enabled = true;
            GameObject[] players = GameObject.FindGameObjectsWithTag(tagString);

            GameObject target = null;

            // Set the target to the closest player
            if (players.Length > 0)
            {
                float minDistance = float.MaxValue;
                foreach (GameObject player in players)
                {
                    float distance = Vector3.Distance(transform.position, player.transform.position);
                    if (distance < minDistance)
                    {
                            minDistance = distance;
                            target = player;
                    }
                }
            }

            // If we have a target, set the NavMeshAgent's destination to the target's position
            if (target != null)
            {
                    agent.destination = target.transform.position;
            }
        }
        else
        {
            agent.enabled = false;
        }
    }
}