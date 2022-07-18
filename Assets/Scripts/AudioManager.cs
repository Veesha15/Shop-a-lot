using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
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


    public void PlaySound(AudioClip _audioClip) // add to button in inspector 
    {
        generalAudioSource.PlayOneShot(_audioClip);
    }

    public void PlayButtonClick() // add to button in inspector 
    {
        generalAudioSource.PlayOneShot(buttonClickSound);
    }


}

// music is setup on first audio source on Game Manager
