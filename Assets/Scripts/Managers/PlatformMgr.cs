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
    private float fourthTurn;
    private float fifthTurn;
    private float lastTurn;
    private bool updateTransform;
    private PlatformState state;

    enum PlatformState {
        firstStage,
        secondStage,
        thirdStage,
        fourthStage,
        fifthStage,
        sixthStage,
        lastStage
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
        thirdTurn = 435.0f;
        fourthTurn = -100.0f;
        fifthTurn = 290.0f;
        lastTurn = 75.0f;
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
            platform.targetOrientation = -97.0f;
            state = PlatformState.thirdStage;
        }

        if (platform.transform.position.z >= thirdTurn && state == PlatformState.thirdStage)
        {

            Debug.Log("Need to turn");

            //platform.speedX = 0.0f;
            //platform.speedZ = 2.0f;
            //platform.transform.Rotate(0.0f, -92.0f, 0.0f, Space.World);
            platform.targetOrientation = -190.0f;
            state = PlatformState.fourthStage;
        }

        if (platform.transform.position.x <= fourthTurn && state == PlatformState.fourthStage)
        {

            Debug.Log("Need to turn");

            //platform.speedX = 0.0f;
            //platform.speedZ = 2.0f;
            //platform.transform.Rotate(0.0f, -92.0f, 0.0f, Space.World);
            platform.targetOrientation = -280.0f;
            state = PlatformState.fifthStage;
        }

        if (platform.transform.position.z <= fifthTurn && state == PlatformState.fifthStage)
        {

            Debug.Log("Need to turn");

            //platform.speedX = 0.0f;
            //platform.speedZ = 2.0f;
            //platform.transform.Rotate(0.0f, -92.0f, 0.0f, Space.World);
            platform.targetOrientation = -370.0f;
            state = PlatformState.sixthStage;
        }

        if (platform.transform.position.x >= lastTurn && state == PlatformState.sixthStage)
        {

            Debug.Log("Need to turn");

            //platform.speedX = 0.0f;
            //platform.speedZ = 2.0f;
            //platform.transform.Rotate(0.0f, -92.0f, 0.0f, Space.World);
            platform.targetOrientation = -370.0f;
            state = PlatformState.lastStage;
        }

        if(state == PlatformState.lastStage)
        {
            platform.acceleration = 0;
            platform.velocity = new Vector3 (0, 0, 0);
            platform.speedX = 0;
            PauseEndMgr.instance.End();
        }
    }
}
