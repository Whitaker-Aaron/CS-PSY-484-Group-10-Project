using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Platform : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public float speedZ;

    public float acceleration;

    public float targetOrientation;
    public float orientation;



    public Vector3 velocity;

    List<GameObject> onPlatform;

    // Start is called before the first frame update
    void Start()
    {
        onPlatform = new List<GameObject>();
        targetOrientation = 0;
        orientation = 0;
    }

    // Update is called once per frame
    void Update()
    {

        

        float difference = Mathf.Abs(targetOrientation - orientation);
        if (targetOrientation > orientation)
        {
            if (difference < 180) orientation += acceleration * Time.deltaTime;
            else if (difference > 180) orientation -= acceleration * Time.deltaTime;
        }
        else if (targetOrientation < orientation)
        {
            if (difference < 180) orientation -= acceleration * Time.deltaTime;
            else if (difference > 180) orientation += acceleration * Time.deltaTime;
        }

        if (difference < .5) orientation = targetOrientation;

        float angle = orientation * Mathf.Deg2Rad;

        velocity = new Vector3(Mathf.Cos(angle) * speedX, 0, -Mathf.Sin(angle) * speedX);
        Debug.Log(velocity);


        //velocity = new Vector3(speedX, speedY, speedZ) * Time.deltaTime;
        gameObject.transform.position += velocity * Time.deltaTime;

        foreach(GameObject ob in onPlatform)
        {
            ob.transform.position += velocity * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Entity>(out Entity _))
        {
            onPlatform.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (onPlatform.Contains(other.gameObject))
        {
            onPlatform.Remove(other.gameObject);
        }
    }
}
