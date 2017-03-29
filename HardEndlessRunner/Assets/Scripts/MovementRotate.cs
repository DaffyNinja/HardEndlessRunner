using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRotate : MonoBehaviour {

    public float rotateSpeed;

    public bool isRight;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (isRight)
        {
            transform.Rotate(0, 0, -rotateSpeed);
        }
        else
        {
            transform.Rotate(0, 0, rotateSpeed);
        }

		
	}
}
