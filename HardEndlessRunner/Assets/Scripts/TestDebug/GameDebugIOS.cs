using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDebugIOS : MonoBehaviour {

    public bool debugOn;

    public Text framesPerSecondTxt;
    public Text difficultyText;

    public GameObject uiDebugPanel;

    public TrackCreaterManager tManager;

   // public IOSGameMaster gMaster;



    // Use this for initialization
    void Start()
    {
        if (debugOn)
        {
            uiDebugPanel.SetActive(true);
        }
        else
        {
            uiDebugPanel.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (debugOn)
        {
            // FPS
            float FPS = 1.0f / Time.deltaTime;
            framesPerSecondTxt.text = "FPS: " + Mathf.Round(FPS).ToString();

            //Difficulty
            if (tManager.isEasyIOS)
            {
                difficultyText.text = "EASY";
            }
            else if (tManager.isMediumIOS)
            {
                difficultyText.text = "MEDIUM";
            }
            else if (tManager.isHardIOS)
            {
                difficultyText.text = "HARD";
            }


        }
    }
}
