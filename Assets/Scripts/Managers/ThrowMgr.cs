using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowMgr : MonoBehaviour
{
    public static ThrowMgr instance;

    public Ball shootObject; // The object to shoot
    public GameObject shootObjectholder;

    public Ball leftHeldBall;
    public Ball rightHeldBall;

    public InputActionAsset inputActions;
    public InputAction lHoldAction;
    public InputAction lReleaseAction;
    public InputAction rHoldAction;
    public InputAction rReleaseAction;

    public List<Vector3> leftHandPrevPos;
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
        lHoldAction = inputActions.FindActionMap("XRI LeftHand Interaction").FindAction("Activate");
        lHoldAction.performed += _ => LeftHold();
        lHoldAction.Enable();

        lReleaseAction = inputActions.FindActionMap("XRI LeftHand Interaction").FindAction("Release");
        lReleaseAction.performed += _ => LeftRelease();
        lReleaseAction.Enable();

        leftHandPrevPos = new List<Vector3>();

        rHoldAction = inputActions.FindActionMap("XRI RightHand Interaction").FindAction("Activate");
        rHoldAction.performed += _ => RightHold();
        rHoldAction.Enable();

        rReleaseAction = inputActions.FindActionMap("XRI RightHand Interaction").FindAction("Release");
        rReleaseAction.performed += _ => RightRelease();
        rReleaseAction.Enable();

        rightHandPrevPos = new List<Vector3>();
    }

    private void FixedUpdate()
    {
        leftHandPrevPos.Add(PlayerMgr.instance.leftHand.transform.position);
        if (leftHandPrevPos.Count > posTrackerLimit)
        {
            leftHandPrevPos.RemoveAt(0);
        }

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
        if (leftHeldBall != null)
        {
            leftHeldBall.transform.position = PlayerMgr.instance.leftHand.transform.position;
        }
        if (rightHeldBall != null)
        {
            rightHeldBall.transform.position = PlayerMgr.instance.rightHand.transform.position;
        }
    }

    void LeftHold()
    {
        if (leftHeldBall == null && !PauseEndMgr.instance.PauseEnd())
        {
            Ball ball = Instantiate(shootObject, PlayerMgr.instance.leftHand.transform.position, Quaternion.identity, shootObjectholder.transform);
            ball.rb.useGravity = false;
            ball.held = true;
            leftHeldBall = ball;
        }

    }

    void LeftRelease()
    {
        if (leftHeldBall != null)
        {
            if (!PauseEndMgr.instance.PauseEnd())
            {
                Vector3 pvel = Vector3.zero;
                Vector3 rvel = Vector3.zero;
                for (int i = 0; i < posTrackerLimit - 1; i++)
                {
                    Vector3 p = platformPrevPos[i + 1] - platformPrevPos[i];
                    rvel += leftHandPrevPos[i + 1] - leftHandPrevPos[i] - p;
                    pvel += p;
                }

                leftHeldBall.held = false;
                leftHeldBall.rb.useGravity = true;
                leftHeldBall.rb.velocity = (forceMultiplier * rvel + pvel) / (Time.fixedDeltaTime * (posTrackerLimit - 1));
                leftHeldBall = null;
            }
            else
            {
                Destroy(leftHeldBall.gameObject);
                leftHeldBall = null;
            }
        }
    }

    void RightHold()
    {
        if (rightHeldBall == null && !PauseEndMgr.instance.PauseEnd())
        {
            Ball ball = Instantiate(shootObject, PlayerMgr.instance.rightHand.transform.position, Quaternion.identity, shootObjectholder.transform);
            ball.rb.useGravity = false;
            ball.held = true;
            rightHeldBall = ball;
        }
        
    }

    void RightRelease()
    {
        if (rightHeldBall != null)
        {
            if (!PauseEndMgr.instance.PauseEnd())
            {
                Vector3 pvel = Vector3.zero;
                Vector3 rvel = Vector3.zero;
                for(int i = 0; i < posTrackerLimit - 1; i++)
                {
                    Vector3 p = platformPrevPos[i + 1] - platformPrevPos[i];
                    rvel += rightHandPrevPos[i + 1] - rightHandPrevPos[i] - p;
                    pvel += p;
                }

                rightHeldBall.rb.useGravity = true;
                rightHeldBall.held = false;
                rightHeldBall.rb.velocity = (forceMultiplier * rvel + pvel) / (Time.fixedDeltaTime * (posTrackerLimit - 1));
                rightHeldBall = null;
            }
            else
            {
                Destroy(rightHeldBall.gameObject);
                rightHeldBall = null;
            }
        }
    }
}
