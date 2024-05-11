using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{

    public GameObject ParticleEffect;
    public float vertRange;
    public float rotRange;
    private float initTopHeight;
    private float initBottomHeight;
    private float initLeftRotate;
    private float initRightRotate;
    private float vertVelocity;
    bool travelDown;
    bool rotateLeft;

    // Start is called before the first frame update
    void Start()
    {

        initBottomHeight = transform.position.y - vertRange;
        initTopHeight = transform.position.y + vertRange;
        initLeftRotate = transform.rotation.y - rotRange;
        initRightRotate = transform.rotation.y + rotRange;

        travelDown = false;
        rotateLeft = false;
        
        vertVelocity = 0.75f;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(travelDown == false)
        {
            float change = transform.position.y + vertVelocity * Time.deltaTime;
            //Vector3 upTransition = new Vector3(transform.position.x, initTopHeight, transform.position.z);
            //transform.position = Vector3.Lerp(transform.position, upTransition, Time.deltaTime);
            transform.position = new Vector3(transform.position.x, change, transform.position.z);
        }

        if(transform.position.y >= initTopHeight)
        {
            
            travelDown = true;
        }

        //Debug.Log(travelDown);

        if (travelDown == true)
        {

            float change = transform.position.y - vertVelocity * Time.deltaTime;
            //Vector3 upTransition = new Vector3(transform.position.x, initTopHeight, transform.position.z);
            //transform.position = Vector3.Lerp(transform.position, upTransition, Time.deltaTime);
            transform.position = new Vector3(transform.position.x, change, transform.position.z);
        }

        if(transform.position.y <= initBottomHeight)
        {
            travelDown = false;
        }


        transform.Rotate(new Vector3(0.0f, rotRange, 0.0f) * Time.deltaTime);








        //if (rotateLeft == false)
        //{
        //    float change = transform.rotation.y + 2 * Time.deltaTime;

        //    //transform.Rotate(new Vector3(0.0f, 3.0f, 0.0f) * Time.deltaTime);
        //    //transform.rotation = Quaternion.Euler(transform.rotation.x, change, transform.rotation.z);
        //}

        //if (transform.rotation.y >= initRightRotate)
        //{

        //    rotateLeft = true;
        //}

        ////Debug.Log(travelDown);

        //if (rotateLeft == true)
        //{
        //    //Debug.Log("inside the thang");

        //    float change = transform.rotation.y - 2 * Time.deltaTime;

        //    //transform.Rotate(new Vector3(0.0f, 3.0f, 0.0f) * Time.deltaTime);
        //    //transform.rotation = Quaternion.Euler(transform.rotation.x, change, transform.rotation.z);

        //}

        //if (transform.rotation.y <= initLeftRotate)
        //{
        //    rotateLeft = false;
        //}



    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Ball>(out Ball _))
        {
            Debug.Log("collision detected");
            vertVelocity = 0.0f;
            rotRange = 0.0f;

            //ScoreMgr.instance.score += 1;
            ScoreMgr.instance.scoreCount += 100;
            MainManager.instance.playerScore += 100;
            ParticleEffect.GetComponent<ParticleSystem>().transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z);
            ParticleEffect.GetComponent<ParticleSystem>().Play();
            gameObject.SetActive(false);
            

            
        }
    }
}
