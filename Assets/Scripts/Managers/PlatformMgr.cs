using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMgr : MonoBehaviour
{
    public static PlatformMgr instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // This script is currently empty, though it will be used to create paths for the platform
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
