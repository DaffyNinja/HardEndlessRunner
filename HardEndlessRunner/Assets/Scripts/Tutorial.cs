using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{

    public bool runTutorial;
    public bool isAndroid;

    [Header("Tutorial Sections")]
    public float jumpTime;
    public float slideTime;

    public bool isJump;
    public bool isSlide;

    [Header("UI")]
    public TMP_Text tutText;
    public string jumptext;
    public string slideText;


    GameMaster gMaster;
    IOSGameMaster gMasterIOS;
    TrackCreaterManager trackMan;
    TrackDifficultyManager trackDifficult;

    [Space(5)]
    public bool debug;

    TrackTester trackTest;

    float timer;

    // Use this for initialization
    void Awake()
    {
        trackMan = GetComponent<TrackCreaterManager>();

        if (runTutorial && debug == false)
        {
            isJump = true;
            trackMan.isTutorial = true;

            if (isAndroid)
            {
                trackDifficult = GetComponent<TrackDifficultyManager>();

                trackDifficult.isTutorial = true;

                gMaster = GetComponent<GameMaster>();
                gMaster.isTutorial = true;

            }
            else
            {
                gMasterIOS = GetComponent<IOSGameMaster>();
            }


        }
        else if (debug == true)
        {
            trackTest = GetComponent<TrackTester>();
            isJump = true;
           
        }
        else
        {
            trackMan.isTutorial = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (runTutorial && debug == false)
        {
            if (isAndroid)
            {
                timer += Time.deltaTime;


                if (isJump == true)
                {
                    tutText.text = jumptext;

                    trackMan.trackPiece1 = 0;
                    trackMan.trackPiece2 = 0;
                    trackMan.trackPiece3 = 0;
                    trackMan.trackPiece4 = 2;
                }
                else if (isSlide == true)
                {
                    tutText.text = slideText;

                    trackMan.trackPiece1 = 0;
                    trackMan.trackPiece2 = 0;
                    trackMan.trackPiece3 = 0;
                    trackMan.trackPiece4 = 24;
                }

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
                else if (timer >= slideTime) // tutorial END
                {
                    //print("TUT END");

                    isSlide = false;
                    trackMan.isTutorial = false;
                    gMaster.isTutorial = false;

                    runTutorial = false;

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
