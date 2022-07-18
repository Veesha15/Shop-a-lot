using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour // attached to empty game object
{
    private AudioManager AM;

    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] Button coinButton; 

    public int money { get; private set; }
    public static bool ShopWindowOpen;


    // ***** DEFAULT METHODS *****
    private void Awake()
    {
        AM = FindObjectOfType<AudioManager>();
        coinButton.onClick.AddListener(AddTestMoney);
    }

    private void Start()
    {
        moneyText.text = money.ToString();
        AddMoney(45);
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

    private void AddTestMoney()
    {
        money += 10;
        moneyText.text = money.ToString();
        AM.PlaySound(AM.coinDropSound);
    }


}
