using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class blockBehavior : MonoBehaviour
{
    public GameObject blockObject;
    private Rigidbody blockBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blockBody = GetComponent<Rigidbody>();
        blockBody.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
