using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private Movement player;
    [SerializeField] private List<GameObject> Floors = new List<GameObject>();
    [SerializeField] private Vector3 InitialPosition;

    [SerializeField] private int LeftSpawnIndex;
    [SerializeField] private int RightSpawnIndex;

    public int NoofTileSpawned;
    private float TileXLength;
    private Vector3 CurrentTilePosition;

    void Start()
    {
        player = FindObjectOfType<Movement>();
        player.OnNewTileEntered += Player_OnNewTileEntered;
        InitialPosition = Vector3.zero;
        TileXLength = Floors[0].transform.localScale.x;
    }

    private void Player_OnNewTileEntered(Vector3 obj)
    {
        CurrentTilePosition = obj;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SpawnOnLeft();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnOnRight();
        }
    }
    
    public void SpawnOnLeft()
    {
        Debug.Log("Spawning on Left");
        GameObject newTile = Instantiate(Floors[0].gameObject, new Vector3((CurrentTilePosition.x) - TileXLength, 0, 0), Quaternion.identity);
    }
    public void SpawnOnRight()
    {
        Debug.Log("Spawning on Right");
        GameObject newTile = Instantiate(Floors[0].gameObject, new Vector3((CurrentTilePosition.x + NoofTileSpawned) + TileXLength, 0, 0), Quaternion.identity);
    }
}
