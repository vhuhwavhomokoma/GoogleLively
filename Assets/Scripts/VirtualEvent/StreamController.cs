using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StreamController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    void Start()
    {
        PlayStream();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            StopStream();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayStream();
        }
    }

    public void PlayStream()
    {
        string url = PlayerPrefs.GetString("UserInput", "No input found");
        if (!string.IsNullOrEmpty(url))
        {
            videoPlayer.url = url;
            videoPlayer.Play();
        }
       
    }

    public void StopStream()
    {
        videoPlayer.Stop();
    }
}
