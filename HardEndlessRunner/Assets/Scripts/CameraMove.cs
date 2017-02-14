using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float moveSpeed;
    public float boostSpeed;
    [Header("Screen Siz & Pos")]
    public float xPos;
    public float yPos;
    public float orthSize;
    [Space(5)]
    public float killNum;

    public Transform playerTrans;
    PlayerMove pMove;

    public GameMaster gMaster;

	// Use this for initialization
	void Awake ()
    {
        GetComponent<Camera>().orthographicSize = orthSize;

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

        if (viewPos.x <= killNum)
        {
            //print("GO");

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
