using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SeSlider : MonoBehaviour
{

    [SerializeField] private AudioMixer _audioMixer;
    private AudioPlayer _audioPlayer;
    private Slider _slider;
    /*
     * Prevents the script from triggering the sound feedback
     * when starting the game.
     * Without it, the sound plays during "Start()" because of the 
     * ('On Value Changed') Unity event.
     */
    private bool _hasScriptChangedSliderValue;

    private void Awake() {
        _slider = GetComponent<Slider>();
        _audioPlayer = GetComponent<AudioPlayer>();
    }

    private void Start() {
        _slider.value = PlayerPrefs.GetFloat("seVol", -20);
        _audioMixer.SetFloat("seVol", PlayerPrefs.GetFloat("seVol"));
    }

    public void SetSeVolume (float volume){
        if (volume == -40){
            _audioMixer.SetFloat("seVol", -80);
        }
        else{
            _audioMixer.SetFloat("seVol", volume);
            SoundFeedback();
        }
        PlayerPrefs.SetFloat("seVol", volume);
    }

    private void SoundFeedback(){
        if (_hasScriptChangedSliderValue){
            _audioPlayer.Play(0);
        }
        else{
            _hasScriptChangedSliderValue = true;
        }
    }

}