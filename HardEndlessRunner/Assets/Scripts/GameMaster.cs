using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour
{


    public float score;
    public int highScore;
    int currentHighScore;
    string highScoreKey = "HighScore";

    [Space(5)]
    public bool isEasy;
    public bool isMedium;
    public bool isHard;

    [Space(5)]
    public bool isGameOver;

    public Text scoreUI;
    public Text highScoreUI;
    public Text gOverscoreUI;
    public Text gOverhighScoreUI;
    [Space(5)]
    public GameObject inGameCanvas;
    public GameObject touchButtonCanvas;
    public GameObject gOverCanvas;
    [Space(5)]
    public GameObject playerObj;

    [Header("Game Type")]
    public bool isMainGame;
    public bool isLavaSpecial;

    Vector2 playerObjStartPos;

    [Header("Level Unlock")]
    public bool lavaUnlock;
    public bool sawUnlock;
    public bool upsideDownUnlock;

    int lavaNum;
    int sawNum;
    int upSideNum;


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
        if (isMainGame)
        {
            if (playerObj.GetComponent<PlayerMove>().isTouch == true)
            {
                touchButtonCanvas.SetActive(false);
            }
            else if (playerObj.GetComponent<PlayerMove>().isButtons == true)
            {
                touchButtonCanvas.SetActive(true);
            }
        }
        else if (isLavaSpecial)
        {
            if (playerObj.GetComponent<PlayerMoveLava>().isTouch == true)
            {
                touchButtonCanvas.SetActive(false);
            }
            else if (playerObj.GetComponent<PlayerMoveLava>().isButtons == true)
            {
                touchButtonCanvas.SetActive(true);
            }

        }  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Difficulty


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

                if (isMainGame)
                {
                    if (playerObj.GetComponent<PlayerMove>().obtainedBoost == false)   // Normal
                    {
                        score += Time.deltaTime * 3;
                    }
                    else   // Boost
                    {
                        score += Time.deltaTime * 4;
                    }
                }
                else if (isLavaSpecial)
                {
                    score += Time.deltaTime * 3;
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

        gOverscoreUI.text = Mathf.RoundToInt(score).ToString();

        // Highscore
        if (score > currentHighScore)
        {
            highScore = Mathf.RoundToInt(score);
            PlayerPrefs.SetInt("highScore", highScore);
            highScoreUI.text = currentHighScore.ToString();
            gOverhighScoreUI.text = currentHighScore.ToString();

        }
        else
        {
            gOverhighScoreUI.text = currentHighScore.ToString();
        }

    }

    void LevelUnlocks()
    {
        if (isMainGame)
        {
            if (score >= 100 || highScore >= 100)
            {
                lavaNum = 1;
                // Lava
                PlayerPrefs.SetInt("lavaNum", 1);

            }
            else if (score >= 200)
            {
                // Saw OnLY
                PlayerPrefs.SetInt("sawNum", 1);
            }
            else if (score >= 300)
            {
                // Upside down Cam
                PlayerPrefs.SetInt("upSideNum", 1);
            }
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
