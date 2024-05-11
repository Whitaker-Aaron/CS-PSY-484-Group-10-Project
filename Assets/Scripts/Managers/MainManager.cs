using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public GameObject MainMgr;

    public int playerScore;

    private void Awake()
    {
        // start of new code
       
        // end of new code

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        Debug.Log(playerScore);
    }
}
