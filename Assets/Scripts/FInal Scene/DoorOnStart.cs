using UnityEngine;

public class DoorOnStart : MonoBehaviour
{
    [SerializeField] private GameObject DoorUI;
    [SerializeField] private Animator DoorAnimator;


    void Start()
    {
        OnDoorOpen();
    }

    // Update is called once per frame
    void Update()
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
