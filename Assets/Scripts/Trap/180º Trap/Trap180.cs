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
            for (float i = 0; i > -90; i--)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, i*Time.deltaTime);
            }
        }
    }
}
