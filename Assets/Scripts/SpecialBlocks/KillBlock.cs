using UnityEngine;

public class KillBlock : MonoBehaviour
{

    private Stats _playerStats;

    private void Start()
    {
        _playerStats = GameObject.Find("Player").GetComponentInChildren<Stats>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player")){
            _playerStats.Kill();
        }
    }

}