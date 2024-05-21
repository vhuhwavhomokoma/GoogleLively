using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class AccountManagement : MonoBehaviour
{
    public TextMeshProUGUI accountbalance; // Account balace displayed on UI
    private string apiUrl = "https://libraryweb4.azurewebsites.net/api/Your"; //API Gateway to database
    

    void Start()
    {
        StartCoroutine(GetRequest(apiUrl));
    }

    
    //Transition to payment gate
    public void OpenURL()
    {
        Application.OpenURL("https://www.example.com");
    }

    //Retrieve the value of the account balance from the databse
    IEnumerator GetRequest(string url)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        yield return webRequest.SendWebRequest();

        //Check for errors in connection
        if (webRequest.result != UnityWebRequest.Result.ConnectionError)
        {
            string recv = webRequest.downloadHandler.text;
           
            accountbalance.text = "L 100";
        }
    }
}
