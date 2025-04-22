using System.ComponentModel;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Trap180 : MonoBehaviour
{
    [SerializeField]
    private Trigger180 trigger180;
    [SerializeField]
    private float lerpChange = 0.1f;
    [SerializeField]    
    private float rotateSpeed;
    [SerializeField, Description("0 - 360")]
    private float angleToStop = 270;
    
    private float rotation;


    private void Update()
    {
        if (trigger180.IsActivated() == true)
        { 
            rotation += Time.deltaTime * rotateSpeed;
            if (transform.eulerAngles.z != angleToStop)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -rotation);
                Debug.Log(transform.eulerAngles.z);    
            }
            else 
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -90f);
                Debug.Log("POR FAVOR PARA");
            }
        }
    }
}
