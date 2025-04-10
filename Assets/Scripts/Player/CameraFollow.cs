using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public enum Type{ Teleport, Linear,  FeedbackLoop };
    public Type type;
    [SerializeField] private float cameraSpeed = 100.0f;
    private Transform playerTransform;
    [SerializeField] Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerTransform == null)
        {
            Player player = FindFirstObjectByType<Player>();
            if (player == null) return;
            playerTransform = player.GetCameraTarget();
        }

        Vector3 targetPos = playerTransform.position + offset;
        targetPos.z = transform.position.z;
//        transform.position = Vector3.MoveTowards(transform.position, targetPos, cameraSpeed* Time.fixedDeltaTime);
        
        switch (type)
        {
            case Type.Teleport:
                transform.position = targetPos;
                break;
            case Type.Linear:
                transform.position = Vector3.MoveTowards(transform.position, targetPos, cameraSpeed * Time.fixedDeltaTime);
                break;
            case Type.FeedbackLoop:
                {
                    Vector3 toDestination = targetPos - transform.position;
                    transform.position += toDestination * cameraSpeed;
                }
                break;

        }
    }
}
