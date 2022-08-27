using System;
using UnityEngine;

public class NpcAttack : MonoBehaviour
{

    // Components.
    private NpcChase _npcChase;
    private Stats _stats;

    // Target (Player).
    private Stats _playerStats;

    private void Awake() {
        _npcChase = GetComponent<NpcChase>();
        _stats = GetComponent<Stats>();
        _npcChase.OnTargetCaught += DamagePlayer;
    }

    private void Start() {
        if (GameObject.FindGameObjectWithTag("Player")){
            _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
        }
    }

    private void DamagePlayer(object sender, EventArgs e){
        if(_playerStats){
            _playerStats.AddHealth(_stats.Dmg * -1);
        }
    }

}