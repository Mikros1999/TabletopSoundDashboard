using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DashboardSliderManager : MonoBehaviour
{
    private AudioSource audioSource;
    private Slider volumeSlider;
    private TMP_Text sliderLabel;

    void Awake()
    {
        InitializeThisElement();
    }

    private void InitializeThisElement()
    {
        audioSource = GetComponent<AudioSource>();
        volumeSlider = GetComponentInChildren<Slider>();
        sliderLabel = GetComponentInChildren<TMP_Text>();

        if (audioSource == null || volumeSlider == null || sliderLabel == null)
        {
            Debug.LogError($"DashboardSliderManager: Missing component!");
            return;
        }

        volumeSlider.value = 0f;
        audioSource.volume = 0f;
        audioSource.playOnAwake = true;
        audioSource.loop = true;

        if (audioSource.clip != null)
        {
            sliderLabel.text = FormatAudioName(audioSource.clip.name);
        }
        else
        {
            gameObject.SetActive(false);
            return;
        }

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float volume)
    {
        audioSource.volume = volume;
    }

    private string FormatAudioName(string clipName)
    {
        string cleanedName = clipName.Replace(" - ", " ");
        string[] words = cleanedName.Split(' ');
        return string.Join("\n", words);
    }
}