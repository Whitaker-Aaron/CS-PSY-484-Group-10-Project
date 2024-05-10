using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMgr : MonoBehaviour
{
    public static PlayerMgr instance;

    public GameObject playerObject;
    public GameObject leftHand;
    public GameObject rightHand;

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
        
    }
}
