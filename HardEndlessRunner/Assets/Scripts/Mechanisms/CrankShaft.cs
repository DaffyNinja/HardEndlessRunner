﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankShaft : MonoBehaviour {

    public InOutSpikes spikeCS;

    SpriteRenderer sprRend;

	// Use this for initialization
	void Awake ()
    {
        sprRend = GetComponent<SpriteRenderer>();

        //if (spikeCS.isActive)
        //{
        //    transform.localRotation = Quaternion.Euler(0, 180, 0);
        //}
        //else
        //{
        //    transform.localRotation = Quaternion.Euler(0, 0, 0);
        //}

        if (spikeCS.isActive)
        {
            sprRend.flipY = true;
        }
        else
        {
            sprRend.flipY = false;
        }

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    transform.localRotation = Quaternion.Euler(0, 180, 0);
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    transform.localRotation = Quaternion.Euler(0, 0, 0);
        //}

        //if (spikeCS.isActive)
        //{
        //    transform.localRotation = Quaternion.Euler(0, 180, 0);
        //}
        //else
        //{
        //    transform.localRotation = Quaternion.Euler(0, 0, 0);
        //}

        if (spikeCS.isActive)
        {
            sprRend.flipY = true;
        }
        else
        {
            sprRend.flipY = false;
        }

    }
}
