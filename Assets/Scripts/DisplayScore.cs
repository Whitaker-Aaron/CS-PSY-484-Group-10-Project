using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = MainManager.instance.playerScore;
    }

    // Update is called once per frame
    void Update()
    {
        //score = MainManager.instance.playerScore;
        scoreText.SetText("Final score : " + score);
    }
}
