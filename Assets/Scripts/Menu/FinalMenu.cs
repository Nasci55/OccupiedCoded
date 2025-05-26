using UnityEngine;

public class FinalMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneTransition.TransitionToScene("Main Menu Restart");
        }
    }
}
