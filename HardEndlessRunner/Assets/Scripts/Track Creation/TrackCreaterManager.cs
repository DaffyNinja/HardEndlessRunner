﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrackNumList   // Is used to number the track pieces coresponding to their list in the array
{
    public int trackNum1;
    public int trackNum2;
    public int trackNum3;
    public int trackNum4;
}

public class TrackCreaterManager : MonoBehaviour
{

    public List<GameObject> tracksList; // The track list
    [Space(15)]
    public List<TrackNumList> tNumListEasy; // Stores the track set numbers for Easy tracks
    [Space(10)]
    public List<TrackNumList> tNumListMedium;   // Stores the track set numbers for Medium tracks
    [Space(10)]
    public List<TrackNumList> tNumListHard; // Stores the track set numbers for Hard tracks
    [Space(15)]
    public float trackDis;
    public float spawnDis;
    public float trackYPos;
    [Space(5)]
    public float destroyNum;

    bool create;
    bool isStart;

    GameObject[] tracksObjs; // The track gameobjects created in scene

    [Header("Difficulty")]  // Altrs when to change to the diffrent difficulty tracks
    public int mediumNum;
    public int hardNum;

    GameObject tr1;
    GameObject tr2;
    GameObject tr3;
    GameObject tr4;
    GameObject tr5;
    GameObject tr6;

    [HideInInspector]
    public int trackPiece1;
    [HideInInspector]
    public int trackPiece2;
    [HideInInspector]
    public int trackPiece3;
    [HideInInspector]
    public int trackPiece4;

    [Header("Special")]         // Special
    public bool spawnSpecials;
    public List<GameObject> specialObjs;
    [Space(5)]
    public float specialAppearNum;
    float startSpecialNum;

    [Header("Player")]
    public Transform playerTrans;
    Vector2 playerPos;

    GameMaster gMaster;
    TrackDifficultyManager trackDifficultyMan;

    // Use this for initialization
    void Awake()
    {
        //isStart = true;
        gMaster = GetComponent<GameMaster>();
        trackDifficultyMan = GetComponent<TrackDifficultyManager>();
        playerPos = playerTrans.position;
        startSpecialNum = specialAppearNum;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TrackMaintance();  // Creates the tracks

        Difficulty();   // Changes the difficulty in the difficulty manager script        
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

    void SpawnTracks()   // Creates the tracks at positions ahead of the player
    {
        Vector2 pos1 = new Vector2(playerTrans.position.x, playerPos.y - trackYPos);
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

        TrackCreation1(pos7, pos8, pos9, pos10);//, pos5, pos6);

        // Spawn Special
        if (playerTrans.position.x >= playerPos.x + specialAppearNum && spawnSpecials == true)
        {
            GameObject[] specialSpawn = GameObject.FindGameObjectsWithTag("Special Spawn");

            Instantiate(specialObjs[Random.Range(0, specialObjs.Count)], specialSpawn[1].transform.position, Quaternion.identity);

            specialAppearNum = specialAppearNum + startSpecialNum;
        }

    }

    // Creates the starting part of the track
    void TrackCreation1(Vector2 trackPos1, Vector2 trackPos2, Vector2 trackPos3, Vector2 trackPos4)//, Vector2 trackPos5, Vector2 trackPos6)
    {
        create = true;

        foreach (GameObject t in tracksObjs)
        {
            if (trackPos1.x < t.transform.position.x + spawnDis) // 11.5
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

            MediumTracksAdjust();

            create = false;

        }
    }

    // Alters the tracks difficulty by changing it in the DifficultyManager script
    void Difficulty()
    {
        if (gMaster.score < mediumNum)   //Easy
        {
            trackDifficultyMan.Easy();

        }
        else if (gMaster.score >= mediumNum && gMaster.score < hardNum) // Medium
        {
            trackDifficultyMan.Medium();
        }
        else    // Hard
        {
            trackDifficultyMan.Hard();
        }

    }

    void EasyTracksAdjust()
    {
    }

    void MediumTracksAdjust() // Adjust values of certain track pieces depending on the tracks in a set
    {
        if (tr1.name == "Track Saw Long(Clone)" && tr3.name == "Track Saw Long(Clone)")
        {
            print("Long Saws");

            tr1.GetComponentInChildren<SawArmRotate>().isRandom = false;
            tr3.GetComponentInChildren<SawArmRotate>().isRandom = false;

            tr1.GetComponentInChildren<SawArmRotate>().isClockwise = true;
            tr3.GetComponentInChildren<SawArmRotate>().isClockwise = true;
        }
    }

    void HardTracksAdjust()
    {
    }


}