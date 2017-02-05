using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRotate : MonoBehaviour {

    public float rotateSpeed;

    public bool isRotate;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (isRotate)
        {
            transform.Rotate(0, 0, rotateSpeed);
        }

		
	}
}
