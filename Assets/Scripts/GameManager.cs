using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;

    public int money = 43;
    public static bool ShopWindowOpen;


    private void Start()
    {
        moneyText.text = money.ToString();
    }




    public void AddMoney(int _amount)
    {
        money += _amount;
        moneyText.text = money.ToString();
    }

    public void RemoveMoney(int _amount)
    {
        money -= _amount;
        moneyText.text = money.ToString();
    }

    public static void PosInfoWindow()
    {

    }

}
