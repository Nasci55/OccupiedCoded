using UnityEngine;

public class DidThePlayerPassThrough : MonoBehaviour
{
    public bool didThePlayerPassThrough { get; private set; }


    void Start()
    {
        didThePlayerPassThrough = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            didThePlayerPassThrough = true;
        }
    }
}
