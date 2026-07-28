using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    public static EndScreenManager Instance { get; private set; }
    public bool IsEndScreenActive { get; private set; } = false;

    [SerializeField] private GameObject endScreenUI;
    [SerializeField] private TextMeshProUGUI resultText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void ShowEndScreen(bool isWin)
    {
        Time.timeScale = 0f; // Pause the game
        endScreenUI.SetActive(true);
        resultText.text = isWin ? "You Win!" : "Game Over!";
        IsEndScreenActive = true;
    }

    public void OnRestartButtonClicked()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnMainMenuButtonClicked()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene("TitleScreen");
    }
}