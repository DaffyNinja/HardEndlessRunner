using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTester : MonoBehaviour
{


    public List<GameObject> tracksList;
    [Space(5)]
    public int trackPiece1;
    int startTPiece1;
    public int trackPiece2;
    public int trackPiece3;
    public int trackPiece4;
    [Space(10)]
    public float trackDis;
    public float spawnDis;
    public float trackYPos;
    [Space(5)]
    public float destroyNum;

    bool create;
    bool isStart;

    GameObject[] tracksObjs;

    public bool isSplit;
    public int splitTrNum;
    public float splitTrackYPos;

    [Space(5)]
    public bool isSpecial;
    public float specialAppearNum;
    float startSpecialNum;
    public GameObject[] specialObjs;

    [Space(5)]
    public Transform playerTrans;
    Vector2 playerPos;

    GameObject tr1;
    GameObject tr2;
    GameObject tr3;
    GameObject tr4;
    GameObject tr5;
    GameObject tr6;

    Vector2 tP1;
    Vector2 tP2;
    Vector2 tP3;
    Vector2 tP4;
    Vector2 tP5;
    Vector2 tP6;

    // Use this for initialization
    void Awake()
    {
        isStart = true;
        playerPos = playerTrans.position;

        startSpecialNum = specialAppearNum;

        startTPiece1 = trackPiece1;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // tracksObj = GameObject.FindGameObjectsWithTag("Track");

        TrackMaintance();

        if (isSplit)
        {
            trackPiece1 = splitTrNum;
          //  isSplit = false;
        }
        else
        {
            trackPiece1 = startTPiece1;
        }

    }

    void TrackMaintance()
    {
        tracksObjs = GameObject.FindGameObjectsWithTag("Track");
        SpawnTracks();

        foreach (GameObject t in tracksObjs)
        {
            if (t.transform.position.x < playerTrans.position.x - destroyNum)
            {
                Destroy(t);
            }

        }

        GameObject[] dartObjs = GameObject.FindGameObjectsWithTag("Dart");

        foreach (GameObject d in dartObjs)
        {
            if (d.transform.position.x < playerTrans.position.x - destroyNum)
            {
                Destroy(d);
            }
        }
    }

    void SpawnTracks()
    {
        Vector2 pos1 = new Vector2(playerTrans.position.x + 0, playerPos.y - trackYPos);
        Vector2 pos2 = new Vector2(playerTrans.position.x + trackDis, playerPos.y - trackYPos);
        Vector2 pos3 = new Vector2(playerTrans.position.x + trackDis * 2, playerPos.y - trackYPos);
        Vector2 pos4 = new Vector2(playerTrans.position.x + trackDis * 3, playerPos.y - trackYPos);
        Vector2 pos5 = new Vector2(playerTrans.position.x + trackDis * 4, playerPos.y - trackYPos);
        Vector2 pos6 = new Vector2(playerTrans.position.x + trackDis * 5, playerPos.y - trackYPos);

        Vector2 pos7 = new Vector2(playerTrans.position.x + trackDis * 6, playerPos.y - trackYPos);
        Vector2 pos8 = new Vector2(playerTrans.position.x + trackDis * 7, playerPos.y - trackYPos);
        Vector2 pos9 = new Vector2(playerTrans.position.x + trackDis * 8, playerPos.y - trackYPos);
        Vector2 pos10 = new Vector2(playerTrans.position.x + trackDis * 9, playerPos.y - trackYPos);
        Vector2 pos11 = new Vector2(playerTrans.position.x + trackDis * 10, playerPos.y - trackYPos);

        Vector2 splitUp1 = new Vector2(playerTrans.position.x + trackDis * 6, playerPos.y + splitTrackYPos);
        Vector2 splitUp2 = new Vector2(playerTrans.position.x + trackDis * 7, playerPos.y + splitTrackYPos);
        Vector2 splitUp3 = new Vector2(playerTrans.position.x + trackDis * 8, playerPos.y + splitTrackYPos);
        Vector2 splitUp4 = new Vector2(playerTrans.position.x + trackDis * 9, playerPos.y + splitTrackYPos);
        Vector2 splitUp5 = new Vector2(playerTrans.position.x + trackDis * 10, playerPos.y + splitTrackYPos);

        Vector2 splitDwn1 = new Vector2(playerTrans.position.x + trackDis * 6, playerPos.y - splitTrackYPos);
        Vector2 splitDwn2 = new Vector2(playerTrans.position.x + trackDis * 7, playerPos.y - splitTrackYPos);
        Vector2 splitDwn3 = new Vector2(playerTrans.position.x + trackDis * 8, playerPos.y - splitTrackYPos);
        Vector2 splitDwn4 = new Vector2(playerTrans.position.x + trackDis * 9, playerPos.y - splitTrackYPos);
        Vector2 splitDwn5 = new Vector2(playerTrans.position.x + trackDis * 10, playerPos.y - splitTrackYPos);

        if (isStart)
        {
            TrackCreation1(pos1, pos2, pos3, pos4, pos5, pos6);
        }
        else if (isStart == false && isSplit == false)
        {
            TrackCreation2(pos7, pos8, pos9, pos10, pos11);
        }
        else if (isStart == false && isSplit == true)
        {
            TrackCreation3(splitUp1, splitUp3, splitUp3, splitUp4, splitUp5);
            TrackCreation3(splitDwn1, splitDwn2, splitDwn3, splitDwn4, splitDwn5);
        }


        if (playerTrans.position.x >= playerPos.x + specialAppearNum && isSpecial == true)
        {
            GameObject[] specialSpawn = GameObject.FindGameObjectsWithTag("Special Spawn");

            Instantiate(specialObjs[Random.Range(0, specialObjs.Length)], specialSpawn[1].transform.position, Quaternion.identity);

            specialAppearNum = specialAppearNum + startSpecialNum;

        }

    }

    void TrackCreation1(Vector2 trackPos1, Vector2 trackPos2, Vector2 trackPos3, Vector2 trackPos4, Vector2 trackPos5, Vector2 trackPos6)
    {
        create = true;

        foreach (GameObject t in tracksObjs)
        {
            if (trackPos1.x < t.transform.position.x) // 11.5
            {
                create = false;
                isStart = false;
            }
        }

        if (create && isStart == true)
        {
            tr1 = Instantiate(tracksList[0], trackPos1, Quaternion.identity);
            tr2 = Instantiate(tracksList[0], trackPos2, Quaternion.identity);
            tr3 = Instantiate(tracksList[0], trackPos3, Quaternion.identity);
            tr4 = Instantiate(tracksList[0], trackPos4, Quaternion.identity);
            tr5 = Instantiate(tracksList[0], trackPos5, Quaternion.identity);
            tr6 = Instantiate(tracksList[0], trackPos6, Quaternion.identity);

            create = false;
        }
    }

    void TrackCreation2(Vector2 trackPos1, Vector2 trackPos2, Vector2 trackPos3, Vector2 trackPos4, Vector2 trackPos5)
    {

        create = true;

        foreach (GameObject t in tracksObjs)
        {
            if (trackPos1.x < t.transform.position.x + spawnDis)
            {
                create = false;
                isStart = false;
            }
        }

        if (create)
        {
            tr1 = Instantiate(tracksList[trackPiece1], trackPos1, Quaternion.identity);

            tr2 = Instantiate(tracksList[trackPiece2], trackPos2, Quaternion.identity);

            tr3 = Instantiate(tracksList[trackPiece3], trackPos3, Quaternion.identity);

            tr4 = Instantiate(tracksList[trackPiece4], trackPos4, Quaternion.identity);

            create = false;

        }

    }

    void TrackCreation3(Vector2 trackPos1, Vector2 trackPos2, Vector2 trackPos3, Vector2 trackPos4, Vector2 trackPos5)
    {

        create = true;

        foreach (GameObject t in tracksObjs)
        {
            if (trackPos1.x < t.transform.position.x + spawnDis)
            {
                create = false;
                isStart = false;
            }
        }

        if (create)
        {
            tr1 = Instantiate(tracksList[0], trackPos1, Quaternion.identity);

            tr2 = Instantiate(tracksList[0], trackPos2, Quaternion.identity);

            tr3 = Instantiate(tracksList[0], trackPos3, Quaternion.identity);

            tr4 = Instantiate(tracksList[0], trackPos4, Quaternion.identity);

            create = false;

        }

    }

}
