using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SteamManager))]
public class SteamManagerEditor : Editor
{
    private SerializedProperty appID;
    private SerializedProperty steamDebug;
    private SerializedProperty enumField;

    // Remembers which foldouts are open
    private readonly Dictionary<string, bool> foldouts = new Dictionary<string, bool>();

    private void OnEnable()
    {
        appID = serializedObject.FindProperty("appID");
        steamDebug = serializedObject.FindProperty("steamDebug");
        enumField = serializedObject.FindProperty("enumField");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawDefaultProperties();

        EditorGUILayout.Space(10);

        DrawAchievementSelector();

        EditorGUILayout.Space();

        DrawActionButtons();

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawDefaultProperties()
    {
        EditorGUILayout.PropertyField(appID);
        EditorGUILayout.PropertyField(steamDebug);
    }

    private void DrawAchievementSelector()
    {
        EditorGUILayout.LabelField("Achievement Debugger", EditorStyles.boldLabel);

        string[] names = Enum.GetNames(typeof(eAchievement));

        Dictionary<string, List<int>> groups = new Dictionary<string, List<int>>();

        for (int i = 0; i < names.Length; i++)
        {
            string prefix = names[i].Contains("_")
                ? names[i].Substring(0, names[i].IndexOf('_'))
                : "Other";

            if (!groups.ContainsKey(prefix))
                groups.Add(prefix, new List<int>());

            groups[prefix].Add(i);
        }

        foreach (var group in groups)
        {
            if (!foldouts.ContainsKey(group.Key))
                foldouts[group.Key] = true;

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            foldouts[group.Key] =
                EditorGUILayout.Foldout(
                    foldouts[group.Key],
                    $"{group.Key} ({group.Value.Count})",
                    true);

            if (foldouts[group.Key])
            {
                foreach (int index in group.Value)
                {
                    bool selected = enumField.enumValueIndex == index;

                    if (GUILayout.Toggle(selected, names[index], "Button"))
                    {
                        enumField.enumValueIndex = index;
                    }
                }
            }

            EditorGUILayout.EndVertical();

            GUILayout.Space(2);
        }

        EditorGUILayout.Space();

        EditorGUILayout.HelpBox(
            $"Selected Achievement:\n{names[enumField.enumValueIndex]}",
            MessageType.None);
    }

    private void DrawActionButtons()
    {
        SteamManager manager = (SteamManager)target;

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Check"))
            manager.IsThisAchievementUnlocked();

        if (GUILayout.Button("Unlock"))
            manager.UnlockAchievement();

        if (GUILayout.Button("Clear"))
            manager.ClearAchievementStatus();

        EditorGUILayout.EndHorizontal();

        GUILayout.Space(8);

        GUI.backgroundColor = new Color(1f, 0.65f, 0.65f);

        if (GUILayout.Button("Reset ALL Steam Achievements"))
        {
            if (EditorUtility.DisplayDialog(
                "Reset Steam Achievements",
                "This will permanently reset ALL achievements for the current Steam account.\n\nContinue?",
                "Reset",
                "Cancel"))
            {
                manager.ResetAllAchievements();
            }
        }

        GUI.backgroundColor = Color.white;
    }
}