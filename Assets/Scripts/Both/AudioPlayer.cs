using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _sounds;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play (int audioClipID)
    {
        _audioSource.clip = _sounds[audioClipID];
        _audioSource.Play();
    }

    public void Stop()
    {
        _audioSource.Stop();
    }

}
