using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckpointManager : MonoBehaviour
{
    static CheckpointManager instance;

    [SerializeField]
    private Stack<Checkpoint> checkpoints = new Stack<Checkpoint>();
    
    [SerializeField]
    private Checkpoint initialCheckpoint;

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
        if (checkpoints.Count > 0)
        {
            Checkpoint LastCheckpoint = checkpoints.Peek();
            return LastCheckpoint.GetComponent<Transform>().position;
        }
        return initialCheckpoint.GetComponent<Transform>().position;
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
            }
             Debug.Log(checkpoints.ToString());
             checkpoints.Push(checkpoint);
        }
        else
        {
            checkpoints.Push(checkpoint);
        }
    }
}
