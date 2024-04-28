using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMgr : MonoBehaviour
{
    public static PlatformMgr instance;

    public Platform platform;
    private float firstTurn;
    private float secondTurn;
    private float thirdTurn;
    private bool updateTransform;
    private PlatformState state;

    enum PlatformState {
        firstStage,
        secondStage,
        thirdStage,
        fourthStage
    };


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    // This script is currently empty, though it will be used to create paths for the platform

    
    void Start()
    {
        firstTurn = 75.0f;
        secondTurn = 130.0f;
        thirdTurn = 390.0f;
        state = PlatformState.firstStage;

    }

    // Update is called once per frame
    void Update()
    {
        if (platform.transform.position.x >= firstTurn &&  state == PlatformState.firstStage)
        {
            
            Debug.Log("Need to turn");

            //platform.speedX = 0.0f;
            //platform.speedZ = 2.0f;
            //platform.transform.Rotate(0.0f, -92.0f, 0.0f, Space.World);
            platform.targetOrientation = -97.0f;
            state = PlatformState.secondStage;
        }

        if (platform.transform.position.z >= secondTurn && state == PlatformState.secondStage)
        {

            Debug.Log("Need to turn");

            //platform.speedX = 0.0f;
            //platform.speedZ = 2.0f;
            //platform.transform.Rotate(0.0f, -92.0f, 0.0f, Space.World);
            platform.targetOrientation = -103.0f;
            state = PlatformState.thirdStage;
        }

        if (platform.transform.position.z >= thirdTurn && state == PlatformState.thirdStage)
        {

            Debug.Log("Need to turn");

            //platform.speedX = 0.0f;
            //platform.speedZ = 2.0f;
            //platform.transform.Rotate(0.0f, -92.0f, 0.0f, Space.World);
            platform.targetOrientation = -180.0f;
            state = PlatformState.fourthStage;
        }
    }
}
