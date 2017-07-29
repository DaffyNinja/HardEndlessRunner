using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePoll : MonoBehaviour
{

    public float maxHeight;
    public float minHeight;

    public float speed;

    public bool moveUp;
    public bool moveDown;

    Vector2 startPos;

    public InOutSpikes spikeCS;

    // Use this for initialization
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveUp)
        {
            transform.localPosition = Vector2.Lerp(new Vector2(transform.localPosition.x, transform.localPosition.y), new Vector2(transform.localPosition.x, maxHeight), speed * Time.deltaTime);
        }
        else if (moveDown)
        {
            transform.localPosition = Vector2.Lerp(new Vector2(transform.localPosition.x, transform.localPosition.y), new Vector2(transform.localPosition.x, minHeight), speed * Time.deltaTime);
        }


        //if (transform.position.y >= startPos.y + maxHeight - 0.25f)
        //{
        //    //moveUp = false;
        //    //moveDown = true;

        //    print("MAX HEIGHT");
        //}
        //else if (transform.position.y <= startPos.y - minHeight + 0.25f && moveDown)
        //{
        //    //moveUp = true;
        //    //moveDown = false;

        //    print("MIN HEIGHT");
        //}

        if (spikeCS.timer >= spikeCS.inOutTime/2 && spikeCS.isActive) // Down
        {
            moveUp = false;
            moveDown = true;
        }
        else if (spikeCS.timer <= spikeCS.inOutTime / 2)
        {
            moveUp = true;
            moveDown = false;
        }


    }
}
