using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset = new Vector3(0, 5, -7);
    // LateUpdate is called once per frame, after the update() of the gameObject player, for avoid sacade
    void LateUpdate()
    {
        //adding camera behin the player (if it s the same has the player the camera is under the vehicle)
        transform.position = player.transform.position + offset;
    }
}
