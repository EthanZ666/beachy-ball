using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerOne Player1;
    public PlayerTwo Player2;
    
    void Start()
    {
        PlayerKeyData player1Data = PlayerKeyData.CreateArrowData();
        PlayerKeyData player2Data = PlayerKeyData.CreateWASDData();
        
        Player1.Initialize(player1Data);
        Player2.Initialize(player2Data);
    }

}