using UnityEngine;

public class ButtonSound : MonoBehaviour
{

    [SerializeField] private AudioPlayer _audioPlayer;
    [SerializeField] private int _soundIndex;

    public void ClickSound(){
        _audioPlayer.Play(0);
    }

}