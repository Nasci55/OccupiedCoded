using UnityEngine;
using UnityEngine.Events;

public class AchievementUnlocker : MonoBehaviour
{
    [SerializeField]
    private SteamManager steamManager;

    [SerializeField]
    private string achievement;

    private void Start()
    {
         steamManager = FindFirstObjectByType<SteamManager>();
    }

    public void UnlockAchievement()
    {
        steamManager.UnlockAchievement(achievement);
    }
}
