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
    bool activate = true;



    private float rotation;
    private int damage = 1;
    private void Start()
    {
    }

    private void Update()
    {
        if (trigger180.isActivated() == true)
        {
            StartCoroutine(TrapActivating());
        }

    }

    private IEnumerator returnToOriginalPos()
    {
        yield return new WaitForSeconds(2);
        rotation += Time.deltaTime * 3;
        Quaternion start = transform.rotation;
        Debug.Log("RODA AO CONTRARIO");
        if (transform.eulerAngles.z < 360)
        {
            //gameObject.transform.rotation = Quaternion.identity;
            //transform.rotation = Quaternion.RotateTowards(Quaternion.Euler(new Vector3(0,0,-90)) ,Quaternion.identity, rotation);
            //transform.rotation = Quaternion.RotateTowards(start, Quaternion.identity, 90);
            transform.rotation = Quaternion.Slerp(start, Quaternion.identity, 0.02f);
        }

    }
    private IEnumerator TrapActivating()
    {
        yield return new WaitForSeconds(1.0f);
        rotation += Time.deltaTime * rotateSpeed;
        if (transform.eulerAngles.z > angleToStop && activate == true)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -rotation);
            Debug.Log(transform.eulerAngles.z);
            if (transform.eulerAngles.z == angleToStop)
                    activate = false;
        }
        else
        {
            trigger180.setActivate(false);
            StartCoroutine(returnToOriginalPos());
        }
    }


    public void OnTriggerEnter2D(Collider2D collider)
    {
        HealthSystem healthSystem = collider.GetComponentInParent<HealthSystem>();
        if (healthSystem == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"{name} collided with {healthSystem.name}");
            healthSystem.DealDamage(damage);
            Debug.Log($"The player Health now is {healthSystem.getHealth}");
        }

    }
}