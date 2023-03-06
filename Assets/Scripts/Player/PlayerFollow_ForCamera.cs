using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow_ForCamera : MonoBehaviour
{
    public Transform Player;
    void Update()
    {
        transform.position = Player.transform.position;    
    }
}
