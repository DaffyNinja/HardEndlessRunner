using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDebug : MonoBehaviour
{
    public bool debugOn;

    public Text framesPerSecondTxt;
    public Text difficultyText;

    public GameObject uiDebugPanel;

    public GameMaster gMaster;



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
            if (gMaster.isEasy)
            {
                difficultyText.text = "Easy";
            }
            else if (gMaster.isMedium)
            {
                difficultyText.text = "Medium";
            }
            else if (gMaster.isHard)
            {
                difficultyText.text = "Hard";
            }


        }
    }
}
