using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI Player1ScoreValue;
    public TextMeshProUGUI Player2ScoreValue;

    [Header("Rules")]
    [SerializeField] private int _winningScore = 5;

    [Header("Ball")]
    [SerializeField] private BallCollision2D _ball;

    private int _player1Score = 0;
    private int _player2Score = 0;

    void Awake()
    {
        if (_ball == null) _ball = Object.FindFirstObjectByType<BallCollision2D>();
        UpdateScoreDisplay();
    }

    public void AddScoreToPlayer1()
    {
        _player1Score++;
        UpdateScoreDisplay();
        if (_player1Score >= _winningScore)
            HandleWin(1);
    }

    public void AddScoreToPlayer2()
    {
        _player2Score++;
        UpdateScoreDisplay();
        if (_player2Score >= _winningScore)
            HandleWin(2);
    }

    private void HandleWin(int winner)
    {
        Debug.Log($"Player {winner} wins! Resetting scores and respawning ball.");

        _player1Score = 0;
        _player2Score = 0;
        UpdateScoreDisplay();

        if (_ball != null)
        {
            _ball.ResetRally();
            _ball.ServeRandom();
        }
        else

        PlayerPrefs.SetString("Winner", $"Player {winner}");
        PlayerPrefs.SetInt("Player1Score", _player1Score);
        PlayerPrefs.SetInt("Player2Score", _player2Score);
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    private void UpdateScoreDisplay()
    {
        if (Player1ScoreValue != null) Player1ScoreValue.text = _player1Score.ToString();
        if (Player2ScoreValue != null) Player2ScoreValue.text = _player2Score.ToString();
    }
}
