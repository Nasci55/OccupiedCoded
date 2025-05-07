using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private Camera mainCamera;
    private bool lightTurn = true;
    private void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 rotation = mousePos - transform.position;
        
        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,rotationZ);
        
        flashlight();
    
    }


    void flashlight()
    {
        if (lightTurn == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                Light2D light = transform.GetComponentInChildren<Light2D>();
                /*foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }*/
                //light.gameObject.SetActive(false);
                light.GetComponent<Light2D>().enabled = false;

                lightTurn = false;
                Debug.Log("Turned On");
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Light2D light = transform.GetComponentInChildren<Light2D>();
                /*foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);

                }*/
                //light.gameObject.SetActive(true);
                light.GetComponent<Light2D>().enabled = true;

                lightTurn = true;
                Debug.Log("Turned Off");
            }
        }
    }

   public bool GetFlashlightState() => lightTurn;
}
