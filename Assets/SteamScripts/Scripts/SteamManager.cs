using System;
using UnityEngine;

public enum eAchievement
{
    ASTRO_CARD,
    ASTRO_LIGHTS,
    ASTRO_HACK,
    ASTRO_MOTHERBOARD,
    ASTRO_VIRUS,
    ASTRO_DOOR,

    CSN_P1,
    CSN_P2,
    CSN_P3,
    CSN_PIZZA,
    CSN_SNAKE,

    ECHO_FINISH,
    ECHO_NOTE_MASTER,
    ECHO_FIRST_NOTE,
    ECHO_TIME_TRAVELER,
    ECHO_TIKI_COLLECTOR,

    OCP_FINISH,
    OCP_FAMILY,
    OCP_TRAP,
    OCP_ENEMY,

    TP_TENTOAST,
    TP_HUNDREDTOAST,
    TP_THOUSANDTOAST,
    TP_FINISHED,
    TP_COMPLETIONIST,
    TP_CUSTOMIZETOASTER,
    TP_CUSTOMIZEARM,
    TP_BOSS,
    TP_INFINITEHUNDRED,
    TP_INFINITETWOHUNDRED,

    TAF_FIRSTPUZZLE,
    TAF_SECONDPUZZLE,
    TAF_THIRDPUZZLE,
    TAF_END,

    LAUNCH_TAF,
    LAUNCH_TP,
    LAUNCH_OCP,
    LAUNCH_ECHO,
    LAUNCH_CSN,
    LAUNCH_ASTRO,
}

public class SteamManager : MonoBehaviour
{
    public static SteamManager instance;

    [SerializeField] private uint appID = 4993710;

    private bool connectedToSteam;
    private string achId;

    public bool steamDebug = false;

    [Header("Achievement Debugger")]
    public eAchievement enumField;

    public string SelectedAchievementID => enumField.ToString();

#if UNITY_EDITOR
    private void OnValidate()
    {
        achId = enumField.ToString();
    }
#endif

    private void Awake()
    {
        achId = enumField.ToString();
    }

    public void IsThisAchievementUnlocked(string id = "")
    {
        if (steamDebug || string.IsNullOrEmpty(id))
            id = achId;

        var ach = new Steamworks.Data.Achievement(id);
        Debug.Log($"Achievement {id} status: {ach.State}");
    }

    public void UnlockAchievement(string id = "")
    {
        if (steamDebug || string.IsNullOrEmpty(id))
            id = achId;

        var ach = new Steamworks.Data.Achievement(id);
        ach.Trigger();

        Debug.Log($"Achievement {id} unlocked");
    }

    public void ClearAchievementStatus(string id = "")
    {
        if (steamDebug || string.IsNullOrEmpty(id))
            id = achId;

        var ach = new Steamworks.Data.Achievement(id);
        ach.Clear();

        Debug.Log($"Achievement {id} cleared");
    }

    private void Start()
    {
        try
        {
            Steamworks.SteamClient.Init(appID);

            PrintName();

            connectedToSteam = true;
        }
        catch (Exception e)
        {
            connectedToSteam = false;
            Debug.LogException(e);
        }
    }

    private void Update()
    {
        if (connectedToSteam)
            Steamworks.SteamClient.RunCallbacks();
    }

    public void DisconnectFromSteam()
    {
        if (connectedToSteam)
            Steamworks.SteamClient.Shutdown();
    }

    public void UnlockAchievement(eAchievement achievement)
    {
        if (!connectedToSteam)
            return;

        var ach = new Steamworks.Data.Achievement("Achievement_" + (int)achievement);
        ach.Trigger();
    }

    public void ResetAllAchievements()
    {
        if (!connectedToSteam)
        return;

        Steamworks.SteamUserStats.ResetAll(true);

        Debug.Log("All Steam achievements and stats have been reset.");
    }

    private void PrintName()
    {
        Debug.Log(Steamworks.SteamClient.Name);
    }
}