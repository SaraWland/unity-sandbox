using UnityEngine;

public class Logger : MonoBehaviour
{
    private int updateCount = 0;
    private int fixedUpdateCount = 0;

    private void Awake()
    {
        Debug.Log($"[{Time.frameCount}][{Time.time}] Awake called");
    }

    private void OnEnable()
    {
        Debug.Log($"[{Time.frameCount}][{Time.time}] OnEnable called");
    }

    private void Start()
    {
        Debug.Log($"[{Time.frameCount}][{Time.time}] Start called");
    }

    private void Update()
    {
        if (updateCount < 3)
        {
            Debug.Log($"[{Time.frameCount}][{Time.time}] Update called");
            updateCount++;
        }
    }

    private void FixedUpdate()
    {
        if (fixedUpdateCount < 3)
        {
            Debug.Log($"[{Time.frameCount}][{Time.time}] FixedUpdate called");
            fixedUpdateCount++;
        }
    }
}
