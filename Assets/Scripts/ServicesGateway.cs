using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServicesGateway : MonoBehaviour
{
 

    // Transition to Virtual Market
    public void ToVirtualMarket()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Transition to Virtual Event Setup
    public void ToVirtualEvent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    //Transition back to the Avatar's virtual room
    public void ToVirtualRoom()
    {
        SceneManager.LoadScene(1);
    }

}
