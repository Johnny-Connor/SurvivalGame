using System;
using UnityEngine;

public class NpcSpawnAndDeath : MonoBehaviour
{

    private Stats _stats;
    private Stats _playerStats;

    private void Awake() {
        _stats = GetComponent<Stats>();
        _stats.OnEntityDeath += TeleportAway;
        _playerStats = GameObject.Find("Player").GetComponentInChildren<Stats>();
        _playerStats.OnEntityDeath += HealAndRespawn;
    }

    private void TeleportAway(object sender, EventArgs e){
        transform.position = new Vector2(0, -10);
    }

    private void HealAndRespawn(object sender, EventArgs e){
        _stats.SetHealthToMax();
        _stats.TeleportToSpawnPoint();
    }

}