using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnCheck : MonoBehaviour
{
    LevelGenerator levelGenerator;
    [SerializeField] private GameObject Box;
    [SerializeField] private float MinX, MinZ;
    [SerializeField] private float MaxX, MaxZ;
    void Start()
    {
        levelGenerator = FindObjectOfType<LevelGenerator>();
        SpawnRandomBox();
    }
    void SpawnRandomBox()
    {
        Instantiate(Box,transform.parent.position + new Vector3(Random.Range(MinX, MaxX),1.75f,Random.Range(MinZ, MaxZ)), Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Movement>(out Movement player))
        {
            Vector3 Direction = (transform.position - player.transform.position).normalized;
            if (Direction.x > 0)
            {
                Debug.Log("SPAWN ON RIGHT");
                levelGenerator.SpawnOnRight();
            }
            else
            {
                Debug.Log("SPAWN ON LEFT");
                levelGenerator.SpawnOnLeft();
            }
            transform.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
