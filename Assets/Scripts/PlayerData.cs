using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private KeyCode _leftKey;
    private KeyCode _rightKey;
    private KeyCode _jumpKey;

    public PlayerData(KeyCode left, KeyCode right, KeyCode jump)
    {
        this._leftKey = left;
        this._rightKey = right;
        this._jumpKey = jump;
    }

    public KeyCode GetLeftKey()
    {
        return this._leftKey;
    }

    public KeyCode GetRightKey()
    {
        return this._rightKey;
    }

    public KeyCode GetJumpKey()
    {
        return this._jumpKey;
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
