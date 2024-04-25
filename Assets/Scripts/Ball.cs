using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Entity
{
    float timer = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Destroy(gameObject);
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
