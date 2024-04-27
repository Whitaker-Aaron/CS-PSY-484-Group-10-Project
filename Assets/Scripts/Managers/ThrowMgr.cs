using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowMgr : MonoBehaviour
{
    public static ThrowMgr instance;

    public Ball shootObject; // The object to shoot
    public GameObject shootObjectholder;

    public Ball heldBall;

    public InputActionAsset inputActions;
    public InputAction holdAction;
    public InputAction releaseAction;


    public List<Vector3> rightHandPrevPos;
    public List<Vector3> platformPrevPos; // Prevents extra force from being added due to the platform

    public float forceMultiplier;
    public float posTrackerLimit;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        holdAction = inputActions.FindActionMap("XRI RightHand Interaction").FindAction("Activate");
        holdAction.performed += _ => Hold();
        holdAction.Enable();

        releaseAction = inputActions.FindActionMap("XRI RightHand Interaction").FindAction("Release");
        releaseAction.performed += _ => Release();
        releaseAction.Enable();

        rightHandPrevPos = new List<Vector3>();
    }

    private void FixedUpdate()
    {
        rightHandPrevPos.Add(PlayerMgr.instance.rightHand.transform.position);
        if(rightHandPrevPos.Count > posTrackerLimit )
        {
            rightHandPrevPos.RemoveAt(0);
        }

        platformPrevPos.Add(PlatformMgr.instance.platform.transform.position);
        if (platformPrevPos.Count > posTrackerLimit)
        {
            platformPrevPos.RemoveAt(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(heldBall != null)
        {
            heldBall.transform.position = PlayerMgr.instance.rightHand.transform.position;
        }
    }

    void Hold()
    {
        if (heldBall == null)
        {
            Ball ball = Instantiate(shootObject, PlayerMgr.instance.rightHand.transform.position, Quaternion.identity, shootObjectholder.transform);
            ball.rb.useGravity = false;
            heldBall = ball;
        }
        
    }

    void Release()
    {
        if (heldBall != null)
        {
            Vector3 pvel = Vector3.zero;
            Vector3 rvel = Vector3.zero;
            for(int i = 0; i < posTrackerLimit - 1; i++)
            {
                Vector3 p = platformPrevPos[i + 1] - platformPrevPos[i];
                rvel += rightHandPrevPos[i + 1] - rightHandPrevPos[i] - p;
                pvel += p;
            }

            heldBall.rb.useGravity = true;
            heldBall.rb.velocity = (forceMultiplier * rvel + pvel) / (Time.fixedDeltaTime * (posTrackerLimit - 1));
            heldBall = null;
        }
    }
}
