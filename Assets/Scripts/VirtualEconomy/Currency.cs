

public class Currency
{
    //Virtual Currency management
    private int LivelyCoins;

    //Currency constructor
    public Currency(int coins)
    {
        LivelyCoins = coins;
    }

    //Getter method
    public int GetCoins()
    {
        return LivelyCoins;
    }

    //Add to currency
    public void Add(int amount)
    {
        LivelyCoins = LivelyCoins + amount;
    }

    //Subtract from currency
    public bool Subtract(int amount)
    {
        if (LivelyCoins >= amount)
        {
            LivelyCoins = LivelyCoins - amount;
            return true;
        }
        else
        {
            return false;
        }
    }


}
