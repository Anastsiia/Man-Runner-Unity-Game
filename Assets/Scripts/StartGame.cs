using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    private static GameObject player;
    private Vector3 endPos = new Vector3(2.7f,0,0);


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player.GetComponent<PlayerController>().isGameOver = true;
        player.GetComponent<Animator>().SetFloat("Speed_f", 0.3f);
        player.GetComponent<Animator>().SetBool("Static_b", true);
        StartCoroutine(PlayIntro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayIntro()
    {
        while (player.transform.position.x < endPos.x)
        {
            player.transform.Translate(Vector3.forward * 0.01f);
            yield return null;
        }

        player.GetComponent<Animator>().SetFloat("Speed_f", 0.1f);
        while (!Input.GetKeyDown(KeyCode.Space))
        {

            yield return null;
        }
        player.GetComponent<PlayerController>().isGameOver = false;
        player.GetComponent<Animator>().SetFloat("Speed_f", 0.6f);
    }
}
