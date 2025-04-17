using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Trap180 : MonoBehaviour
{
    [SerializeField]
    private Trigger180 trigger180;
    [SerializeField]
    private float LerpChange = 0.1f;
    
    private float Rotation;


    private void Update()
    {
        
        if (trigger180.IsActivated() == true)
        { 
            Rotation = Mathf.Lerp(0, -90, LerpChange);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, Rotation);
        }
    }
}
