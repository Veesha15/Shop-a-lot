using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource generalAudioSource; // 2nd audio source on Game Manager

    public AudioClip doorBellSound;
    public AudioClip lightBulbSound;
    public AudioClip buttonClickSound;


    public void PlaySound(AudioClip _audioClip) // add to button in inspector 
    {
        generalAudioSource.PlayOneShot(_audioClip);
    }

    public void ButtonClick() // add to button in inspector 
    {
        generalAudioSource.PlayOneShot(buttonClickSound);
    }

}

// music is setup on first audio source on Game Manager
