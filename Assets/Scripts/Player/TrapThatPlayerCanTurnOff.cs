using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class TrapThatPlayerCanTurnOff : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log($"{name} collided with {collider.name}");
    }

}
