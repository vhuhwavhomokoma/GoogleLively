using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioClip[] musicTracks;
    private AudioSource audioSource;
    private int TrackIndex = 0;

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
            PlayTrack(TrackIndex);
        }
    }

  

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            NextTrack();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            NextTrack();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayPreviousTrack();
        }

        

    }

    void PlayTrack(int index)
    {
        if (index >= 0 && index < musicTracks.Length)
        {
            audioSource.clip = musicTracks[index];
            audioSource.Play();
        }
    }

    public void NextTrack()
    {
        TrackIndex = (TrackIndex + 1) % musicTracks.Length;
        PlayTrack(TrackIndex);
    }

    public void PlayPreviousTrack()
    {
        TrackIndex = (TrackIndex - 1 + musicTracks.Length) % musicTracks.Length;
        PlayTrack(TrackIndex);
    }

    
}
