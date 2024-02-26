using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 moveDirection;
    private Rigidbody rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
       if(context.phase == InputActionPhase.Started)
        {
            Debug.Log("Jump");
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase != InputActionPhase.Performed) {

            Debug.Log("Move " + context.ReadValue<Vector2>().ToString());
            moveDirection = context.ReadValue<Vector2>();
        }
        
    }


    private void FixedUpdate()
    {

        Quaternion turnRotation = Quaternion.Euler(0f, moveDirection.x, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
        rb.AddForce(speed * transform.forward * moveDirection.y);
        //rb.MovePosition(rb.position + transform.forward * speed * moveDirection.y * Time.deltaTime);
              
    }

    /*
    private void Move(Vector2 direction)
    {
        // Handle movement based on the input direction
        Vector3 movement = new Vector3(direction.x, 0f, direction.y);
        transform.Translate(movement * Time.deltaTime, Space.World);
    }
    */
}
