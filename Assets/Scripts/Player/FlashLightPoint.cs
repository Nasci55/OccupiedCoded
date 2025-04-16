using UnityEngine;

public class FlashLightPoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 5);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
