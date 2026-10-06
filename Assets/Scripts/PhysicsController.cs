using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    //PSEUDO CODE: Declare private variable of type RigidBody, public float speed;
    [SerializeField] private Rigidbody rb;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        // Initialize RigidBody variable by getting from current gameobject;
        rb = GetComponent<Rigidbody>();
    }
    // Fixed Update is called once per frame - use fixed Update for physics
    void FixedUpdate()
    {
        // Check for "a", "d", "w", and "d" key input, for each, add force vector3s going left, right, forward, and back
        if(Input.GetKey("a"))
        {
           rb.AddForce(Vector3.left * speed);
        }   
        if(Input.GetKey("d"))
        {
           rb.AddForce(Vector3.right * speed);
        }
        if(Input.GetKey("w"))
        {
           rb.AddForce(Vector3.forward * speed);
        }
       if(Input.GetKey("s"))
        {
           rb.AddForce(Vector3.back * speed);
        }

        //Stretch Task - add multiple to increase force
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


    }
//Stretch Tasks
// Unity Rollaball (Combines forces in Vector https://learn.unity.com/project/roll-a-ball-tutorial )
// Intermediate controllers https://medium.com/ironequal/unity-character-controller-vs-rigidbody-a1e243591483