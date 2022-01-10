using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerController : MonoBehaviour
{
    private float rotationSpeed = 45.0f;
    //initialize to none rotation
    private Quaternion currentRotation = Quaternion.identity;
    private Vector3 eulerAngles = new Vector3(0, 0, 90);
    private Vector3 currentEulerAngles;

    // Update is called once per frame
    void Update()
    {
        currentEulerAngles += eulerAngles * Time.deltaTime * rotationSpeed;
        currentRotation.eulerAngles = currentEulerAngles;
        transform.rotation = currentRotation;
    }
}
