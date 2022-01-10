using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 1200.0f;
    public float slowSpeed = 0.02f;
    public float rotationSpeed = 60.0f;
    public float verticalInput;

    //right and left, -1 and 1
    private float horizontalInput;

    private Vector3 forward = new Vector3(0, 0, 1);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        horizontalInput = Input.GetAxis("Horizontal");
        
        // move the plane forward at a constant rate automatically
        transform.Translate(forward * Time.deltaTime * speed);

        if (Input.GetKey("r"))
        {
            speed = speed - slowSpeed;
            // slowdown           
            transform.Translate(forward * Time.deltaTime * speed);
        }
        
        // tilt the plane up/down based on up/down arrow keys
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
        

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);     

    }
}
