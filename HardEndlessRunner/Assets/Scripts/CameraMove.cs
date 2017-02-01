using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float moveSpeed;

    public float xPos;
    public float yPos;

    public Transform playerTrans;

    public GameMaster gMaster;

	// Use this for initialization
	void Start ()
    {
        transform.position = new Vector3(playerTrans.position.x + xPos, playerTrans.position.y + yPos, transform.position.z);
    }

    // Update is called once per frame
    void Update ()
    {
        Vector3 viewPos = GetComponent<Camera>().WorldToViewportPoint(playerTrans.position);

        if (viewPos.x < 0)
        {
            //print("GO");

            gMaster.isGameOver = true;

        }

        transform.Translate(moveSpeed, 0, 0);

        if (gMaster.isGameOver)
        {
            moveSpeed = 0;
        }
		
	}
}
