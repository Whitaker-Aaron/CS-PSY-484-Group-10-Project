using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;

    public Vector3 velocity;

    List<GameObject> onPlatform;

    // Start is called before the first frame update
    void Start()
    {
        onPlatform = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(speed, 0, 0) * Time.deltaTime;
        gameObject.transform.position += velocity;

        foreach(GameObject ob in onPlatform)
        {
            ob.transform.position += velocity;
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
