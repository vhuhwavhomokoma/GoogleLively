

public class Currency
{
    //Virtual Currency management
    private int goldCoins;

    //Currency constructor
    public Currency(int coins)
    {
        goldCoins = coins;
    }

    //Getter method
    public int GetCoins()
    {
        return goldCoins;
    }

    //Add to currency
    public void AddGoldCoins(int amount)
    {
        goldCoins += amount;
    }

    //Subtract from currency
    public bool SubtractGoldCoins(int amount)
    {
        if (goldCoins >= amount)
        {
            goldCoins -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }


}
