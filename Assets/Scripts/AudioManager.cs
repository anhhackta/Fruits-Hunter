using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip backgroundMusic;
    public AudioClip fruitCollectSound;
    public AudioClip fruitLoseSound;
    public AudioClip groundHitSound;
    public AudioClip gameOverSound;

    private AudioSource backgroundAudioSource;
    private AudioSource effectAudioSource;
    
    void Awake()
    {
        // Nếu chưa có Instance, gán nó
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
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
        effectAudioSource.PlayOneShot(fruitCollectSound);
    }

    public void PlayFruitLoseSound()
    {
        effectAudioSource.PlayOneShot(fruitLoseSound);
    }

    public void PlayGroundHitSound()
    {
        effectAudioSource.PlayOneShot(groundHitSound);
    }

    public void PlayGameOverSound()
    {
        effectAudioSource.PlayOneShot(gameOverSound);
    }
}
