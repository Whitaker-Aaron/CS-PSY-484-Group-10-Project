using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

//lHoldAction = inputActions.FindActionMap("XRI LeftHand Interaction").FindAction("Activate");

public class MenuInput : BaseInput
{
    public Camera eventCamera = null;
    public InputActionAsset inputActions;
    public InputAction rHoldAction;
    public InputAction rReleaseAction; 
    //public GameObject rightHand;


    protected override void Awake()
    {
        GetComponent<BaseInputModule>().inputOverride = this;
        rHoldAction = inputActions.FindActionMap("XRI RightHand Interaction").FindAction("Activate");
        rReleaseAction = inputActions.FindActionMap("XRI RightHand Interaction").FindAction("Release");
        rHoldAction.Enable();
        rReleaseAction.Enable();
    }

    public override bool GetMouseButton(int button)
    {
        

        Debug.Log(rHoldAction.WasPerformedThisFrame());
        return rHoldAction.WasPerformedThisFrame();
        //rHoldAction.
    }

    public override bool GetMouseButtonDown(int button)
    {
        return rHoldAction.WasPerformedThisFrame();
    }

    public override bool GetMouseButtonUp(int button)
    {
        //return rReleaseAction.triggered;
        return rReleaseAction.WasPerformedThisFrame();
    }

    public override Vector2 mousePosition
    {
        get { return new Vector2(eventCamera.pixelWidth / 2, eventCamera.pixelHeight / 2); }
    }






}

