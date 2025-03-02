using UnityEngine;
using UnityEngine.UI;

public class DashboardSliderManager : MonoBehaviour
{
    private AudioSource audioSource;
    private Slider volumeSlider;

    void Awake()
    {
        InitializeThisElement();
    }

    private void InitializeThisElement()
    {
        audioSource = GetComponent<AudioSource>();
        volumeSlider = GetComponentInChildren<Slider>();

        if (audioSource == null || volumeSlider == null)
        {
            Debug.LogError($"AudioManager: Missing components in {gameObject.name}!");
            return;
        }

        volumeSlider.value = 0f;
        audioSource.volume = 0f;
        audioSource.playOnAwake = true;
        audioSource.loop = true;

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float volume)
    {
        audioSource.volume = volume;
    }
}
