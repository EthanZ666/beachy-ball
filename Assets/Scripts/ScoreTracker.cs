using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public TextMeshProUGUI Player1ScoreValue;
    public TextMeshProUGUI Player2ScoreValue;

    private int player1Score = 0;
    private int player2Score = 0;

    public void AddScoreToPlayer1()
    {
        player1Score++;
        UpdateScoreDisplay();
    }

    public void AddScoreToPlayer2()
    {
        player2Score++;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        if (Player1ScoreValue != null)
            Player1ScoreValue.text = player1Score.ToString();
        if (Player2ScoreValue != null)
            Player2ScoreValue.text = player2Score.ToString();
    }
}

