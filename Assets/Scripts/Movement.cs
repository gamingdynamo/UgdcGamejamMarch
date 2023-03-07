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

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(Horizontal, 0f, Vertical).normalized;

        body.velocity = new Vector3(Input.GetAxis("Horizontal"),0f, Input.GetAxis("Vertical"))*movespeed;
       
        cam.transform.rotation = rotation;

        float targetangle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, targetangle, 0f);

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetangle , ref TurnSmoothVel , TurnSmoothTime );
    }

    private void LateUpdate()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, body.transform.position - Offset, MovementSensitivity * Time.deltaTime);
       // cam.transform.LookAt(body.transform.position);
    }
}
