using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawArmRotate : MonoBehaviour {

    public float speed;

    public bool isRandom;

    public bool isClockwise;

    int ranNum;

    // Use this for initialization
    void Awake ()
    {
        ranNum = Random.Range(0, 2);

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (isRandom)
        {
            if (ranNum == 0) // Anti clockwise
            {
                transform.Rotate(0, 0, speed); 
            }
            else // Clockwise
            {
                transform.Rotate(0, 0, -speed);
            }
        }
        else
        {
            if (isClockwise == false)
            {
                transform.Rotate(0, 0, speed);
            }
            else
            {
                transform.Rotate(0, 0, -speed);
            }
        }

        //print(" RanNum: " + ranNum.ToString());
	}
}
