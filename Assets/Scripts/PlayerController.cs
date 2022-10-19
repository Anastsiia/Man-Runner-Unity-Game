using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    public ParticleSystem obstacleParticle;
    public ParticleSystem dirtyPartycle;
    public AudioClip jump;
    public AudioClip crash;
    private AudioSource playerSourse;
    private int jumpsCount = 0;
    public bool isGameOver;
    public bool isSuper;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerSourse = GetComponent<AudioSource>();
        playerRB.constraints = RigidbodyConstraints.FreezePositionX;
        Physics.gravity *= 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpsCount < 2 && !isGameOver)
        {
            playerRB.AddForce(Vector3.up * 10, ForceMode.Impulse);
            jumpsCount += 1;
            playerAnim.SetTrigger("Jump_trig");
            dirtyPartycle.Stop();
            playerSourse.PlayOneShot(jump, 0.3f);
        }
        if (Input.GetKeyDown(KeyCode.C))
            isSuper = !isSuper;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isGameOver)
        {
            jumpsCount = 0;
            dirtyPartycle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            isGameOver = true;
            obstacleParticle.Play();
            dirtyPartycle.Stop();
            playerSourse.PlayOneShot(crash, 0.3f);

        }
    }
}
