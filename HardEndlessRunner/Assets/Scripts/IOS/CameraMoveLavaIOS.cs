using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveLavaIOS : MonoBehaviour
{

    public float moveSpeed;
    public float boostSpeed;

    [Header("Screen Size & Pos")]
    public float xPos;
    public float yPos;
    public float orthSize;
    [Space(5)]
    public float killNum;

    public Transform playerTrans;
    PlayerMoveLavaIOS pMove;

    public IOSGameMaster gMaster;

    // Use this for initialization
    void Awake()
    {
        GetComponent<Camera>().orthographicSize = orthSize;

        transform.position = new Vector3(playerTrans.position.x + xPos, playerTrans.position.y + yPos, transform.position.z);

        pMove = playerTrans.GetComponent<PlayerMoveLavaIOS>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Camera movement
        transform.Translate(moveSpeed, 0, 0);



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