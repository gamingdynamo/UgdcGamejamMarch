using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
	[SerializeField] private GameObject npcPrefab;
	[SerializeField] private Transform player;
	[SerializeField] private LayerMask groundMask;

	private Vector3 offset;
	private Vector3 pos;

	private bool canSpawn = false;

	private void Start()
	{
		for(int i = 0; i < 5; i++)
		{
			Spawn();
		}

		canSpawn = true;
	}

	private void Update()
	{
		if (canSpawn)
		{
			Spawn();
			canSpawn = false;
			Invoke("Delay", 5f);
		}
	}

	private void Spawn()
	{
		pos = new Vector3(player.position.x + Random.Range(-15f, 15f), 1f, player.position.z + Random.Range(-15f, 15f));

		GameObject npcClone = Instantiate(npcPrefab, pos, Quaternion.identity);

		if (Physics.Raycast(npcClone.transform.position, npcClone.transform.TransformDirection(Vector3.down), out RaycastHit hit, 50f, groundMask))
		{
			npcClone.transform.position = hit.point;
		}

		if (Random.value > 0.5f)
		{
			npcClone.GetComponent<Npc>().goodFriend = true;
		}

		else
		{
			npcClone.GetComponent<Npc>().goodFriend = false;
		}
	}

	private void Delay()
	{
		canSpawn = true;
	}
}
