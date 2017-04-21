using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDebug : MonoBehaviour
{
    public bool debugOn;

    public GameObject uiDebugPanel;
    public Text framesPerSecondTxt;

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
            float FPS = 1.0f / Time.deltaTime;

            framesPerSecondTxt.text = FPS.ToString();
        }
    }
}
