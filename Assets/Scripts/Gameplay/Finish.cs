using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioClip levelCompleteSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Level Completed!");
            AudioSource.PlayClipAtPoint(levelCompleteSound, transform.position);
            EndScreenManager.Instance.ShowEndScreen(true);
        }
    }
}