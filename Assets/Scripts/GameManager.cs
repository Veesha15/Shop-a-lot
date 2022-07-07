using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int money { get; private set; }
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
