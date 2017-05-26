using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class IOSGameMaster : MonoBehaviour
{

    public float score;
    public int highScore;
    int currentHighScore;
    string highScoreKey = "HighScore";

    [Space(5)]
    public bool isGameOver;

    // Pro text
    public TMP_Text scoreUI;
    public TMP_Text highScoreUI;

    public TMP_Text gOverScoreUI;
    public TMP_Text gOverHighScoreUI;

    [Space(5)]
    public GameObject inGameCanvas;
    public GameObject touchButtonCanvas;
    public GameObject gOverCanvas;
    [Space(5)]
    public GameObject playerObj;
    [Space(5)]
    public bool isLava;
    [Space(5)]
    public bool boostFrameRate;
    [Space(5)]
    public bool isEasy;
    public bool isMedium;
    public bool isHard;


    Vector2 playerObjStartPos;

    // Use this for initialization
    void Awake()
    {
        isGameOver = false;

        inGameCanvas.SetActive(true);

        gOverCanvas.SetActive(false);

        score = 0;

        playerObjStartPos = playerObj.transform.position;

        currentHighScore = PlayerPrefs.GetInt("highScore");

        // Deactivates the players  menu of the 
        if (!isLava)
        {
            if (playerObj.GetComponent<PlayerMoveIOS>().isTouch == true)
            {
                touchButtonCanvas.SetActive(false);
            }
            else if (playerObj.GetComponent<PlayerMoveIOS>().isButtons == true)
            {
                touchButtonCanvas.SetActive(true);
            }
        }
        else
        {
            if (playerObj.GetComponent<PlayerMoveLavaIOS>().isTouch == true)
            {
                touchButtonCanvas.SetActive(false);
            }
            else if (playerObj.GetComponent<PlayerMoveLavaIOS>().isButtons == true)
            {
                touchButtonCanvas.SetActive(true);
            }

        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (boostFrameRate)
        {
            Application.targetFrameRate = 60;
        }
        else
        {
            Application.targetFrameRate = -1;
        }

        if (isGameOver) // If the game is over reload the scene the player is on if the player presses enter 
        {
            GameOver();

            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }
        else if (isGameOver == false)
        {
            if (playerObj.transform.position.x > playerObjStartPos.x)
            {
                // Increases the players score based on time
                if (!isLava)
                {
                    if (playerObj.GetComponent<PlayerMoveIOS>().obtainedBoost == false)   // Normal
                    {
                        score += Time.deltaTime * 3;
                    }
                    else   // Boost
                    {
                        score += Time.deltaTime * 4;
                    }
                }
            }
        }

        // Debug
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        scoreUI.text = Mathf.RoundToInt(score).ToString();
        highScoreUI.text = currentHighScore.ToString();

    }

    void GameOver()
    {
        gOverCanvas.SetActive(true);

        inGameCanvas.SetActive(false);

        gOverScoreUI.text = Mathf.RoundToInt(score).ToString();

        // Highscore
        if (score > currentHighScore)
        {
            highScore = Mathf.RoundToInt(score);
            PlayerPrefs.SetInt("highScore", highScore);
            highScoreUI.text = currentHighScore.ToString();
            gOverHighScoreUI.text = currentHighScore.ToString();
        }
        else
        {
            gOverHighScoreUI.text = currentHighScore.ToString();
        }

    }

    void PhoneInput()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Buttons for the game over screen
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }

}