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
        camLocation.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 50, -10f);
    }

    // Update is called once per frame
    void Update()
    {

        if (playerTransform.rotation.y == 0)
        {
            if (camLocation.position.x < playerTransform.position.x + 50)
            {
                camLocation.position = new Vector3(playerTransform.position.x + 2, playerTransform.position.y + 50, -10f);
            }
            else
            {
                camLocation.position = new Vector3(playerTransform.position.x + 50, playerTransform.position.y + 50, -10f);
            }
        }
        else
        {
            if (camLocation.position.x > playerTransform.position.x - 50)
            {
                camLocation.position = new Vector3(playerTransform.position.x - 2, playerTransform.position.y + 50, -10f);
            }
            else
            {
                camLocation.position = new Vector3(playerTransform.position.x - 50, playerTransform.position.y + 50, -10f);
            }
        }
    }
}
