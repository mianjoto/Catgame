using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
    // Singleton for audio management
    public static AudioManager Instance;

    [SerializeField] private AudioSource _musicSource, _fxSource;
    
    public bool musicOn;
    public bool isDucked;
    float previousVolume;
    public float defaultMasterVolume = 0.7f;


    void Awake()
    {   
        // Singleton handler
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Debug.Log("Singleton instance already exists!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
    }

    public void PlayOneShot(AudioClip clip, float volumeScale=1)
    {
        if (clip == null)
            return;
        _fxSource.PlayOneShot(clip, volumeScale);
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
    
    public void DuckAudio(float duration)
    {
        previousVolume = AudioListener.volume;
        slowlyMuteFX(duration);
        slowlyMuteMusic(duration);
        isDucked = true;
    }

    public void ReverseDuckAudio(float duration)
    {
        _fxSource.DOFade(previousVolume, duration);
        _musicSource.DOFade(previousVolume, duration);
        isDucked = false;
    }

    public void ToggleMusic()
    {
        _musicSource.mute = !_musicSource.mute;
        if (_musicSource.mute)
            _musicSource.Pause();
        else
            _musicSource.Play();
        musicOn = !musicOn;
    }

    public bool IsMusicPlaying()
    {
        return _musicSource.isPlaying;
    }

    public void slowlyMuteFX(float duration)
    {
        _fxSource.DOFade(0, duration);
    }


    public void slowlyMuteMusic(float duration)
    {
        _musicSource.DOFade(0, duration);
    }
}
