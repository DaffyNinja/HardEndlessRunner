using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public bool doAnimation;
    [Space(5)]
    public Animator playTracksButton;
    public Animator specialTracksButton;
    public Animator settingsTracksButton;
    [Space(5)]
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject specialTracksPanel;

    [Header("Special Levels Menu")]
    public Button lavaButon;
    public Button sawButton;
    public Button upSideDwnButton;

    // Use this for initialization
    void Start()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        specialTracksPanel.SetActive(false);

        specialTracksButton.SetBool("isHidden", false);
        playTracksButton.SetBool("isHidden", false);
        settingsTracksButton.SetBool("isHidden", false);
    }

    // Update is called once per frame
    void Update()
    {
        // Unlocks
        if (PlayerPrefs.GetInt("lavaNum") == 0)
        {

            lavaButon.interactable = false;
        }
        else
        {

            lavaButon.interactable = true;
        }

        if (PlayerPrefs.GetInt("sawNum") == 0)
        {

            sawButton.interactable = false;
        }
        else
        {

            sawButton.interactable = true;
        }

        if (PlayerPrefs.GetInt("upSideNum") == 0)
        {
            upSideDwnButton.interactable = false;
        }
        else
        {
            upSideDwnButton.interactable = true;
        }

    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void SpecialTracksButton()
    {
        specialTracksPanel.SetActive(true);

        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);


        specialTracksButton.SetBool("isHidden", true);
        playTracksButton.SetBool("isHidden", true);
        settingsTracksButton.SetBool("isHidden", true);
    }

    public void SettingsButton()
    {
        settingsPanel.SetActive(true);

        mainMenuPanel.SetActive(false);
        specialTracksPanel.SetActive(false);

        specialTracksButton.SetBool("isHidden", true);
        playTracksButton.SetBool("isHidden", true);
        settingsTracksButton.SetBool("isHidden", true);
    }

    public void SpecialBackButton()
    {
        mainMenuPanel.SetActive(true);

        specialTracksPanel.SetActive(false);
        settingsPanel.SetActive(false);

        specialTracksButton.SetBool("isHidden", true);
        playTracksButton.SetBool("isHidden", true);
        settingsTracksButton.SetBool("isHidden", true);

    }

    public void LavaButton()
    {
        SceneManager.LoadScene(2);
    }

    public void SawButton()
    {
        SceneManager.LoadScene(3);
    }

    public void UpsideDownButton()
    {
        SceneManager.LoadScene(4);
    }
}

