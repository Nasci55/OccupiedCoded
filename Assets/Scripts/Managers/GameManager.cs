using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform destination;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.Y) && Input.GetKey(KeyCode.E))
        {
            player.position = destination.position;
        }
    }
}
