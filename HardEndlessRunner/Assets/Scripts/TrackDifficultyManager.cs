using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackDifficultyManager : MonoBehaviour {

    TrackCreaterManager trackMan;

	// Use this for initialization
	void Start ()
    {
        trackMan = GetComponent<TrackCreaterManager>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {

		
	}

    public void Easy()
    {
        print("Easy");

        trackMan.trackPiece1 = trackMan.tNumListEasy[0].trackNum1;
        trackMan.trackPiece2 = trackMan.tNumListEasy[0].trackNum2;
        trackMan.trackPiece3 = trackMan.tNumListEasy[0].trackNum3;
        trackMan.trackPiece4 = trackMan.tNumListEasy[0].trackNum4;
    }

    public void Medium()
    {
        print("Medium");

        trackMan.trackPiece1 = trackMan.tNumListMedium[0].trackNum1;
        trackMan.trackPiece2 = trackMan.tNumListMedium[0].trackNum2;
        trackMan.trackPiece3 = trackMan.tNumListMedium[0].trackNum3;
        trackMan.trackPiece4 = trackMan.tNumListMedium[0].trackNum4;

    }

    public void Hard()
    {
        print("Hard");

        trackMan.trackPiece1 = trackMan.tNumListHard[0].trackNum1;
        trackMan.trackPiece2 = trackMan.tNumListHard[0].trackNum2;
        trackMan.trackPiece3 = trackMan.tNumListHard[0].trackNum3;
        trackMan.trackPiece4 = trackMan.tNumListHard[0].trackNum4;

    }


}
