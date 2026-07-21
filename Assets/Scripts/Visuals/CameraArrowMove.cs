using UnityEngine;
using UnityEngine.InputSystem;

public class CameraArrowMove : MonoBehaviour
{
    [SerializeField]
    private float       speed = 5.0f;
    [SerializeField, Tooltip("Allow vertical movement with up/down arrows")]
    private bool        allowVertical = true;

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        Vector2 dir = Vector2.zero;

        if (keyboard.leftArrowKey.isPressed)  dir.x -= 1.0f;
        if (keyboard.rightArrowKey.isPressed) dir.x += 1.0f;

        if (allowVertical)
        {
            if (keyboard.downArrowKey.isPressed) dir.y -= 1.0f;
            if (keyboard.upArrowKey.isPressed)   dir.y += 1.0f;
        }

        if (dir == Vector2.zero) return;

        // Normalize so diagonals move at the same constant speed
        transform.position += (Vector3)dir.normalized * (speed * Time.unscaledDeltaTime);
    }
}
