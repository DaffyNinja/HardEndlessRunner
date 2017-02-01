using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingPillar : MonoBehaviour
{

    public float inOutSpeed;
    public float inOutDistance;
    public float inOutTime;

    Vector2 startPos;

    float timer;

    Transform pillarTrans;

    Vector2 activePos;

    Vector2 deactivePos;


    [Space(5)]
    public bool isActive;
    public bool isDeactive;



    // Use this for initialization
    void Start()
    {
        startPos = transform.position;

        activePos = new Vector2(startPos.x, startPos.y + 5.5f);
        deactivePos = new Vector2(startPos.x, startPos.y - 1.5f);

        isDeactive = true;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector2(transform.position.x, (Mathf.PingPong(Time.time * inOutSpeed, inOutDistance)));

        if (timer < inOutTime && isActive)  // Active
        {
            timer += Time.deltaTime;

            // transform.position = activePos;
              transform.position = Vector2.Lerp(deactivePos, activePos, inOutSpeed);

            //transform.position = new Vector2(transform.position.x, (Mathf.PingPong(Time.time, 2)));


        }
        else if (timer >= inOutTime)  // Deactive
        {
            isActive = false;
            isDeactive = true;

            // transform.position = deactivePos;

        }

        if (isDeactive)
        {
            timer -= Time.deltaTime;

            // transform.position = new Vector2(transform.position.x, (Mathf.PingPong(Time.time, 2)));

            transform.position = Vector2.Lerp(activePos, deactivePos, inOutSpeed);

            if (timer <= 0)
            {
                isActive = true;
                isDeactive = false;
            }
        }
    }

}
