using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticale;
    public ParticleSystem dirtParticale;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public float jumpBorder;
    private int jumpCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }
      
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < 2 && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCounter += 1;
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticale.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }


        transform.position = new Vector3(jumpBorder, transform.position.y , transform.position.z);
            
        transform.rotation = Quaternion.Euler(0, 90, 0);


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticale.Play();
            jumpCounter = 0;
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {  
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticale.Play();
            dirtParticale.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
