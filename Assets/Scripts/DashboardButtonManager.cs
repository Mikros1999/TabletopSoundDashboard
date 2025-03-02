using UnityEngine;
using UnityEngine.UI;

public class DashboardButtonManager : MonoBehaviour
{
    private AudioSource audioSource;
    private Button soundButton;

    void Start()
    {
        InitializeThisElement();
    }

    private void InitializeThisElement()
    {
        audioSource = GetComponent<AudioSource>();
        soundButton = GetComponent<Button>();

        if (audioSource == null || soundButton == null)
        {
            Debug.LogError("ButtonAudioTrigger: Missing AudioSource or Button component!");
            return;
        }

        soundButton.onClick.AddListener(PlayButtonSound);
    }

    void PlayButtonSound()
    {
         audioSource.Play();
    }
}