using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{

    [SerializeField] private string nextSceneName = "Phase4";

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}