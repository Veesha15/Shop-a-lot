using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour // attached to prefab
{
    public static AudioManager Instance { get; private set; }

    private AudioSource generalAudioSource;

    public AudioClip doorBellSound;
    public AudioClip lightBulbSound;
    public AudioClip buttonClickSound;
    public AudioClip coinDropSound;
    public AudioClip softSlotSound;
    public AudioClip mediumSlotSound;
    public AudioClip hardSlotSound;
    public AudioClip notificationSound;
    public AudioClip binSound;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        else
        {
            Instance = this;
        }

        generalAudioSource = GetComponent<AudioSource>();
    }


    public void PlaySound(AudioClip _audioClip) // select which audio clip to play
    {
        generalAudioSource.PlayOneShot(_audioClip);
    }

    public void PlayButtonClick() // provides consistency for any UI sounds
    {
        generalAudioSource.PlayOneShot(buttonClickSound);
    }


}

// music is setup on Game Manager
