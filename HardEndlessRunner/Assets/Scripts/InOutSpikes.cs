using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOutSpikes : MonoBehaviour
{

    public float inOutSpeed;
    public float inOutTime;
    float timer;

    Transform[] spikeTrans;

    Vector2 startPos1;
    Vector2 startPos2;
    Vector2 startPos3;

    Vector2 activePos;

    Vector2 deactivePos1;
    Vector2 deactivePos2;
    Vector2 deactivePos3;

    [Space(5)]
    public bool isActive;
    public bool isDeactive;

    // Use this for initialization
    void Start()
    {
        spikeTrans = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            spikeTrans[i] = transform.GetChild(i).transform;
        }

        startPos1 = spikeTrans[0].transform.position;
        startPos2 = spikeTrans[1].transform.position;
        startPos3 = spikeTrans[2].transform.position;

        deactivePos1 = new Vector2(spikeTrans[0].transform.position.x, spikeTrans[0].transform.position.y - 1);
        deactivePos2 = new Vector2(spikeTrans[1].transform.position.x, spikeTrans[1].transform.position.y - 1);
        deactivePos3 = new Vector2(spikeTrans[2].transform.position.x, spikeTrans[2].transform.position.y - 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < inOutTime && isActive)  // Active
        {
            timer += Time.deltaTime;

            spikeTrans[0].transform.position = startPos1;
            spikeTrans[1].transform.position = startPos2;
            spikeTrans[2].transform.position = startPos3;
        }
        else if (timer >= inOutTime)  // Deactive
        {
            spikeTrans[0].transform.position = deactivePos1;
            spikeTrans[1].transform.position = deactivePos2;
            spikeTrans[2].transform.position = deactivePos3;

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
}
