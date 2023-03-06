using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody body;
    public float movespeed;
    public Vector3 Offset;
    public float TurnSmoothTime;
    float TurnSmoothVel;

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(Horizontal, 0f, Vertical).normalized;
        body.velocity = direction * movespeed;
       
        float targetangle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
        transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * TurnSmoothTime);

    }

}
