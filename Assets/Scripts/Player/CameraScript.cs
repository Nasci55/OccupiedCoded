using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform playerTransform;
    private Transform camLocation;
    void Start()
    {
        camLocation = GetComponent<Transform>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerTransform.rotation.y == 0)
        {
            camLocation.position = new Vector3(playerTransform.position.x + 50, playerTransform.position.y + 50, -10f);
        }
        else
        {
            camLocation.position = new Vector3(playerTransform.position.x - 50, playerTransform.position.y + 50, -10f);
            
        }
    }
}
