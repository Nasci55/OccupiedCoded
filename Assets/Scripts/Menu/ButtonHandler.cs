using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonHandler : MonoBehaviour
{
    private float delayBeforeLoad = 2.0f;

    public void OnGameEarlyStartPress()
    {
        StartCoroutine(DelayedSceneLoad());
    }

    private IEnumerator DelayedSceneLoad()
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene("StartMenu");
    }
}