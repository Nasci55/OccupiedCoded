using UnityEngine;

public class ThunderOUT : MonoBehaviour
{
    [SerializeField]
    private GameObject Thunder1;
    [SerializeField]
    private GameObject Thunder2;


    void OTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player entered the trigger");
        Thunder1.SetActive(false);
        Thunder2.SetActive(false);
    }
}
