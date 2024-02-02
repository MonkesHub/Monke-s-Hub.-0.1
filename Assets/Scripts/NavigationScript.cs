using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavigationScript : MonoBehaviour

{
    public GameObject Player;
    public GameObject Enemy;

    private int destPoint = 0;

    public NavMeshAgent agent;

    public Transform[] points;

    public float DetectionRange = 5f;

   
    

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        CheckForPlayerInRange();
    }
    void CheckForPlayerInRange()
    {
     
        if (Vector3.Distance(Player.transform.position, Enemy.transform.position) < DetectionRange)
        {
            agent.speed = 7.5f;
            Chase();
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                agent.speed = 5f;
                Wander();
            }
        }
    }
   
    void Wander()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
        
    }
    
    void Chase()
    {
        agent.destination = Player.transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DetectionRange);
    }
}
