using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
     Process pour ajouter un prefab : ajouter depuis sa source l'objet à la hierarchie, lui applique rce que l'on souhaite, comme
     un box collider, script, etc, et ensuite glisser l'object depuis la hierachie vers le dossier Prefabs.

     L'objet dans la hierarchie peut ensuite être supprimer, si l'on souhaite qu'il n'apparaise pas depuis le départ.
     */
    private Rigidbody playerRb;
    public float speed = 5.0f;
    private GameObject focalPoint;
    public GameObject powerUpIndicator;

    // Serialize field permet d'avoir une lecture de la valeur de la variable même si variable est privée
    [SerializeField]
    private bool hasPowerup = false;

    private float powerupStrength = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {       
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine() 
    {
        // yield permet de déclencher l'attente de 7, soit la durée du pouvoir
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with " + gameObject.name + " with powerup set to " + hasPowerup);

            enemyRB.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
