using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingsVariablePipe : MonoBehaviour
{
    [SerializeField]
    private UnityEvent callSetting;
    [SerializeField]
    private SettingsEnum settingName;
    private Slider thisSlider;

    void Start()
    {
        thisSlider = GetComponentInChildren<Slider>();
 
    }

    public void ChangeVariableData()
    {
        PlayerPrefs.SetFloat(settingName.ToString(), thisSlider.value);
        PlayerPrefs.Save();
        callSetting?.Invoke();
    }
}
