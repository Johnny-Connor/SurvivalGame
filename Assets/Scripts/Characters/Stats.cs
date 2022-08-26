using System;
using UnityEngine;

public class Stats : MonoBehaviour
{

    [SerializeField] private float _health;
    private float _maxHealth;
    [SerializeField] private float _dmg;    
    [SerializeField] private float _spd;
    [SerializeField] private float _range;
    [SerializeField] private Vector2 _respawnPoint;

    public event EventHandler OnEntityDeath;

    private void Awake() {
        _maxHealth = _health;
    }

    public void AddHealth(float value){
        _health += value;
        if (_health <= 0){
            OnEntityDeath?.Invoke(this, EventArgs.Empty);
        }
    }

    public void SetHealthToMax(){
        _health = _maxHealth;
    }

    public void TeleportToSpawnPoint(){
        transform.position = _respawnPoint;
    }

    public float Health{
        get { return _health; }
    }

    public float Dmg{
        get { return _dmg; }
    }

    public float Spd{
        get { return _spd; }
    }

    public float Range{
        get { return _range; }
    }

    public Vector2 RespawnPoint{
        get { return _respawnPoint; }
    }

}