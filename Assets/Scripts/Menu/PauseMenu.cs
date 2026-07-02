using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuUI;

    [SerializeField]
    private GameObject flashlight;
    [SerializeField]
    private int mainMenuSceneIndex;

    private bool isPaused;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuUI.activeSelf)
            {
                OnResumeGame();
            }
            else
            {
                OnPauseMenu();
            }
        }
    }

    public void OnPauseMenu()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.visible = true;
        flashlight.SetActive(false);
    }

    public void OnResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.visible = false;
        flashlight.SetActive(true);
    }

    public void OnQuitGame()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}
