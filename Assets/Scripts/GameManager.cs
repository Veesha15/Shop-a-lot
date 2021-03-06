using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour // attached to empty game object (Game Manager)
{
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] Button coinButton; 

    public int money { get; private set; }
    public static bool ShopWindowOpen;


    // ***** DEFAULT METHODS *****
    private void Awake()
    {
        coinButton.onClick.AddListener(AddTestMoney);
    }

    private void Start()
    {
        AddMoney(245);
    }


    // ***** CUSTOM METHODS *****
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

    private void AddTestMoney() // for testing purposes :)
    {
        money += 10;
        moneyText.text = money.ToString();
        AudioManager.Instance.PlaySound(AudioManager.Instance.coinDropSound);
    }


}
