using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(35, 0, 0);
    private PlayerController playerControllerScript;
    private int obstacleChoose;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpownObstacles", 0.75f, 3);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpownObstacles()
    {
        obstacleChoose = Random.Range(0, 3);
        if (playerControllerScript.isGameOver == false)
            Instantiate(obstaclePrefabs[obstacleChoose], spawnPos, obstaclePrefabs[obstacleChoose].transform.rotation);
    }
}
