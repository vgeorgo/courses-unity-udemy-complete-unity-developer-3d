﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	void Start ()
    {
		
	}

	void Update ()
    {
		
	}

    void OnParticleCollision(GameObject other)
    {
		Destroy(gameObject);
    }
}
