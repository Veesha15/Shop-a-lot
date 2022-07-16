using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;

    public int money = 2; // TODO: make private
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

    public void AddTestMoney() // assigned to button in Inspector | for testing 
    {
        money += 10;
        moneyText.text = money.ToString();
    }



}
