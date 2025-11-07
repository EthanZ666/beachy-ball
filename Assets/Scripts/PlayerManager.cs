using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player player1;
    public Player player2;
    
    void Start()
    {
        PlayerData player1Data = new PlayerData (KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow);
        PlayerData player2Data = new PlayerData(KeyCode.A, KeyCode.D, KeyCode.W);
        
        player1.Initialize(player1Data);
        player2.Initialize(player2Data);
    }

}
