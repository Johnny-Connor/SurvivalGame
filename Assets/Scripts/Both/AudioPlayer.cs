using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    [SerializeField] private AudioSource[] _audioSources;
    [SerializeField] private AudioClip[] _sounds;

    public void Play (int audioClipID, int audioSourceID)
    {
        _audioSources[audioSourceID].clip = _sounds[audioClipID];
        _audioSources[audioSourceID].Play();
    }

    public void Stop(int audioSourceID)
    {
        _audioSources[audioSourceID].Stop();
    }

}