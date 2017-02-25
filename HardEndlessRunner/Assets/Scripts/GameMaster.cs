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
    public bool isGameOver;

    public Text scoreUI;
    public Text highScoreUI;

    public GameObject touchButtonCanvas;
    public GameObject gOverCanvas;

    public GameObject playerObj;

    Vector2 playerObjStartPos;

    // Use this for initialization
    void Awake()
    {
        isGameOver = false;

        gOverCanvas.SetActive(false);

        score = 0;

        playerObjStartPos = playerObj.transform.position;

        currentHighScore = PlayerPrefs.GetInt("highScore");

        if (playerObj.GetComponent<PlayerMove>().isTouch || playerObj.GetComponent<PlayerMove>().isPC)
        {
            touchButtonCanvas.SetActive(false);
        }
        else
        {
            touchButtonCanvas.SetActive(true);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
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
        else if (isGameOver == false)
        {
            if (playerObj.transform.position.x > playerObjStartPos.x)
            {
                if (playerObj.GetComponent<PlayerMove>().obtainedBoost == false)
                {
                    score += Time.deltaTime;
                }
                else
                {
                    score += Time.deltaTime * 2;
                }
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }



        scoreUI.text = Mathf.RoundToInt(score).ToString();
        highScoreUI.text = currentHighScore.ToString();

       // PhoneInput();
    }

    void GameOver()
    {
        gOverCanvas.SetActive(true);

        // Highscore
        if (score > currentHighScore)
        {
            //highScore = currentHighScore;
            //highScore = Mathf.RoundToInt(score);

            highScore = Mathf.RoundToInt(score);
            PlayerPrefs.SetInt("highScore", highScore);
            highScoreUI.text = currentHighScore.ToString();

        }

    }

    void PhoneInput()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }

}
