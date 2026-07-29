using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyContact : MonoBehaviour
{
    [SerializeField] private float stompDetectionThreshold = -0.5f;
    [SerializeField] private AudioClip stompSound;
    [SerializeField] private AudioClip playerDamageSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player
        if (!collision.gameObject.CompareTag("Player")) return;

        // Check the collision normal to determine if the player is above the enemy
        if (collision.contacts[0].normal.y < stompDetectionThreshold)
        {
            // Player is above the enemy, destroy the enemy
            Destroy(gameObject);
            Rigidbody2D playerRb = collision.rigidbody;
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, 3f); // Bounce the player up
            AudioSource.PlayClipAtPoint(stompSound, transform.position);
            Debug.Log("Enemy destroyed by player stomp");
        }
        else
        {
            // Player is not above the enemy, reload the scene
            Debug.Log("Player killed by enemy contact");
            collision.gameObject.GetComponent<HitFlash>().Flash();
            FindAnyObjectByType<ScreenShake>().Shake(0.15f, 0.1f);
            AudioSource.PlayClipAtPoint(playerDamageSound, transform.position);
            EndScreenManager.Instance.ShowEndScreen(false);
        }
    }
}