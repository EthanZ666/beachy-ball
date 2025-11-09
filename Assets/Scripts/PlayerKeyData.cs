using System;
using UnityEngine;

[System.Serializable]
public class PlayerKeyData
{
    private KeyCode _leftKey;
    private KeyCode _rightKey;
    private KeyCode _jumpKey;

    public PlayerKeyData(KeyCode left, KeyCode right, KeyCode jump)
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
    public void SetLeftKey(KeyCode key)
    {
        if (key == KeyCode.None)
        {
            throw new Exception("Invalid left key: cannot be None.");
        }

        if (key == _rightKey || key == _jumpKey)
        {
            throw new Exception($"Invalid left key: {key} is already used for movement.");
        }

        this._leftKey = key;
    }

    public void SetRightKey(KeyCode key)
    {
        if (key == KeyCode.None)
        {
            throw new Exception("Invalid right key: cannot be None.");
        }

        if (key == _leftKey || key == _jumpKey)
        {
            throw new Exception($"Invalid right key: {key} is already used for movement.");
        }

        this._rightKey = key;
    }

    public void SetJumpKey(KeyCode key)
    {
        if (key == KeyCode.None)
        {
            throw new Exception("Invalid jump key: cannot be None.");
        }

        if (key == _leftKey || key == _rightKey)
        {
            throw new Exception($"Invalid jump key: {key} is already used for movement.");
        }

        this._jumpKey = key;
    }


    public static PlayerKeyData CreateArrowData()
    {
        return new PlayerKeyData (KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow);
    }

    public static PlayerKeyData CreateWASDData()
    {
        return new PlayerKeyData(KeyCode.A, KeyCode.D, KeyCode.W);
    }
}
