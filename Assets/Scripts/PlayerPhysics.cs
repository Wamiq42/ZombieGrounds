using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics
{
    private Vector3 velocity;
    private float gravity = -9.81f;
    private Transform groundCheck;
    private float groundRadius = 0.4f;
    private LayerMask groundLayerMask;
    private bool onGround;

    public void SetGroundCheckTransform(Transform transform)
    {
        groundCheck = transform;
    }
    public void SetGroundLayerMask(LayerMask layerMask)
    {
        groundLayerMask = layerMask;
    }


    public Vector3 Gravity()
    {
        onGround = Physics.CheckSphere(groundCheck.position, groundRadius, groundLayerMask);

        if (onGround)
        {
            velocity.y = 0f;
            //Debug.Log(velocity);
            //Debug.Log("if Condition");
            return velocity;
        }
        else
        {
            // v = 1/2 gt^2
            //Debug.Log(velocity);
            //Debug.Log("else Condition");
            velocity.y += (gravity * Time.deltaTime);
            return velocity;
        }
       
    }
}
