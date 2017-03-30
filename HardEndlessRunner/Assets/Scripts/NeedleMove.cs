using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMove : MonoBehaviour {

    public float speed;

    float angles;


	// Use this for initialization
	void Start ()
    {
             

	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (transform.eulerAngles.z <= 150)
        //{
        //    angles = Mathf.LerpAngle(0, -150, speed * Time.time);
        //}
        //else if(transform.eulerAngles.z == 150)
        //{
        //    angles = Mathf.LerpAngle(-150, 0, speed * Time.time);
        //}

        angles = Mathf.LerpAngle(0, -150, speed * Time.time);

        transform.eulerAngles = new Vector3(0, 0, angles);



    }
}
