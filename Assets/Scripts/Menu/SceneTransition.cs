using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private static SceneTransition instance;
    [SerializeField]
    private Animator _anim;
    private static string sceneToLoad;
    private static bool isLoadingScene;
    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static void TransitionToScene(string sceneName)
    {
        if (isLoadingScene)
            return;
        isLoadingScene = true;

        Debug.Log("Start transition to " + sceneName);
        instance._anim.SetTrigger("FadeIn");
        sceneToLoad = sceneName;

    }
    public void FadeToBlack()
    {

        Debug.Log("Fade to blLACK");

        SceneManager.LoadScene(sceneToLoad);
        isLoadingScene = false;
    }
}
