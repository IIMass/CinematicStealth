using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource voSource;

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
    public void PlayVO(AudioClip clip)
    {
        voSource.clip = clip;
        voSource.Play();
    }
}