using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float moveSpeed;
    public float boostSpeed;

    public float xPos;
    public float yPos;

    public Transform playerTrans;
    PlayerMove pMove;

    public GameMaster gMaster;

	// Use this for initialization
	void Awake ()
    {
        transform.position = new Vector3(playerTrans.position.x + xPos, playerTrans.position.y + yPos, transform.position.z);

        pMove = playerTrans.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (pMove.obtainedBoost == false)
        {
            transform.Translate(moveSpeed, 0, 0);
        }
        else
        {
            transform.Translate(boostSpeed, 0, 0);
        }

        Vector3 viewPos = GetComponent<Camera>().WorldToViewportPoint(playerTrans.position);

        if (viewPos.x < 0)
        {
            //print("GO");

            gMaster.isGameOver = true;

        }
        if (gMaster.isGameOver)
        {
            moveSpeed = 0;
        }
		
	}
}
