using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{


    public bool IsRoaming;
    public Transform player , dest1 , dest2 ,dest3 , dest4;
    public NavMeshAgent agent;
    public bool ReachedDest2, ReachedDest3, ReachedDest4;

    // Update is called once per frame
    void Update()
    {
        do
        {
            agent.destination = dest1.transform.position;

        } while (ReachedDest4 == true);

        while (ReachedDest2 == true)
        {
            agent.destination = dest2.transform.position;
        }
    }
}
