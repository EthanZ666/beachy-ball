using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;
    public TextMeshProUGUI MoneyText;
    private int _money = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(this);
            return;
        }
        if (MoneyText == null)
        {
            MoneyText = GetComponentInChildren<TextMeshProUGUI>();
            if (MoneyText != null) Debug.Log("MoneyManager: auto-found moneyText: " + MoneyText.name);
        }
        UpdateUI();
    }

    public void AddMoney(int amount)
    {
        _money += amount;
        Debug.Log("MoneyManager.AddMoney called, total=" + _money);
        UpdateUI();

    }

    public void UpdateUI()
    {
        if (MoneyText == null)
        {
            Debug.LogError("MoneyManager.UpdateUI: MoneyText is Null!");
            return;
        }
        MoneyText.text = "$" + _money;
    }
    void Start()
    {
        MoneyText.text = "$" + _money;
    }
}