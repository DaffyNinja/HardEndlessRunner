using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraTestDebug : MonoBehaviour {

    float screenWidth;
    float screenHeight;

    float orthSize;

    Camera cam;
    public bool isIOS;
    public Text orthSizeTxt;

    public Transform playerTrans;

    // Use this for initialization
    void Awake ()
    {

        cam = GetComponent<Camera>();

        transform.position = new Vector3(playerTrans.position.x + 16, playerTrans.position.y + 2.5f, transform.position.z);


        screenHeight = Screen.height;
        screenWidth = Screen.width;   


        if (isIOS && screenHeight > 480 && screenWidth > 800)
        {
            orthSize = 11.5f;
        }
        else
        {
            orthSize = 12.5f;
        }

        cam.orthographicSize = orthSize;

        orthSizeTxt.text = orthSize.ToString();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
