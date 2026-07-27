using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered kill zone. Reloading scene...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}