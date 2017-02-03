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


        //trackPiece1 = tNumListEasy[0].trackNum1;
        //trackPiece2 = tNumListEasy[0].trackNum2;
        //trackPiece3 = tNumListEasy[0].trackNum3;
        //trackPiece4 = tNumListEasy[0].trackNum4;
    }

    public void Medium()
    {

    }

    public void Hard()
    {

    }


}
