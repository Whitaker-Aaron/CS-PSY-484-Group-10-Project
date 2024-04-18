using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;

    List<GameObject> onPlatform;

    // Start is called before the first frame update
    void Start()
    {
        onPlatform = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

        foreach(GameObject ob in onPlatform)
        {
            ob.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MovingObject"))
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
