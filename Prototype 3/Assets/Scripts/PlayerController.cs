using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce;
    public float gravityMod;
    public bool isOnGround = true;
    public bool gameOver = false;
    private int collisionNum = 0;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround &&! gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            collisionNum++;
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            Debug.Log("Game Over!");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            if (collisionNum == 1)
            {
                explosionParticle.Play();
            }
        }
    }
}
