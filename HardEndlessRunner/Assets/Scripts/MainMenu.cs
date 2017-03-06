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

    // Use this for initialization
    void Start()
    {
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
        specialTracksButton.SetBool("isHidden", true);
        playTracksButton.SetBool("isHidden", true);
        settingsTracksButton.SetBool("isHidden", true);
    }

    public void SettingsButton()
    {
        specialTracksButton.SetBool("isHidden", true);
        playTracksButton.SetBool("isHidden", true);
        settingsTracksButton.SetBool("isHidden", true);
    }
}

