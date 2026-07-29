using UnityEngine;

public class EnemyAnimationOffset : MonoBehaviour
{
    private void Start()
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            float randomOffset = Random.Range(0f, 1f);
            animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, 0, randomOffset);
        }
        else
        {
            Debug.LogWarning("Animator component not found on the coin object.");
        }
    }
}