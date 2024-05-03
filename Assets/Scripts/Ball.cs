using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Entity
{
    float timer = 10f;
    public bool held = true;

    int lineLen = 10;
    public LineRenderer trail;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!held)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Destroy(gameObject);
            }
        }

    }

    private void FixedUpdate()
    {
        if (!held)
        {
            Vector3 nextPos = transform.position + rb.velocity * Time.fixedDeltaTime;
            if(trail.positionCount < lineLen)
            {
                trail.positionCount += 1;
                trail.SetPosition(trail.positionCount - 1, nextPos); 
            }
            else
            {
                Vector3[] newLine = new Vector3[lineLen];
                for(int i = 1; i < lineLen; i++)
                {
                    newLine[i - 1] = trail.GetPosition(i);
                }
                newLine[lineLen-1] = nextPos;
                trail.SetPositions(newLine);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy _))
        {
            Destroy(gameObject);
        }
    }
}
