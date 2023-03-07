using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;

    private Vector3 offset;

    private bool canGo = true;

    private Bounds bndFloor;

	private enum NpcType{
        Npc1,
        Npc2,
        Npc3
	}

    [SerializeField] private NpcType state;

	private void Start()
	{
        bndFloor = GameObject.Find("Terrain").GetComponent<Renderer>().bounds;
	}

	void Update()
    {
        switch (state) {
            case NpcType.Npc1:
                if (canGo)
                {
                    SetRandomDestination();
                    canGo = false;
                    Invoke("Delay", 7f);
                }
                break;
            case NpcType.Npc2:
                if (canGo)
				{
                    SetDestinationAroundPlayer();
                    canGo = false;
                    Invoke("Delay", 7f);
                }
                break;
            case NpcType.Npc3:
                break;
        }
    }

    private void SetRandomDestination()
	{
        float x = Random.Range(bndFloor.min.x, bndFloor.max.x);
        float z = Random.Range(bndFloor.min.z, bndFloor.max.z);

        agent.SetDestination(new Vector3(x, 0f, z));
	}

    private void SetDestinationAroundPlayer()
	{
        offset = new Vector3(Random.Range(-8f, 8f), 0f, Random.Range(-8f, 8f));

        agent.SetDestination(player.position + offset);
	}

    private void Delay()
    {
        canGo = true;
    }
}
