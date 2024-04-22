using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowMgr : MonoBehaviour
{
    public static ThrowMgr instance;

    public GameObject shootObject; // The object to shoot

    public InputAction fireAction;

    public float forceMultiplier;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        fireAction = new InputAction(binding: "<XRController>{RightHand}/triggerPressed");
        //fireAction = new InputAction(binding: "<Keyboard>/w");
        fireAction.performed += _ => Fire();
        fireAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Fire()
    {
        GameObject ball = Instantiate(shootObject, PlayerMgr.instance.rightHand.transform.position, Quaternion.identity);
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        ballBody.velocity = forceMultiplier * PlayerMgr.instance.rightHand.transform.forward;
    }
}
