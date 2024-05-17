using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class AccountManagement : MonoBehaviour
{
    public TextMeshProUGUI accountbalance;
    private string apiUrl = "https://libraryweb4.azurewebsites.net/api/Your";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest(apiUrl));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetRequest(string url)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(": Error: " + webRequest.error);
        }
        else
        {
            string recv = webRequest.downloadHandler.text;
           
            accountbalance.text = recv;
        }
    }
}
