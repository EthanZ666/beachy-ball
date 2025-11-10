using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public TextMeshProUGUI winText;

    void Start()
    {
        string winner = PlayerPrefs.GetString("Winner", "Unknown");
        winText.text = winner + " Wins! Game Over!";
    }

    public void OnMainMenuButton()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(0);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}