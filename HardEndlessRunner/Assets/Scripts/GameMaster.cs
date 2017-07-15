using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameMaster : MonoBehaviour
{
    [Header("Score & Highscore")]
    public float score;
    public int highScore;
    int currentHighScore;
    string highScoreKey = "HighScore";

    [Header("Difficulty")]
    public bool isEasy;
    public bool isMedium;
    public bool isHard;

    [Space(5)]
    public bool isGameOver;

    [Header("UI")]
    public TMP_Text scoreUI;
    public TMP_Text highScoreUI;

    public TMP_Text gOverScoreUI;
    public TMP_Text gOverHighScoreUI;

    public TMP_Text gOverText;

    [Space(5)]
    public GameObject inGameCanvas;
    public GameObject touchButtonCanvas;
    public GameObject gOverCanvas;
    public GameObject tutorialCanvas;
    public GameObject pauseCanvas;

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

    [HideInInspector]
    public bool camD;
    [Space(5)]
    public bool isTutorial;
    [Space(5)]
    public GameObject playerObj;

    [HideInInspector]
    public static int runTutorialNum;


    // Use this for initialization
    void Awake()
    {
        isGameOver = false;
     
        if (runTutorialNum == 1)
        {
            isTutorial = true;
        }
        else
        {
            isTutorial = false;
        }

   
        if (isTutorial == false)
        {
            tutorialCanvas.SetActive(false);
            inGameCanvas.SetActive(true);
        }
        else
        {
            tutorialCanvas.SetActive(true);
            inGameCanvas.SetActive(false);
        }


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


        camD = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (isTutorial == false)
        {
            tutorialCanvas.SetActive(false);
            inGameCanvas.SetActive(true);
        }
        else
        {
            tutorialCanvas.SetActive(true);
            inGameCanvas.SetActive(false);
        }
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

        // Game Over Text
        if (playerObj.GetComponent<PlayerMove>().sawD == true)
        {
            gOverText.text = "BUUZZZZZZZ!";
        }
        else if (playerObj.GetComponent<PlayerMove>().spikeD == true)
        {
            gOverText.text = "Swiss Cheese!";
        }
        else if (camD == true)
        {
            gOverText.text = "Run Faster!!!";
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

    void PhoneInput()  // Android
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
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
