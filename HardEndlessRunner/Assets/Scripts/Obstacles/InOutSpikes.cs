﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOutSpikes : MonoBehaviour
{
    public float inOutTime;
    public float timer;

    public bool isGround;

    Transform spikeTran;

    Vector2 startPos;
    Vector2 activePos;
    Vector2 deactivePos;

    [Space(5)]
    public bool isActive;
    public bool isDeactive;

    public bool isNew;

    // Use this for initialization
    void Awake()
    {
        spikeTran = transform.GetChild(0);

        startPos = spikeTran.position;

        if (isGround)
        {
            deactivePos = new Vector2(spikeTran.position.x, spikeTran.position.y - 1);
        }
        else
        {
            activePos = new Vector2(spikeTran.position.x, spikeTran.position.y + 1);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isNew == false)
        {
            if (timer < inOutTime && isActive)  // Active
            {
                timer += Time.deltaTime;

                spikeTran.transform.position = startPos;
            }
            else if (timer >= inOutTime)  // Deactive
            {
                spikeTran.position = deactivePos;

                isActive = false;
                isDeactive = true;

            }

            if (isDeactive)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    isActive = true;
                    isDeactive = false;
                }
            }
        }
        else
        {
            if (isActive)  // Active
            {
                spikeTran.transform.position = startPos;
            }
            else
            {
                spikeTran.position = deactivePos;

            }

        }



    }
}
