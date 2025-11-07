using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player Player1;
    public Player Player2;
    
    void Start()
    {
        PlayerData player1Data = PlayerData.CreateArrowData();
        PlayerData player2Data = PlayerData.CreateWASDData();
        
        Player1.Initialize(player1Data);
        Player2.Initialize(player2Data);
    }

}
