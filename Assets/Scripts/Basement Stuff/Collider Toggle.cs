using System;
using Unity.VisualScripting;
using UnityEngine;

public class ColliderToggle : MonoBehaviour
{
    [SerializeField] private bool isThisOnlyUsedOnce;
    [SerializeField] private bool startOn;
    [SerializeField] private Collider2D colliderToToggle;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>())
        {
             colliderToToggle.enabled = !startOn;

             if (isThisOnlyUsedOnce)
             {
                 this.gameObject.SetActive(false);
             }
        }
    }
}
