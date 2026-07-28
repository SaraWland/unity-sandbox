using UnityEngine;
using UnityEngine.InputSystem;

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
}