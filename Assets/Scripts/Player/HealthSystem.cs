using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int MaxHealth = 3; 

    private int health;

    private void Start()
    {
        health = MaxHealth;
    }

    public void DealDamage(int damage)
    {

        if (health > 0)
        {
            health -= damage;
        }
        else if (health <= 0)
        {

        }
    }

    public int getHealth { get => health; }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2);
        Debug.Log(SceneManager.GetActiveScene().name);
        SceneTransition.TransitionToScene("Main Menu Restart");
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
