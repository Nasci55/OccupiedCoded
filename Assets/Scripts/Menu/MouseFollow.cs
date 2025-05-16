using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private RectTransform rectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition = Input.mousePosition;
    }
}
