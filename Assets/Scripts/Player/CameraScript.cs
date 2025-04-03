using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 100.0f;
    private Transform playerTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null)
        {
            PlayerScript player = FindFirstObjectByType<PlayerScript>();
            if (player == null) return;
            playerTransform = player.GetCameraTarget();
        }

        Vector3 targetPos = playerTransform.position;
        targetPos.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, cameraSpeed * Time.deltaTime);
    }
}
