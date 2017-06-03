using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public bool runTutorial;
    public bool isAndroid;

    [Header("Tutorial Sections")]
    public float jumpTime;
    public float slideTime;

    public bool isJump;
    public bool isSlide;


    GameMaster gMaster;
    IOSGameMaster gMasterIOS;
    TrackCreaterManager trackMan;

    [Space(5)]
    public bool debug;

    TrackTester trackTest;

    float timer;

    // Use this for initialization
    void Awake()
    {
        trackMan = GetComponent<TrackCreaterManager>();

        if (runTutorial)
        {
            isJump = true;
            trackMan.isTutorial = true;

            if (isAndroid)
            {
                gMaster = GetComponent<GameMaster>();

            }
            else
            {
                gMasterIOS = GetComponent<IOSGameMaster>();
            }

            if (debug == true)
            {
                trackTest = GetComponent<TrackTester>();
            }

        }
        else
        {
            trackMan.isTutorial = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (runTutorial)
        {
            if (isAndroid)
            {
                timer += Time.deltaTime;

                if (timer <= jumpTime)
                {
                    isJump = true;
                    isSlide = false;
                }
                else if (timer >= jumpTime && timer <= slideTime)
                {
                    isJump = false;
                    isSlide = true;
                }
                else if (timer >= slideTime)
                {
                    print("TUT END");
                    runTutorial = false;
                }

                if (isJump == true)
                {
                    trackMan.trackPiece1 = 0;
                    trackMan.trackPiece2 = 0;
                    trackMan.trackPiece3 = 0;
                    trackMan.trackPiece4 = 2;
                }
                else if (isSlide == true)
                {
                    trackMan.trackPiece1 = 0;
                    trackMan.trackPiece2 = 0;
                    trackMan.trackPiece3 = 0;
                    trackMan.trackPiece4 = 24;
                }


            }

            if (debug)
            {
                timer += Time.deltaTime;

                if (timer <= jumpTime)
                {
                    isJump = true;
                    isSlide = false;
                }
                else if (timer >= jumpTime && timer <= slideTime)
                {
                    isJump = false;
                    isSlide = true;
                }
                else if (timer >= slideTime)
                {
                    print("TUT END");
                }

                if (isJump == true)
                {
                    trackTest.trackPiece4 = 20;
                }
                else if (isSlide == true)
                {
                    trackTest.trackPiece4 = 6;
                }

            }


        }

    }
}
