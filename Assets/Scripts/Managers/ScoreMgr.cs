using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScoreMgr : MonoBehaviour
{
    public static ScoreMgr instance;
    public Text scoreText;
    public int scoreCount;

    //public int score = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
    }
}
