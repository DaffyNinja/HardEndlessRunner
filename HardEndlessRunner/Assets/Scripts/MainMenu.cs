using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
}

