using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10f);
    [SerializeField] private ScreenShake screenShake;

    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private float CorrectedMinX => minX + cameraWidth;
    private float CorrectedMaxX => maxX - cameraWidth;
    private float CorrectedMinY => minY + cameraHeight;
    private float CorrectedMaxY => maxY - cameraHeight;

    private float cameraWidth;
    private float cameraHeight;

    private void Start()
    {
        Camera camera = GetComponent<Camera>();
        if (camera != null)
        {
            cameraWidth = camera.orthographicSize * camera.aspect;
            cameraHeight = camera.orthographicSize;
        }
    }

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothed = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    
            smoothed.x = Mathf.Clamp(smoothed.x, CorrectedMinX, CorrectedMaxX);
            smoothed.y = Mathf.Clamp(smoothed.y, CorrectedMinY, CorrectedMaxY);
    
            transform.position = smoothed + (screenShake != null ? screenShake.CurrentOffset : Vector3.zero);
        }
    }
}