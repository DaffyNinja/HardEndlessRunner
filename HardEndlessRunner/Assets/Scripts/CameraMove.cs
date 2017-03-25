using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float moveSpeed;
    public float boostSpeed;

    [Header("Screen Size & Pos")]
    public float xPos;
    public float yPos;
    float screenWidth;
    float screenHeight;
    public float orthSize;
    [Space(5)]
    public float killNum;

    public Transform playerTrans;
    PlayerMove pMove;

    public GameMaster gMaster;

	// Use this for initialization
	void Awake ()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        print("Screen Height: " + screenHeight);
        print("Screen Width: " + screenWidth);

        GetComponent<Camera>().orthographicSize = orthSize;

        transform.position = new Vector3(playerTrans.position.x + xPos, playerTrans.position.y + yPos, transform.position.z);

        pMove = playerTrans.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        // Camera movement
        if (pMove.obtainedBoost == false)
        {
            transform.Translate(moveSpeed, 0, 0);
        }
        else
        {
            transform.Translate(boostSpeed, 0, 0);
        }

        Vector3 viewPos = GetComponent<Camera>().WorldToViewportPoint(playerTrans.position);

        // If the player moves out of camera's left view, the game is over
        if (viewPos.x <= killNum)
        {              
            gMaster.isGameOver = true;
        }

        if (gMaster.isGameOver)
        {
            gameObject.isStatic = true;
            moveSpeed = 0;
        }
        else
        {
            gameObject.isStatic = false;
        }
		
	}
}
