using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    [Header("Important")]
    [SerializeField] private NavMeshAgent agent;
    private Transform player;

    [Header("Materials")]
    [SerializeField] Material playerIsCloseMaterial;
    [SerializeField] Material isFriendMaterial;
    [SerializeField] Material goodFriendMaterial;
    [SerializeField] Material badFriendMaterial;

    public FriendsCounter friends;

    [Header("Good or bad friend")]
    [SerializeField] public bool goodFriend;

    public bool isFriend = false;
 
    private float distanceToPlayer;

    private Vector3 offset;

    private bool canGo = true;

	private enum NpcType{
        GoRandom,
        GoAroundPlayer,
        GoAwayFromPlayer
	}

    [Header("Npc type")]
    [SerializeField] private NpcType state;

    private void Start()
    {
        friends = GameObject.FindObjectOfType<FriendsCounter>();
      
        
    }
    void Update()
    {
        //If you want then you can enable!
        // transform.LookAt(player.transform.position);

        player = GameObject.FindGameObjectWithTag("Player").transform;

        switch (state) {
            case NpcType.GoRandom:
                if (canGo)
                {
                    SetRandomDestination();
                    canGo = false;
                    Invoke("Delay", 7f);
                }
                break;
            case NpcType.GoAroundPlayer:
                if (canGo)
				{
                    SetDestinationAroundPlayer();
                    canGo = false;
                    Invoke("Delay", 7f);
                }
                break;
            case NpcType.GoAwayFromPlayer:
                if (canGo)
                {
                    SetDestinationAwayFromPlayer();
                    canGo = false;
                    Invoke("Delay", 7f);
                }
                break;
        }

        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= 1.75f && isFriend == false)
		{
            transform.GetChild(0).GetComponent<MeshRenderer>().material = playerIsCloseMaterial;
           

            if (Input.GetKeyDown(KeyCode.E))
			{
                isFriend = true;
                GameObject.FindObjectOfType<FriendsCounter>().AddFriendsNumber(goodFriend);
                GameObject.FindObjectOfType<AudioManager>().PlaySound("AddGoodFriend");
  
			}

            if (Input.GetKeyDown(KeyCode.F) && GameObject.FindObjectOfType<PlayerTasks>().killFriend && !goodFriend)
			{
                Destroy(gameObject);
                GameObject.FindObjectOfType<PlayerTasks>().killFriend = false;

            }

        }
        else if (distanceToPlayer > 2.5 && isFriend == false)
        {
           
            if (goodFriend)
            {
                transform.GetChild(0).GetComponent<MeshRenderer>().material = goodFriendMaterial;
            }

            else
            {
                transform.GetChild(0).GetComponent<MeshRenderer>().material = badFriendMaterial;
              
            }
        }
        else if (isFriend) { transform.GetChild(0).GetComponent<MeshRenderer>().material = isFriendMaterial; }

        if (isFriend)
		{
            Destroy(gameObject, 7f);
		}
      
    }

    private void SetRandomDestination()
	{
        agent.SetDestination(new Vector3(Random.Range(-500, 500), 0f, Random.Range(-500, 500)));
	}

    private void SetDestinationAroundPlayer()
	{
        offset = new Vector3(Random.Range(-8f, 8f), 0f, Random.Range(-8f, 8f));

        agent.SetDestination(player.position + offset);
	}

    private void SetDestinationAwayFromPlayer()
	{
        offset = new Vector3(Random.Range(Random.Range(-25f, -15f), Random.Range(15f,25f)), 0f, Random.Range(Random.Range(-25f, -15f), Random.Range(15f, 25f)));

        agent.SetDestination(player.position + offset);
    }

    private void Delay()
    {
        canGo = true;
    }




}
