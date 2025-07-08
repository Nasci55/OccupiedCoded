using UnityEngine;

public class TPThePlayerToTheRightPlace : MonoBehaviour
{
    [SerializeField]
    private Transform FirstFloorPointTransform;
    [SerializeField] private GameObject DoorUI;
    [SerializeField] private Animator DoorAnimator;
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>())
        {
            collider.GetComponent<Transform>().position = FirstFloorPointTransform.position;
            OnDoorOpen();
        }
    }

    private void Update()
    {
        if (isDoorOpening)
        {
            AnimatorStateInfo stateInfo = DoorAnimator.GetCurrentAnimatorStateInfo(0);
            Debug.Log("Door animation state: " + stateInfo.normalizedTime);
            if (stateInfo.normalizedTime >= 1.0f)
            {
                Debug.Log("Door animation completed");
                DoorUI.SetActive(false);
                isDoorOpening = false;
            }
        }
    }

    private bool isDoorOpening = false;
    private void OnDoorOpen()
    {
        //Debug.Log("Door opened");
        DoorUI.SetActive(true);
        DoorAnimator.SetTrigger("OpenDoor");
        isDoorOpening = true;

    }
}
