using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDebug : MonoBehaviour {

   public Text framesPerSecondTxt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float FPS = 1.0f / Time.deltaTime;

        framesPerSecondTxt.text = FPS.ToString();
		
	}
}
