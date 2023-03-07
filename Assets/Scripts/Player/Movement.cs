using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public event Action<Vector3> OnNewTileEntered;

    private Rigidbody body;
    private float TurnSmoothVel;
    [SerializeField] float movespeed;
    [SerializeField] float TurnSmoothTime;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(Horizontal, 0f, Vertical).normalized;
        body.MovePosition(body.position + direction * movespeed * Time.deltaTime);
       
        float targetangle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
        if(direction.magnitude != 0)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * TurnSmoothTime);
        }

       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            OnNewTileEntered?.Invoke(collision.gameObject.transform.position);
        }
    }
<<<<<<< HEAD
    // LOL
    //lOl-REDOOF
=======
>>>>>>> d4473b10172c0afb6e6e12326a27e03691f30a36
}
