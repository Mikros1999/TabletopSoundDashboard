using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DashboardButtonManager : MonoBehaviour
{
    private AudioSource audioSource;
    private Button soundButton;
    private TMP_Text buttonLabel;

    void Awake()
    {
        InitializeThisElement();
    }

    private void InitializeThisElement()
    {
        audioSource = GetComponent<AudioSource>();
        soundButton = GetComponent<Button>();
        buttonLabel = GetComponentInChildren<TMP_Text>();

        if (audioSource == null || soundButton == null || buttonLabel == null)
        {
            Debug.LogError("DashboardButtonManager: Missing Component!");
            return;
        }

        if (audioSource.clip != null)
        {
            buttonLabel.text = FormatAudioName(audioSource.clip.name);
        } else
        {
            soundButton.enabled = false;
            gameObject.SetActive(false);
            return;
        }

        soundButton.onClick.AddListener(PlayButtonSound);
    }

    void PlayButtonSound()
    {
         audioSource.Play();
    }

    private string FormatAudioName(string clipName)
    {
        string cleanedName = clipName.Replace(" - ", " ");
        string[] words = cleanedName.Split(' ');
        return string.Join("\n", words);
    }
}