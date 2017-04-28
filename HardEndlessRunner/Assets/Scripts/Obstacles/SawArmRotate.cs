using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawArmRotate : MonoBehaviour {

    public float speed;

    public bool isRandom;

    public bool isClockwise;

    int ranNum;

    public MovementRotate rotateObj;

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
            if (ranNum == 0) // Anti clockwise  || Right
            {
                transform.Rotate(0, 0, speed);
                rotateObj.isRight = false;
            }
            else // Clockwise || Left
            {
                transform.Rotate(0, 0, -speed);
                rotateObj.isRight = true;
            }
        }
        else
        {
            if (isClockwise == false) // Right
            {
                transform.Rotate(0, 0, speed);
                rotateObj.isRight = false;
            }
            else // Left
            {
                transform.Rotate(0, 0, -speed);
                rotateObj.isRight = true;
            }
        }

        //print(" RanNum: " + ranNum.ToString());
	}
}
