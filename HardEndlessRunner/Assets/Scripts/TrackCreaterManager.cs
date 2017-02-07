using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrackNumList
{
    public int trackNum1;
    public int trackNum2;
    public int trackNum3;
    public int trackNum4;

}

public class TrackCreaterManager : MonoBehaviour
{

    public List<GameObject> tracksList;
    [Space(15)]
    public List<TrackNumList> tNumListEasy;
    [Space(10)]
    public List<TrackNumList> tNumListMedium;
    [Space(10)]
    public List<TrackNumList> tNumListHard;
    [Space(15)]
    public float trackDis;
    public float spawnDis;
    public float trackYPos;
    [Space(5)]
    public float destroyNum;

    bool create;
    bool isStart;

    GameObject[] tracksObjs;

    [Header("Difficulty")]
    //  public int easyNum;
    public int mediumNum;
    public int hardNum;

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

    [HideInInspector]
    public int trackPiece1;
    [HideInInspector]
    public int trackPiece2;
    [HideInInspector]
    public int trackPiece3;
    [HideInInspector]
    public int trackPiece4;

    [Header("Player")]
    public Transform playerTrans;
    Vector2 playerPos;

    GameMaster gMaster;
    TrackDifficultyManager trackDifficultyMan;

    // Use this for initialization
    void Awake()
    {
        isStart = true;
        gMaster = GetComponent<GameMaster>();
        trackDifficultyMan = GetComponent<TrackDifficultyManager>();
        playerPos = playerTrans.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // tracksObj = GameObject.FindGameObjectsWithTag("Track");

        Difficulty();
        TrackMaintance();

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

        if (isStart)
        {
            TrackCreation1(pos1, pos2, pos3, pos4, pos5, pos6);
        }
        else
        {
            TrackCreation2(pos7, pos8, pos9, pos10, pos11);
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

            //if (tr1.name == "Track Saw Middle(Clone)" && tr3.name == "Track Saw Middle(Clone)")
            //{
            //    print(tr2.name);
            //}

        }

    }

    void Difficulty()
    {
        if (gMaster.distance < mediumNum)   //Easy
        {
            trackDifficultyMan.Easy();

        }
        else if (gMaster.distance >= mediumNum && gMaster.distance < hardNum) // Medium
        {
            trackDifficultyMan.Medium();
        }
        else    // Hard
        {
            trackDifficultyMan.Hard();
        }

    }



}
