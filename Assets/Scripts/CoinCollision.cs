
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting; // needed for List

public class CoinCollision : MonoBehaviour
{
    public MoneyManager moneyManager;


    public Coin coin;



    void Awake()
    {

    }

    void Update()
    {
    }





    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        // Set to player after
        {
            moneyManager.AddMoney(coin.value);
            Destroy(gameObject);
        }
    }

}