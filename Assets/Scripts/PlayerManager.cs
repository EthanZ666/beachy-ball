using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerOne Player1;
    public PlayerTwo Player2;
    
    void Start()
    {
        PlayerData player1Data = PlayerData.CreateArrowData();
        PlayerData player2Data = PlayerData.CreateWASDData();
        
        Player1.Initialize(player1Data);
        Player2.Initialize(player2Data);
    }

}