using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500.0f;
    private float speedBoost = 1200.0f;
    private GameObject focalPoint;

    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;

    private float normalStrength = 10.0f; // how hard to hit enemy without powerup
    private float powerupStrength = 25.0f; // how hard to hit enemy with powerup

    /* Mettre le prefab en enfant du focal point dans Player, et glisser ce prefab dans la variable dans Player
       et non direcement le prefab du dossier Prefabs */
    public ParticleSystem smokeParticle;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        // Add force to player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(focalPoint.transform.forward * verticalInput * speedBoost * Time.deltaTime, ForceMode.Impulse);            
            smokeParticle.Play();
        }
        else
        {           
            playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);

            // Set powerup indicator position to beneath player
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            smokeParticle.Stop();
        }
    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            //not this sentence : Vector3 awayFromPlayer =  transform.position - other.gameObject.transform.position;
            // Calculation is enemy position - player's position to give the proper Vector (Distance + direction) force
            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position);

            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }
        }
    }
}
