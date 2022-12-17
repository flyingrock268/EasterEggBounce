using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class scoreKeeper : MonoBehaviour
{
    
    Text score;

    private void Start()
    {
        
        score = GetComponent<Text>();

    }

    private void Update()
    {

        score.text = "Score: " + PlayerPrefs.GetInt("score");

    }

}
