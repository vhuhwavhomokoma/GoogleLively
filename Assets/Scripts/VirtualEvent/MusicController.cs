using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioClip[] musicTracks;
    private AudioSource audioSource;
    private int TrackPos = 0;

    void Start()
    {
        musicTracks = Resources.LoadAll<AudioClip>("Music");
      
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (musicTracks.Length > 0)
        {
            PlayTrack(TrackPos);
        }
    }

  

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextTrack();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            PlayNextTrack();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayPreviousTrack();
        }

        

    }

    void PlayTrack(int songpos)
    {
        if (songpos >= 0 && songpos < musicTracks.Length)
        {
            audioSource.clip = musicTracks[songpos];
            audioSource.Play();
        }
    }

    public void PlayNextTrack()
    {
        TrackPos = (TrackPos + 1) % musicTracks.Length;
        PlayTrack(TrackPos);
    }

    public void PlayPreviousTrack()
    {
        TrackPos = (TrackPos - 1 + musicTracks.Length) % musicTracks.Length;
        PlayTrack(TrackPos);
    }

    
}
