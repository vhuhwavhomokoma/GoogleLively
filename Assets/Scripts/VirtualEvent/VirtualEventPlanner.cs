using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VirtualEventPlanner : MonoBehaviour
{

    public GameObject livestreamurl;

    public GameObject livestreambutton;

    public GameObject musicbutton;

    public TMP_InputField eventName;

    public TMP_InputField date;

    public TMP_InputField time;


    private bool checkstream = false;

    private bool checkmusic = false;

    private void Update()
    {
        if ((musicbutton.activeSelf == true && livestreambutton.activeSelf == false) )
        {
            checkmusic = true;
        }

        if ((musicbutton.activeSelf == false && livestreambutton.activeSelf == true))
        {
            checkstream = true;
        }
        
    }

    public void ToggleLiveStreamField()
    {
        if (livestreamurl != null)
        {
            bool isActive = livestreamurl.activeSelf;
            livestreamurl.SetActive(!isActive);
        }
    }

    public void toggleLiveStreamButton()
    {
        if (livestreambutton != null)
        {
            bool isActive = livestreambutton.activeSelf;
            livestreambutton.SetActive(!isActive);
        }
    }

    public void toggleMusicButton() {
        if (musicbutton != null)
        {
            bool isActive = musicbutton.activeSelf;
            musicbutton.SetActive(!isActive);
        }

    }

    public void ProceedToEvent()
    {
        
        if (eventName.text!="" || date.text!="" || time.text !="")
        {
            if (checkstream)
            {    string url_value = livestreamurl.GetComponent<TMP_InputField>().text;
               
                PlayerPrefs.SetString("UserInput",url_value);
                SceneManager.LoadScene(7);
            }

            if (checkmusic)
            {
                SceneManager.LoadScene(8);
            }


            
        }
      

        
    }

    public void returnToAvatarPhone()
    {
        SceneManager.LoadScene(2);
    }

}
