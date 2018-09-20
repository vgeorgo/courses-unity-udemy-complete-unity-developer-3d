using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
	void Start ()
    {
		
	}
	
	void Update ()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
	}
}
