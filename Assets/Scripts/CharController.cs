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

    [SerializeField] private float pushPower = 5f;


    private CharacterController _controller;

    private Vector3 _velocity = Vector3.zero;
    [SerializeField] private float Gravity = -9.81f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame.
    void Update()
    {
        // stretch task gravity section
    


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
                 speed = Mathf.Max(speed - (deceleration * Time.deltaTime), 0); // Ensure speed doesn't go below 0
             }

        }
        // PSEUDO CODE: Use the speed and transform to move the object forward.
        // PSEUDO CODE: Check for left and right key inputs. Turn if left or right keys are pressed.
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * -rotation * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * rotation * Time.deltaTime);
        }

        if (_controller.isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        else
        {
            _velocity.y += Gravity * Time.deltaTime;
        }


        Vector3 horizontalMovement = transform.forward * speed;
        Vector3 totalMovement = horizontalMovement + Vector3.up * _velocity.y   ;
        _controller.Move(totalMovement * Time.deltaTime);


   


    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //OnControllerColliderHit is called when the controller hits a collider while performing a Move.
        Rigidbody body = hit.rigidbody;
        

        if (body == null || body.isKinematic == true)
        {
            return;
        }
        else if (hit.moveDirection.y < -0.3f)
        {
            return;
        }
        else
        {
            Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            body.AddForce(pushDirection * pushPower, ForceMode.Impulse);
        }

    }
}