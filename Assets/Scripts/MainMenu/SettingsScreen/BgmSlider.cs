using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BgmSlider : MonoBehaviour
{

    [SerializeField] private AudioMixer _audioMixer;
    private Slider _slider;

    private void Awake() {
        _slider = GetComponent<Slider>();
    }

    private void Start() {
        _slider.value = PlayerPrefs.GetFloat("bgmVol", -20);
        _audioMixer.SetFloat("bgmVol", PlayerPrefs.GetFloat("bgmVol"));
    }

    public void SetBgmVolume (float volume){
        if (volume == -40){
            _audioMixer.SetFloat("bgmVol", -80);
        }
        else{
            _audioMixer.SetFloat("bgmVol", volume);
        }
        PlayerPrefs.SetFloat("bgmVol", volume);
    }

}