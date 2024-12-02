using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioClip backgroundMusic;
    public AudioClip fruitCollectSound;
    public AudioClip fruitLoseSound;
    public AudioClip groundHitSound;
    public AudioClip gameOverSound;

    private AudioSource backgroundAudioSource;
    private AudioSource effectAudioSource;

    protected override void Awake()
    {
        base.Awake();
        InitializeAudioSources();
    }

    private void InitializeAudioSources()
    {
        backgroundAudioSource = gameObject.AddComponent<AudioSource>();
        effectAudioSource = gameObject.AddComponent<AudioSource>();

        backgroundAudioSource.clip = backgroundMusic;
        backgroundAudioSource.loop = true;
        backgroundAudioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        backgroundAudioSource.Play();
    }

    public void SetMusicVolume(float volume)
    {
        backgroundAudioSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetEffectVolume(float volume)
    {
        effectAudioSource.volume = volume;
        PlayerPrefs.SetFloat("EffectVolume", volume);
    }

    public void PlayFruitCollectSound()
    {
        PlayEffectSound(fruitCollectSound);
    }

    public void PlayFruitLoseSound()
    {
        PlayEffectSound(fruitLoseSound);
    }

    public void PlayGroundHitSound()
    {
        PlayEffectSound(groundHitSound);
    }

    public void PlayGameOverSound()
    {
        PlayEffectSound(gameOverSound);
    }

    private void PlayEffectSound(AudioClip clip)
    {
        effectAudioSource.PlayOneShot(clip, effectAudioSource.volume);
    }
    public void PlayBackgroundMusic()
    {
        if (!backgroundAudioSource.isPlaying)
        {
            backgroundAudioSource.Play();
        }
    }
}
