using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player Player1;
    public Player Player2;
    
    void Start()
    {
        PlayerData player1Data = new PlayerData (KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow);
        PlayerData player2Data = new PlayerData(KeyCode.A, KeyCode.D, KeyCode.W);
        
        Player1.Initialize(player1Data);
        Player2.Initialize(player2Data);
    }

}
