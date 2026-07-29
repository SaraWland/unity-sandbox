using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    [SerializeField] private AudioClip playerDamageSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered kill zone. Reloading scene...");
            AudioSource.PlayClipAtPoint(playerDamageSound, transform.position);
            FindAnyObjectByType<ScreenShake>().Shake(0.15f, 0.1f);
            EndScreenManager.Instance.ShowEndScreen(false);
        }
    }
}