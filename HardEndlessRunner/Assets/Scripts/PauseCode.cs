using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCode : MonoBehaviour {

    [HideInInspector]
    public bool isPaused;

	// Use this for initialization
	void Start ()
    {
        isPaused = false;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
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
