using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;

    private float turnSpeed = 45.0f;

    //right and left, -1 and 1
    private float horizontalInput;

    //up and down, -1 and 1
    private float verticalInput;

    // Update is called once per frame
    void Update()
    {
        //give a value between -1 and 1
        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");

        // Move of the vehicle forward base on verticalInput
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        // Rotate the vehicle base on horizontalInput
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
