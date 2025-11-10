using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI Player1ScoreValue;
    public TextMeshProUGUI Player2ScoreValue;

    [Header("Rules")]
    [SerializeField] private int winningScore = 5;

    [Header("Ball")]
    [SerializeField] private BallCollision2D ball;

    private int player1Score = 0;
    private int player2Score = 0;

    void Awake()
    {
        if (ball == null) ball = Object.FindFirstObjectByType<BallCollision2D>();
        UpdateScoreDisplay();
    }

    public void AddScoreToPlayer1()
    {
        player1Score++;
        UpdateScoreDisplay();
        if (player1Score >= winningScore)
            HandleWin(1);
    }

    public void AddScoreToPlayer2()
    {
        player2Score++;
        UpdateScoreDisplay();
        if (player2Score >= winningScore)
            HandleWin(2);
    }

    private void HandleWin(int winner)
    {
        Debug.Log($"Player {winner} wins! Resetting scores and respawning ball.");

        player1Score = 0;
        player2Score = 0;
        UpdateScoreDisplay();

        if (ball != null)
        {
            ball.ResetRally();
            ball.ServeRandom(); 
        }
        else
        {
            Debug.LogWarning("ScoreTracker: No BallCollision2D reference set; cannot respawn the ball.");
        }
    }

    private void UpdateScoreDisplay()
    {
        if (Player1ScoreValue != null) Player1ScoreValue.text = player1Score.ToString();
        if (Player2ScoreValue != null) Player2ScoreValue.text = player2Score.ToString();
    }
}
