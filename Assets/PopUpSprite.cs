using UnityEngine;
using UnityEngineInternal;

public class PopUpSprite : MonoBehaviour
{
    [SerializeField]
    private bool popUpAppears;

    private SpriteRenderer popUpVisual;
    void Start()
    {
        popUpVisual = GetComponent<SpriteRenderer>();
        popUpVisual.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (popUpVisual != null)
        {
            if (popUpAppears)
            {
                popUpVisual.enabled = true;
            }
            else
            {
                popUpVisual.enabled = false;
            }
        }
    }
}
