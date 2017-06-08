using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseIOS : MonoBehaviour {


    [HideInInspector]
    public bool isPaused;

    IOSGameMaster gMaster;

    // Use this for initialization
    void Awake()
    {
        isPaused = false;

        gMaster = GetComponent<IOSGameMaster>();

        gMaster.pauseCanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            gMaster.pauseCanvas.SetActive(true);
            gMaster.inGameCanvas.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {

            gMaster.pauseCanvas.SetActive(false);
            gMaster.inGameCanvas.SetActive(true);
            Time.timeScale = 1;
        }
        
    }

    public void PauseButton()
    {
        if (isPaused == false)
        {
            isPaused = true;
        }
        else
        {
            isPaused = false;
        }
    }
}
