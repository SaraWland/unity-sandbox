using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private GameObject coinBurstPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Instantiate(coinBurstPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(1);
            }
            else
            {
                Debug.LogWarning("GameManager instance is null. Cannot add score.");
            }
        }
    }
}