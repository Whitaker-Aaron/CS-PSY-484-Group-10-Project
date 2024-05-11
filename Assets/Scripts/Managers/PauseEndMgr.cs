using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseEndMgr : MonoBehaviour
{
    public static PauseEndMgr instance;

    public InputActionAsset inputActions;
    public InputAction pauseAction;

    public bool pause = false;
    public bool end = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pauseAction = inputActions.FindActionMap("XRI RightHand Interaction").FindAction("Pause");
        pauseAction.performed += _ => Pause();
        pauseAction.Enable();
    }

    public void Pause()
    {
        if(pause)
        {
            Time.timeScale = 1.0f;
        }
        else
        {
            Time.timeScale = 0.0f;
        }
        pause = !pause;
    }

    public void End()
    {
        end = true;
    }

    public bool PauseEnd()
    {
        return pause || end;
    }
}
