using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Volume brightnessVolume;
    [SerializeField]
    private AudioMixer audioVolume;
    [SerializeField]
    private SettingsEnum brightnessEnum;

    private LiftGammaGain brightness;

    private float brightnessChanges;

    private void Start()
    {
        if (brightnessVolume.profile.TryGet(out brightness))
        {
            brightness.gamma.value = new Vector4(1f, 1f, 1f, 0);
        }
        if (PlayerPrefs.HasKey(brightnessEnum.ToString()))
        {
            brightnessChanges = PlayerPrefs.GetFloat(brightnessEnum.ToString());
            brightness.gamma.value = new Vector4(brightnessChanges, brightnessChanges, brightnessChanges, brightnessChanges);
        }

        QualitySettings.vSyncCount = 1;

    }

    public void UpdateBrightnessSetting()
    {
        brightnessChanges = PlayerPrefs.GetFloat(brightnessEnum.ToString());
        brightness.gamma.value = new Vector4(brightnessChanges, brightnessChanges, brightnessChanges, brightnessChanges);
    }

    public void UpdateAudioSettings()
    {
        audioVolume.SetFloat("MasterVolume", PlayerPrefs.GetFloat(SettingsEnum.Volume.ToString()));

    }

}
