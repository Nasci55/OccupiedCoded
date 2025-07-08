using System.Collections;
using UnityEngine;

public class SummonTheEnemyWSound : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private Transform enemySpawnPoint;
    [SerializeField, Header("Audio")] private AudioClip audioClip;

    [SerializeField] private float volume;

    private float audioclipLength;
    void Start()
    {
        audioclipLength = audioClip.length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.playSound(audioClip, transform, volume);
        Debug.Log(audioclipLength);
        StartCoroutine(SpawnEnemy());
        this.GetComponent<Collider2D>().enabled = false;

    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(audioclipLength);
        Enemy.GetComponent<Rigidbody2D>().position = enemySpawnPoint.position;
    }

}
