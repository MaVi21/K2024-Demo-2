using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SliderVolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    // Exposed parameter name in the AudioMixer
    private string exposedParameterName = "effectsVolume";

    private void Start()
    {
        // Subscribe to the slider's OnValueChanged event
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
        }
        else
        {
            Debug.LogWarning("Volume slider is not assigned.");
        }
    }

    public void OnVolumeSliderChanged(float volume)
    {
        // Set the volume of the "effects" group in the AudioMixer
        if (audioMixer != null)
        {
            audioMixer.SetFloat(exposedParameterName, volume);
        }
        else
        {
            Debug.LogWarning("AudioMixer is not assigned.");
        }
    }
}
