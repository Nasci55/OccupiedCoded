using UnityEngine;

public class FamilyFound : MonoBehaviour
{

    AchievementUnlocker achievementUnlocker;

    bool firstTime = true;

    void Start()
    {
        achievementUnlocker = GetComponent<AchievementUnlocker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (firstTime)
        {
            achievementUnlocker.UnlockAchievement();
            firstTime = false;
        }
    }
}
