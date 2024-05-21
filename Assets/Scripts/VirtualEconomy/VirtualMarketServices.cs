using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VirtualMarketServices : MonoBehaviour
{
    public void ToVirtualMarketBuy()
    {
        SceneManager.LoadScene(5);
    }

    public void ToVirtualMarketSell() {

        SceneManager.LoadScene(6);
    }

    public void ToVirtualPhone()
    {
        SceneManager.LoadScene(2);
    }

    public void ToVirtualMarket()
    {
        SceneManager.LoadScene(3);
    }
}
