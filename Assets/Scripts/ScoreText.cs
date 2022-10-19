using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public MoveLeft playerScript;
    private string textValue;
    private Text textElement;

    // Start is called before the first frame update
    void Start()
    {
        textElement = GetComponent<Text>();
        playerScript = GameObject.Find("Background").GetComponent<MoveLeft>();
    }

    // Update is called once per frame
    void Update()
    {
        textValue = "Score: " + playerScript.score;
        textElement.text = textValue;
    }
}
