using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float delay = 3.0f;

    // Update is called once per frame
    void Update()
    {
        delay = delay + Time.deltaTime;

        if(delay >= 3.0)
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                delay = 0.0f;
            }
        } 
        
    }
}
