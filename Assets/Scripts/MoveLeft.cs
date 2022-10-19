using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public int score = 0;
    private float speed;
    private int speedInk;
    private float lastUpdate = 0;
    public Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerAnim = GameObject.Find("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = 10;

        if (playerControllerScript.isSuper)
            speedInk = 2;
        else
            speedInk = 1;

        if (!playerControllerScript.isGameOver)
        {
            playerAnim.SetFloat("Speed_f", speedInk);
            transform.Translate(Vector3.left * Time.deltaTime * speed * speedInk);
            if (Time.time - lastUpdate > 1f)
            {
                score += speedInk;
                lastUpdate = Time.time;
            }
        }
        if (transform.position.x < -10 && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
