using UnityEngine;

public static class TrapDeathTracker
{
    private const string Prefix = "trapDeaths_";

    // Call this when a trap lands the killing blow. Returns the new count.
    public static int RecordDeath(string trapId)
    {
        string key = Prefix + trapId;
        int count = PlayerPrefs.GetInt(key, 0) + 1;
        PlayerPrefs.SetInt(key, count);
        PlayerPrefs.Save();
        return count;
    }

    public static int GetCount(string trapId) => PlayerPrefs.GetInt(Prefix + trapId, 0);
}
