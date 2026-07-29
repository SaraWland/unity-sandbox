using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private PlayerMovement playerMovement;

    private bool isPaused = false;

    private void Update()
    {
        if (Keyboard.current != null && 
            Keyboard.current.escapeKey.wasPressedThisFrame &&
            !EndScreenManager.Instance.IsEndScreenActive)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        PauseMenuUI.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
        playerMovement.ToggleControls(!isPaused);
    }

    public void OnMainMenuButtonClicked()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene("TitleScreen");
    }
}