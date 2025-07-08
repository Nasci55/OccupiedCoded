using System;
using Unity.VisualScripting;
using UnityEngine;

public class ColliderToggle : MonoBehaviour
{
    [SerializeField] private bool isThisOnlyUsedOnce;
    [SerializeField] private bool deactivateThisScriptButKeepCollider;
    [SerializeField] private bool startOn;
    [SerializeField] private bool deactivateEntireGameObject;
    [SerializeField] private Collider2D colliderToToggle;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>())
        {
             colliderToToggle.enabled = !startOn;

             if (isThisOnlyUsedOnce && !deactivateThisScriptButKeepCollider)
             {
                 this.gameObject.SetActive(false);
             }
             if (deactivateThisScriptButKeepCollider && !isThisOnlyUsedOnce)
             {
                this.gameObject.GetComponent<ColliderToggle>().enabled = false;
             }
             if (deactivateEntireGameObject)
            {
                colliderToToggle.GetComponent<GameObject>().SetActive(false);
            }
        }
    }
}
