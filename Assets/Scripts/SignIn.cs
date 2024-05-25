using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignIn : MonoBehaviour
{
    public void User_signin()
    {
        //Loading the next scene after signing in
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
