using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int money;

    public static bool ShopWindowOpen;



    public void AddMoney(int _amount)
    {
        money += _amount;
    }

    public void RemoveMoney(int _amount)
    {
        money -= _amount;
    }

}
