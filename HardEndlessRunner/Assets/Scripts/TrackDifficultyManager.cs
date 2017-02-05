using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackDifficultyManager : MonoBehaviour {

    TrackCreaterManager trackMan;

    int easyRanNum;
    int mediumRanNum;
    int hardRanNum;


    // Use this for initialization
    void Awake ()
    {
        trackMan = GetComponent<TrackCreaterManager>();
    }

    private void FixedUpdate()
    {
        easyRanNum = Random.Range(0, trackMan.tNumListEasy.Length);
        mediumRanNum = Random.Range(0, trackMan.tNumListMedium.Length);
        hardRanNum = Random.Range(0, trackMan.tNumListHard.Length);
    }

    public void Easy()
    {
        print("Easy");

       
        switch (easyRanNum)
        {
            case 0:
               // print(0);

                trackMan.trackPiece1 = trackMan.tNumListEasy[0].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListEasy[0].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListEasy[0].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListEasy[0].trackNum4;
                break;
            case 1:
               // print(1);

                trackMan.trackPiece1 = trackMan.tNumListEasy[1].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListEasy[1].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListEasy[1].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListEasy[1].trackNum4;
                break;
            case 2:
               // print(2);

                trackMan.trackPiece1 = trackMan.tNumListEasy[2].trackNum1;
                trackMan.trackPiece2 = trackMan.tNumListEasy[2].trackNum2;
                trackMan.trackPiece3 = trackMan.tNumListEasy[2].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListEasy[2].trackNum4;
                break;
            default:
                print("EASY ERROR!!");
                break;
        }

    }

    public void Medium()
    {
        print("Medium");

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
            default:
                print("MEDIUM ERROR!!");
                break;
        }
    }

    public void Hard()
    {
        print("Hard");

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
               // trackMan.trackPiece2 = trackMan.tNumListHard[2].trackNum2;

                trackMan.trackPiece3 = trackMan.tNumListHard[2].trackNum3;
                trackMan.trackPiece4 = trackMan.tNumListHard[2].trackNum4;
                break; 
            default:
                print("HARD ERROR!!!");
                break;
        }

    }


}
