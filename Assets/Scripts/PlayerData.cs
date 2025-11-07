using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;

    public PlayerData(KeyCode left, KeyCode right, KeyCode jump)
    {
        leftKey = left;
        rightKey = right;
        jumpKey = jump;
    }
}
