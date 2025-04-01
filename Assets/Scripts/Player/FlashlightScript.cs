using UnityEngine;

public class FlashlightScript : MonoBehaviour
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
        if (lightTurn == true)
        {
            if (Input.GetMouseButton(0))
            {
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);

                }
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);

                }
            }
        }
    }


    void DeactivateChildren(GameObject gb, bool turn)
    {
        foreach (Transform child in transform)
        {
            DeactivateChildren(child.gameObject, turn);            
        }
    }
}
