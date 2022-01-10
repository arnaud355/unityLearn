using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousBus : MonoBehaviour
{
    private Vector3 forward = new Vector3(0, 0, 1);
    public float speed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(forward * Time.deltaTime * speed);
    }
}
