using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public void OnGameExitPress()
    {
        Application.Quit();
        Debug.Log("Game Exited");
    }

    public void OnGameStartPress()
    {
        SceneManager.LoadScene("Visual Updated");
    }

    public void OnGameSettingsPress()
    {
    }

    
}