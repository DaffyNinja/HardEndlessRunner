using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : MonoBehaviour
{

    public float leftRightSpeed;
    public float xPos;
    public bool isRight;
    public bool isLeft;
    [Space(5)]
    public float upDownSpeed;
    public float yPos;
    public bool isUp;
    public bool isDown;
  
    float minimum = 0f;
    float maximum = 1.0f;

    float t = 0.0f;


    Vector2 startPos;
    Vector2 leftRightPos;
    Vector2 upDownPos;

    // Use this for initialization
    void Start()
    {
        startPos = transform.localPosition;

        if (isRight)
        {
            leftRightPos = new Vector2(startPos.x + xPos, startPos.y);
        }
        else if (isLeft)
        {
            leftRightPos = new Vector2(startPos.x - xPos, startPos.y);
        }

        if (isUp)
        {
           // print("Up");
          
            upDownPos = new Vector2(startPos.x, startPos.y + yPos);
        }
        else if (isDown)
        {
            upDownPos = new Vector2(startPos.x, startPos.y - yPos);
        }

    }

    // Update is called once per frame
    void Update()
    {

        float num = Mathf.Lerp(minimum, maximum, t);

        if (isLeft || isRight)
        {
            t += leftRightSpeed * Time.deltaTime;
        }
        else
        {
            t += upDownSpeed * Time.deltaTime;
        }

        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }

        if (isRight || isLeft)
        {
            print("L R");

            transform.localPosition = Vector2.Lerp(startPos, leftRightPos, num);
        }
        else if (isDown || isUp)
        {
            transform.localPosition = Vector2.Lerp(startPos, upDownPos, num);
        }

    }
}
