using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Windows;

public class AccountManagement : MonoBehaviour
{
    public TextMeshProUGUI accountbalance; // Account balace displayed on UI
    private string apiUrl = "https://libraryweb4.azurewebsites.net/api/Your"; //API Gateway to database
    

    void Start()
    {
        StartCoroutine(GetRequest(apiUrl)); //concurrency
        
    }

    
    //Transition to payment gate
    public void OpenURL()
    {
        Application.OpenURL("https://www.example.com");
    }


    public string extractAmount(string jsonstring)
    {
        char[] charsToTrim = { '[', ']', '{', '}' };
        string result = jsonstring.Trim(charsToTrim);
        string[] strings = result.Split(":");

        return strings[4];
    }

 

    //Retrieve the value of the account balance from the databse
    public IEnumerator GetRequest(string url)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        yield return webRequest.SendWebRequest();

        //Check for errors in connection
        if (webRequest.result != UnityWebRequest.Result.ConnectionError)
        {
            string recv = webRequest.downloadHandler.text;
            
            accountbalance.text = "Available Balance: L " + extractAmount(recv);
            PlayerPrefs.SetString("UserAmount", extractAmount(recv));

        }
    }
}
