using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnCheck : MonoBehaviour
{
    LevelGenerator levelGenerator;
    void Start()
    {
        levelGenerator = FindObjectOfType<LevelGenerator>();
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
