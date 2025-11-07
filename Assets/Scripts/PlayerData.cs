using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private KeyCode _leftKey;
    private KeyCode _rightKey;
    private KeyCode _jumpKey;

    public PlayerData(KeyCode left, KeyCode right, KeyCode jump)
    {
        _leftKey = left;
        _rightKey = right;
        _jumpKey = jump;
    }

    public KeyCode GetLeftKey()
    {
        return _leftKey;
    }

    public KeyCode GetRightKey()
    {
        return _rightKey;
    }

    public KeyCode GetJumpKey()
    {
        return _jumpKey;
    }

    public static PlayerData CreateArrowData()
    {
        return new PlayerData (KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow);
    }

    public static PlayerData CreateWASDData()
    {
        return new PlayerData(KeyCode.A, KeyCode.D, KeyCode.W);
    }
}
