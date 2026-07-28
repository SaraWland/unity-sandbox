using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform edgeCheck;
    [SerializeField] private float wallCheckDistance = 0.2f;
    [SerializeField] private float edgeCheckDistance = 0.5f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private int direction = 1; // 1 for right, -1 for left

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
        if (ShouldFlip())
        {
            FlipDirection();
        }
    }

    private bool ShouldFlip()
    {
        // Check for wall
        RaycastHit2D wallHit = Physics2D.Raycast(wallCheck.position, Vector2.right * direction, wallCheckDistance, groundLayer);
        if (wallHit.collider != null)
        {
            return true; // Wall detected
        }

        // Check for edge
        RaycastHit2D edgeHit = Physics2D.Raycast(edgeCheck.position, Vector2.down, edgeCheckDistance, groundLayer);
        if (edgeHit.collider == null)
        {
            return true; // Edge detected
        }

        return false; // No need to flip
    }

    private void FlipDirection()
    {
        direction *= -1; // Change direction
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); // Flip the sprite
    }
}