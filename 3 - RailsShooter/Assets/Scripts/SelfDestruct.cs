using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
	[SerializeField] float delay = 0f;

	void Start()
	{
		Destroy (gameObject, delay);
	}
}
