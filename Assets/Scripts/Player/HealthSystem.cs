using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int MaxHealth = 2;
    [SerializeField] private Animator animator;
    [SerializeField] private string sceneName;
    [SerializeField] private int deathsForAchievement = 5;
    [SerializeField] private SteamManager steamManager;

    private int health;

    private void Start()
    {
        health = MaxHealth;

        if (steamManager == null)
            steamManager = FindFirstObjectByType<SteamManager>();
    }

    public void DealDamage(int damage, string trapId = null)
    {
        if (health <= 0)
            return;

        health -= damage;

        if (health <= 0)
        {
            GetComponent<Collider>().enabled = false;

            if (!string.IsNullOrEmpty(trapId))
            {
                int count = TrapDeathTracker.RecordDeath(trapId);
                if (count >= deathsForAchievement && steamManager != null)
                    steamManager.UnlockAchievement(eAchievement.OCP_TRAP);
            }

            Die();
        }
    }

    public int getHealth { get => health; }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2);
        Debug.Log(SceneManager.GetActiveScene().name);
        SceneTransition.TransitionToScene($"{sceneName}");
    }

    public void Die()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        
        StartCoroutine(Respawn());
    }

}
