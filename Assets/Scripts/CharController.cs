using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharController : MonoBehaviour
{
    //PSEUDO CODE: Declare float variables for speed, maxSpeed, acceleration, deceleration, rotation.
    [Header("Movement Settings")]
    [SerializeField] private float speed = 0f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float acceleration = 2f;
    [SerializeField] private float deceleration = 2f;
    [SerializeField] private float rotation = 100f;


    void Start()
    {
    }
    // Update is called once per frame.
    void Update()
    {
        // PSEUDO CODE: Check for space key input. If not max speed, accelerate, else decelerate.
        if (Input.GetKey(KeyCode.Space))
        {
            if (speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
            }
        }
        else
        {
            if (speed > 0)
            {
                speed -= deceleration * Time.deltaTime;
            }
        }
        // PSEUDO CODE: Use the speed and transform to move the object forward.
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // FUNCTION: Simplest transform with ACC, DEC, Speed (space bar), and TDT.

        // PSEUDO CODE: Check for left and right key inputs. Turn if left or right keys are pressed.
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, -rotation * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, rotation * Time.deltaTime);
        }
    }
}