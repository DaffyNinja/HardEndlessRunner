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

    TrackCreaterManager trackMan;

    [Header("Easy")]
    public int trackPieceEasy1;
    public int trackPieceEasy2;
    public int trackPieceEasy3;
    public int trackPieceEasy4;

    [Header("Medium")]
    public int trackPieceMedium1;
    public int trackPieceMedium2;
    public int trackPieceMedium3;
    public int trackPieceMedium4;

    [Header("Hard")]
    public int trackPieceHard1;
    public int trackPieceHard2;
    public int trackPieceHard3;
    public int trackPieceHard4;

    [Space(10)]
    public bool isTest;

    // Use this for initialization
    void Awake ()
    {
        trackMan = GetComponent<TrackCreaterManager>();

        isGameOver = false;

        gOverCanvas.SetActive(false);

        distance = 0;


    }
	
	// Update is called once per frame
	void Update ()
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

        if (isTest == false)
        {
            DificultyChange();
        }
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

    void DificultyChange()
    {

        if (distance >= 15 && distance < 25)
        {
            trackMan.trackPiece1 = trackPieceMedium1;
            trackMan.trackPiece2 = trackPieceMedium2;
            trackMan.trackPiece3 = trackPieceMedium3;
            trackMan.trackPiece4 = trackPieceMedium4;

        }
        else if (distance >= 25)
        {
            trackMan.trackPiece1 = trackPieceHard1;
            trackMan.trackPiece2 = trackPieceHard2;
            trackMan.trackPiece3 = trackPieceHard3;
            trackMan.trackPiece4 = trackPieceHard4;
        }
        else
        {
            trackMan.trackPiece1 = trackPieceEasy1;
            trackMan.trackPiece2 = trackPieceEasy2;
            trackMan.trackPiece3 = trackPieceEasy3;
            trackMan.trackPiece4 = trackPieceEasy4;
        }


    }


}
