using UnityEngine;

public class BigCoin : Coin
{
    protected override void Awake()
    {
        value = 20;
        base.Awake();
    }
}