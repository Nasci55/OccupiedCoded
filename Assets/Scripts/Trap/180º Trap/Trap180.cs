using System.Collections;
using System.ComponentModel;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Trap180 : MonoBehaviour
{
    [SerializeField]
    private Trigger180 trigger180;
    [SerializeField]    
    private float rotateSpeed;
    [SerializeField, Description("0 - 360")]
    private float angleToStop = 270;
    
    private float rotation;

    private void Start()
    {
    }

    private void Update()
    {
        if (trigger180.isActivated() == true)
        { 
            rotation += Time.deltaTime * rotateSpeed;
            if (transform.eulerAngles.z > angleToStop)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -rotation);
                Debug.Log(transform.eulerAngles.z);    
            }
            else 
            {
                StartCoroutine (returnToOriginalPos());
                trigger180.setActivate(false);
            }

        }
    }

    private IEnumerator returnToOriginalPos()
    {
        yield return new WaitForSeconds(2);
        rotation += Time.deltaTime * 1;
        Debug.Log("RODA AO CONTRARIO");
        if (transform.eulerAngles.x < 360)
        {
            gameObject.transform.rotation = Quaternion.identity;
        }
        
    }
}
