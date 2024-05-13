using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServicesGateway : MonoBehaviour
{
 

    // Update is called once per frame
    public void ToVirtualMarket()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
