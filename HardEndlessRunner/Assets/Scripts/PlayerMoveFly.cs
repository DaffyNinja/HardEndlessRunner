using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveFly : MonoBehaviour {

    public float leftSpeed;
    public float rightSpeed;
    public float verSpeed;

    public float hozSpeed;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(hozSpeed, 0, 0);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(rightSpeed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-leftSpeed, 0, 0);
        }


        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, verSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -verSpeed, 0);
        }


    }
}
