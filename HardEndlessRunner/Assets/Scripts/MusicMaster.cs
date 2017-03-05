using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMaster : MonoBehaviour
{
    public bool goNextSong;
    [Space(5)]
    public int musicNum;

    public AudioClip[] musicTracks;

    AudioSource aSource;

    IEnumerator Start()
    {
        if (goNextSong)
        {
            aSource = GetComponent<AudioSource>();
            aSource.clip = musicTracks[musicNum];

            aSource.Play();
            yield return new WaitForSeconds(aSource.clip.length);

            if (musicNum >= musicTracks.Length)
            {
                musicNum = 0;
            }
            else
            {
                musicNum += 1;
            }

            aSource.clip = musicTracks[musicNum];

            aSource.Play();
        }
        else
        {
            aSource = GetComponent<AudioSource>();

            aSource.clip = musicTracks[musicNum];

            aSource.loop = true;

            aSource.Play();
       
        }
    }

}

