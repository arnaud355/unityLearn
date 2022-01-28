using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 100.0f;
    private float zbound = 6.0f;
    private Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstraintPlayerPosition();
    }
    // Move the player base on key arrows
    void MovePlayer()
    {
        //via le Input on obtient des touches déjà définies, valeur vont de -1 à 1
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRB.AddForce(Vector3.right * speed * horizontalInput);
        playerRB.AddForce(Vector3.forward * speed * verticalInput);
    }
    // Prevent player to leave the top or bottom
    void ConstraintPlayerPosition()
    {
        if (transform.position.z > zbound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zbound);
        }

        if (transform.position.z < -zbound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zbound);
        }
    }
}
