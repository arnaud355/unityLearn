using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    /* Pour les animations il faut un component Animator sur le gameObjet dans la hiérarchie (Player par exemple),
       pn crée ensuite un objet de la classe Animator sur lequel on aura des methods, avec en parametres le nom des variables animations...
     */
    private Animator playerAnim;
    /* Pour les effets : ParticleSystem doit être public, car en dehors du system, on ajoute les sons sur les variables
       sur le gameObjet, par exemple on crée variabe explosionParticle et on lui met l'effet que l'on souhaite       
     */

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    /* Pour les sons : On ajoute un component AudioSource sur le gameObjetc que l'on veut (sons général sur la caméra)
       sur les gameObjet, par exemple on crée variabe jumpSound et on lui met le son que l'on souhaite      
     */
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10.0f;
    public float jumpForceD = 14.0f;
    public float gravityModifier;
    public bool isJumping = true;
    public bool doubleJumping = false;
    public bool speedUpPlayer = false;
    public bool isSpeedUpPlayer = false;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJumping && !gameOver && !doubleJumping)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isJumping = false;
            doubleJumping = true;
            playerAudio.PlayOneShot(jumpSound,1.0f);
            dirtParticle.Stop();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !gameOver && doubleJumping)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isJumping = false;
            doubleJumping = false;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();
        }

        if (Input.GetKeyDown(KeyCode.S) && isJumping && !gameOver && !doubleJumping)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isJumping = false;
            doubleJumping = true;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (speedUpPlayer)
            {
                isSpeedUpPlayer = true;
                isJumping = true;
                doubleJumping = false;
                dirtParticle.Play();
            }
            else
            {
                isSpeedUpPlayer = false;
                isJumping = true;
                doubleJumping = false;
                dirtParticle.Play();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            Debug.Log("Game Over !");
        }
    }
}
