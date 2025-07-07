using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager checkpointManager;
    private void Start()
    {
        checkpointManager = FindFirstObjectByType<CheckpointManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            checkpointManager.AddCheckpointToStack(this);
            Debug.Log("Checkpoint Entered");
        }
    }
}
