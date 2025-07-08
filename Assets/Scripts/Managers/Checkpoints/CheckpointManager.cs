using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckpointManager : MonoBehaviour
{
    static CheckpointManager instance;

    [SerializeField]
    private Stack<Checkpoint> checkpoints = new Stack<Checkpoint>();
    public static CheckpointManager Instance => instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public Vector3 LastCheckpointPosition()
    {
        Checkpoint LastCheckpoint = checkpoints.Peek();
        return LastCheckpoint.GetComponent<Transform>().position;
    }

    public void AddCheckpointToStack(Checkpoint checkpoint)
    {
        if (checkpoints == null)
        {
            foreach (Checkpoint previousCheckpoint in checkpoints)
            {
                if (previousCheckpoint == checkpoint)
                {
                    checkpoints.Push(checkpoint);
                    return;
                }
                else
                {
                    Debug.Log(checkpoints);
                    checkpoints.Push(checkpoint);
                }
            }
        }
        else
        {
            checkpoints.Push(checkpoint);
        }
    }
}
