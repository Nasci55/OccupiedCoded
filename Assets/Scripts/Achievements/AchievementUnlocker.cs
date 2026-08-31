using UnityEngine;
using UnityEngine.Events;

public class AchievementUnlocker : MonoBehaviour
{
    [SerializeField]
    private eAchievement achievement;

    public UnityEvent<string> OnAchieved;

    public void UnlockAchievement()
    {
        OnAchieved?.Invoke(achievement.ToString());
    }
}
