using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    private Stats _targetStats;
    private float _wpnDmg = 25;
    private string _nPCLayerName = "NPC";
    private bool _isColTriggered = false;

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
            _targetStats.AddHealth(_wpnDmg * -1);
        }
    }

}
