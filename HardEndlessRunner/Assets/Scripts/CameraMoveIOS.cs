using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveIOS : MonoBehaviour {

    public float moveSpeed;
    public float boostSpeed;

    [Header("Screen Size & Pos")]
    public float xPos;
    public float yPos;
    public float orthSize;
    [Space(5)]
    public float killNum;

    public Transform playerTrans;
    PlayerMoveIOS pMove;

    public GameMaster gMaster;

    // Use this for initialization
    void Awake()
    {
        GetComponent<Camera>().orthographicSize = orthSize;

        transform.position = new Vector3(playerTrans.position.x + xPos, playerTrans.position.y + yPos, transform.position.z);

        pMove = playerTrans.GetComponent<PlayerMoveIOS>();
    }

    // Update is called once per frame
    void Update()
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
