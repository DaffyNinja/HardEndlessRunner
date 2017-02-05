using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour {

    public float distance;

    public bool isGameOver;

    public Text distanceUI;
    public GameObject gOverCanvas;
    public PlayerMove playMove;

    // Use this for initialization
    void Awake ()
    {
        isGameOver = false;

        gOverCanvas.SetActive(false);

        distance = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (isGameOver)
        {
            GameOver();

            if (Input.GetKey(KeyCode.Return))
            {
                //Scene thisScene = SceneManager.GetActiveScene();

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (isGameOver == false)
        {
            distance += 2 * Time.deltaTime;
        }

        distanceUI.text = Mathf.RoundToInt(distance).ToString();


	}

    void GameOver()
    {
        gOverCanvas.SetActive(true);

        playMove.rightSpeed = 0;
        
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }

}
