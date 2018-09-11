﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    protected Rigidbody _rigidbody;
    protected AudioSource _audioSource;

    [SerializeField] float Thrust = 250f;
    [SerializeField] float RcsThrust = 250f;

    void Start ()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Friendly":

                break;

            case "Fuel":

                break;

            default:

                break;
        }
    }

    protected void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * Thrust);

            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
        else
        {
            if (_audioSource.isPlaying)
            {
                _audioSource.Stop();
            }
        }
    }

    protected void ProcessRotation()
    {
        _rigidbody.freezeRotation = true; // take manual control of rotation

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * RcsThrust);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * RcsThrust);
        }

        _rigidbody.freezeRotation = false; // resume physics control of rotation
    }
}
