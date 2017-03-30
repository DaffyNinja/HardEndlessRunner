using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankShaft : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
		
	}
}
