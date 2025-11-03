using UnityEngine;

public class SmallCoin : Coin
{
    protected override void Awake()
    {
        value = 5;
        base.Awake();
    }
}

