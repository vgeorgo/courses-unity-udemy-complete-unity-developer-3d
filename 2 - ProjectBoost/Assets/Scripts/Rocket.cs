using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    protected Rigidbody _Rigidbody;
    protected AudioSource _AudioSource;
    protected bool _IsPlayingEngine;

    void Start ()
    {
        _Rigidbody = GetComponent<Rigidbody>();
        _AudioSource = GetComponent<AudioSource>();
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

            if (!_AudioSource.isPlaying)
            {
                _AudioSource.Play();
            }
        }
        else
        {
            if (_AudioSource.isPlaying)
            {
                _AudioSource.Stop();
            }
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward);
        }
    }
}
