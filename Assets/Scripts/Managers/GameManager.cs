using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("Cheat Stuff")]
    private Transform playerPos;
    [SerializeField]
    private Transform destination;
    [SerializeField]
    private Transform finalRoom;


    [SerializeField, Header("Post-Processing")]
    private GameObject normalGlobalVolume;
    [SerializeField]
    private GameObject ChaseGlobalVolume;
    [SerializeField]
    private GameObject DeathGlobalVolume;

    private Player player;
    private EnemyVisionState visionState;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        player = FindFirstObjectByType<Player>();
        visionState = FindFirstObjectByType<EnemyVisionState>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.Y) && Input.GetKey(KeyCode.E))
        {
            playerPos.position = destination.position;
        }
        if (Input.GetKey(KeyCode.V) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.U))
        {
            playerPos.position = finalRoom.position;
        }

        CRTEffect();
    }

    private void CRTEffect()
    {
        if (!player.isPlayerDead && !visionState.IsPlayerBeingSeen)
        {
            normalGlobalVolume.SetActive(true);
            ChaseGlobalVolume.SetActive(false);
            DeathGlobalVolume.SetActive(false);
        }
        else if (!player.isPlayerDead && visionState.IsPlayerBeingSeen)
        {
            normalGlobalVolume.SetActive(false);
            ChaseGlobalVolume.SetActive(true);
            DeathGlobalVolume.SetActive(false);
        }
        else if (player.isPlayerDead)
        {
            normalGlobalVolume.SetActive(false);
            ChaseGlobalVolume.SetActive(false);
            DeathGlobalVolume.SetActive(true);
        }
    }
}
