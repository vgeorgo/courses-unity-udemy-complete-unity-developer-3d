using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    protected Rigidbody _Rigidbody;

    void Start ()
    {
        _Rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        ProcessInput();
	}

    protected void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            _Rigidbody.AddRelativeForce(Vector3.up);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {

        }
    }
}
