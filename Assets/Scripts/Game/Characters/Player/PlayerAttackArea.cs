using UnityEngine;

public class PlayerAttackArea : MonoBehaviour
{

    private AudioPlayer _audioPlayer;
    private Stats _targetStats;
    private Stats _playerStats;
    private string _nPCLayerName = "NPC";
    private bool _isColTriggered = false;

    private void Awake() {
        _audioPlayer = GetComponent<AudioPlayer>();
        _playerStats = GetComponentInParent<Stats>();
    }

    private void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.layer == LayerMask.NameToLayer(_nPCLayerName)){
            _targetStats = col.gameObject.GetComponent<Stats>();
            _isColTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.layer == LayerMask.NameToLayer(_nPCLayerName)){
            _targetStats = null;
            _isColTriggered = false;
        }        
    }

    private void Update() {
        if (_isColTriggered && Input.GetButtonDown("Fire1")){
            _audioPlayer.Play(0);
            _targetStats.AddHealth(_playerStats.Dmg * -1);
        }
    }

}
