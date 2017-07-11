using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackDifficultyManager : MonoBehaviour
{

    TrackCreaterManager trackMan;


    int easyRanNum;
    int mediumRanNum;
    int hardRanNum;

    [HideInInspector]
    public bool isTutorial;

    // Use this for initialization
    void Awake()
    {
        trackMan = GetComponent<TrackCreaterManager>();
    }

    private void FixedUpdate()
    {
        // Random numbers that change between track sets
        easyRanNum = Random.Range(0, trackMan.tNumListEasy.Count);
        mediumRanNum = Random.Range(0, trackMan.tNumListMedium.Count);
        hardRanNum = Random.Range(0, trackMan.tNumListHard.Count);
    }

    // Contains all the track numbers that are in the array and assigns the track nums to create the track sets   
    // The easy track sets numbers 
    public void Easy()
    {
        switch (easyRanNum)
        {
            case 0:
                trackMan.trackPiece1 = trackMan.tNumListEasy[0].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListEasy[0].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListEasy[0].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListEasy[0].trackNum4;
                break;
            case 1:
                trackMan.trackPiece1 = trackMan.tNumListEasy[1].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListEasy[1].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListEasy[1].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListEasy[1].trackNum4;
                break;
            case 2:
                trackMan.trackPiece1 = trackMan.tNumListEasy[2].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListEasy[2].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListEasy[2].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListEasy[2].trackNum4;
                break;
            case 3:
                trackMan.trackPiece1 = trackMan.tNumListEasy[3].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListEasy[3].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListEasy[3].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListEasy[3].trackNum4;
                break;
            case 4:
                trackMan.trackPiece1 = trackMan.tNumListEasy[4].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListEasy[4].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListEasy[4].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListEasy[4].trackNum4;
                break;
            case 5:
                trackMan.trackPiece1 = trackMan.tNumListEasy[5].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListEasy[5].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListEasy[5].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListEasy[5].trackNum4;
                break;
            case 6:
                trackMan.trackPiece1 = trackMan.tNumListEasy[6].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListEasy[6].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListEasy[6].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListEasy[6].trackNum4;
                break;
            case 7:
                trackMan.trackPiece1 = trackMan.tNumListEasy[7].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListEasy[7].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListEasy[7].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListEasy[7].trackNum4;
                break;                                       
            default:
                print("EASY ERROR!!");
                break;
        }


    }

    // The medium track sets numbers 
    public void Medium()
    {
        switch (mediumRanNum)
        {
            case 0:
                trackMan.trackPiece1 = trackMan.tNumListMedium[0].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListMedium[0].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListMedium[0].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListMedium[0].trackNum4;
                break;
            case 1:
                trackMan.trackPiece1 = trackMan.tNumListMedium[1].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListMedium[1].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListMedium[1].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListMedium[1].trackNum4;
                break;
            case 2:
                trackMan.trackPiece1 = trackMan.tNumListMedium[2].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListMedium[2].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListMedium[2].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListMedium[2].trackNum4;
                break;
            case 3:
                trackMan.trackPiece1 = trackMan.tNumListMedium[3].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListMedium[3].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListMedium[3].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListMedium[3].trackNum4;
                break;
            case 4:
                trackMan.trackPiece1 = trackMan.tNumListMedium[4].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListMedium[4].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListMedium[4].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListMedium[4].trackNum4;
                break;
            case 5:
                trackMan.trackPiece1 = trackMan.tNumListMedium[5].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListMedium[5].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListMedium[5].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListMedium[5].trackNum4;
                break;
            case 6:
                trackMan.trackPiece1 = trackMan.tNumListMedium[6].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListMedium[6].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListMedium[6].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListMedium[6].trackNum4;
                break;
            case 7:
                trackMan.trackPiece1 = trackMan.tNumListMedium[7].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListMedium[7].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListMedium[7].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListMedium[7].trackNum4;
                break;
            case 8:
                trackMan.trackPiece1 = trackMan.tNumListMedium[8].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListMedium[8].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListMedium[8].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListMedium[8].trackNum4;
                break;
            case 9:
                trackMan.trackPiece1 = trackMan.tNumListMedium[9].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListMedium[9].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListMedium[9].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListMedium[9].trackNum4;
                break;
            case 10:
                trackMan.trackPiece1 = trackMan.tNumListMedium[10].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListMedium[10].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListMedium[10].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListMedium[10].trackNum4;
                break;
            default:
                print("MEDIUM ERROR!!");
                break;
        }
    }

    // The hard track sets numbers 
    public void Hard()
    {
        switch (hardRanNum)
        {
            case 0:
                trackMan.trackPiece1 = trackMan.tNumListHard[0].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListHard[0].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListHard[0].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListHard[0].trackNum4;
                break;
            case 1:
                trackMan.trackPiece1 = trackMan.tNumListHard[1].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListHard[1].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListHard[1].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListHard[1].trackNum4;
                break;
            case 2:
                trackMan.trackPiece1 = trackMan.tNumListHard[2].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListHard[2].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListHard[2].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListHard[2].trackNum4;
                break;
            case 3:
                trackMan.trackPiece1 = trackMan.tNumListHard[3].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListHard[3].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListHard[3].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListHard[3].trackNum4;
                break;
            case 4:
                trackMan.trackPiece1 = trackMan.tNumListHard[4].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListHard[4].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListHard[4].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListHard[4].trackNum4;
                break;
            case 5:
                trackMan.trackPiece1 = trackMan.tNumListHard[5].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListHard[5].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListHard[5].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListHard[5].trackNum4;
                break;
            case 6:
                trackMan.trackPiece1 = trackMan.tNumListHard[6].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListHard[6].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListHard[6].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListHard[6].trackNum4;
                break;
            default:
                print("HARD ERROR!!!");
                break;
        }

    }


}
