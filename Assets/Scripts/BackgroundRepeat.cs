using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private Vector3 startPos;
    private float reapetWith;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        reapetWith = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - reapetWith)
            transform.position = startPos;
    }
}
