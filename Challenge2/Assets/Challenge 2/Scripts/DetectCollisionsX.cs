using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    /*detect collisions et outofBounds sur tout les objects (le frappé et frappeur), mais rigidbody uniquement sur l'un des 2,
     on sait ainsi que le frappeur est gameObject et le frappé other.gameObject
     */
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        //The ball is destroyed
        Destroy(other.gameObject);
    }
}
