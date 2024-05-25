using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Windows;

public class AccountManagement : MonoBehaviour
{
    public TextMeshProUGUI accountbalance; // Account balace displayed on UI
    private string url = "https://libraryweb4.azurewebsites.net/api/Your"; //API Gateway to database
    

    void Start()
    {
        StartCoroutine(Get(url)); //concurrency
        
    }

    
    //Transition to payment gate
    public void OpenURL()
    {
        Application.OpenURL("https://libraryweb-1.azurewebsites.net");
    }


    public string extractAmount(string jsonstring)
    {
        char[] charsToTrim = { '[', ']', '{', '}' };
        string result = jsonstring.Trim(charsToTrim);
        string[] strings = result.Split(":");

        return strings[4];
    }

 

    //Retrieve the value of the account balance from the databse
    public IEnumerator Get(string url)
    {
        UnityWebRequest Request = UnityWebRequest.Get(url);

        yield return Request.SendWebRequest();

        
        if (Request.result != UnityWebRequest.Result.ConnectionError)
        {
            string recv = Request.downloadHandler.text;
            
            accountbalance.text = "Available Balance: L " + extractAmount(recv);
           

        }
        else
        {
            Debug.LogError(Request.error);
        }
    }
}
