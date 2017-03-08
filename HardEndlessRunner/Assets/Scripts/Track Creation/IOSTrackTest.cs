using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOSTrackTest : MonoBehaviour {

    public GameObject[] tracksList;

    bool create;

    GameObject[] tracksObjs;

    public float spawnDis;
    public float trackDis;
    public float trackYPos;


    GameObject tr1;
    GameObject tr2;
    GameObject tr3;
    GameObject tr4;

    public int trackPiece1;
    public int trackPiece2;
    public int trackPiece3;
    public int trackPiece4;


    public Transform playerTrans;
    private Vector2 playerPos;

    // Use this for initialization
    void Start ()
    {
        playerPos = playerTrans.position;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        tracksObjs = GameObject.FindGameObjectsWithTag("Track");
        SpawnTracks();
		
	}

    void SpawnTracks()
    {
        Vector2 pos7 = new Vector2(playerTrans.position.x + trackDis * 6, playerPos.y - trackYPos);
        Vector2 pos8 = new Vector2(playerTrans.position.x + trackDis * 7, playerPos.y - trackYPos);
        Vector2 pos9 = new Vector2(playerTrans.position.x + trackDis * 8, playerPos.y - trackYPos);
        Vector2 pos10 = new Vector2(playerTrans.position.x + trackDis * 9, playerPos.y - trackYPos);

        TrackCreation1(pos7, pos8, pos9, pos10);
    }



    void TrackCreation1(Vector2 trackPos1, Vector2 trackPos2, Vector2 trackPos3, Vector2 trackPos4)//, Vector2 trackPos5)//, Vector2 trackPos6)
    {
        create = true;

        foreach (GameObject t in tracksObjs)
        {
            if (trackPos1.x < t.transform.position.x + spawnDis) // 11.5
            {
                create = false;
               
            }
        }

        if (create)
        {
            tr1 = Instantiate(tracksList[trackPiece1], trackPos1, Quaternion.identity);
            tr2 = Instantiate(tracksList[trackPiece2], trackPos2, Quaternion.identity);
            tr3 = Instantiate(tracksList[trackPiece3], trackPos3, Quaternion.identity);
            tr4 = Instantiate(tracksList[trackPiece4], trackPos4, Quaternion.identity);

            //  TrackPieceAdjust();

            create = false;
        }
    }
}
