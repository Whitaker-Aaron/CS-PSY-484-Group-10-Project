using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Ball>(out Ball _))
        {
            Debug.Log("collision detected");
            //ScoreMgr.instance.score += 1;
            ScoreMgr.instance.scoreCount += 100;
            gameObject.SetActive(false);
        }
    }
}
