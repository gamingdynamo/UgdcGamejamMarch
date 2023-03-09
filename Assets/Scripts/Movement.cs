using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody body;
    public float movespeed;
    public Camera cam;
    public Vector3 Offset;
    public Quaternion rotation;
    public float MovementSensitivity = 0.5f;
    private float Horizontal, Vertical;
    public float TurnSmoothTime = 0.1f;
    float TurnSmoothVel;
    public Animator animator;
    public float AnimationSmoothness = 0.1f;
    private float targetangle;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(Horizontal, 0f, Vertical).normalized;

       // body.velocity = new Vector3(Input.GetAxis("Horizontal"),0f, Input.GetAxis("Vertical"))*movespeed;
       
        cam.transform.rotation = rotation;
         targetangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        //   float targetangle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
      


      //  float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetangle , ref TurnSmoothVel , TurnSmoothTime );

        body.MovePosition(body.position + direction * movespeed * Time.deltaTime);

       
        if (direction.magnitude != 0)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * TurnSmoothTime);
        }


        if (direction.magnitude > 0.1f)
        {
            animator.SetFloat("Blend", 1f, AnimationSmoothness,Time.deltaTime);   
            
        }
        else
        {
            animator.SetFloat("Blend", 0 , AnimationSmoothness , Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, body.transform.position - Offset, MovementSensitivity * Time.deltaTime);
        // cam.transform.LookAt(body.transform.position);
        transform.rotation = Quaternion.Euler(0f, targetangle, 0f).normalized;
    }
}
