using System;
using UnityEngine;

public class NpcChase : MonoBehaviour
{

    // Components.
    private Stats _stats;
    private Rigidbody2D _rb2d;
    private SpriteRenderer _spriteRenderer;

    // Target (Player).
    private GameObject _player;

    // Events.
    public event EventHandler OnTargetChase;
    public event EventHandler OnTargetCaught;

    private void Awake() {
        _rb2d = GetComponent<Rigidbody2D>();
        _stats = GetComponent<Stats>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        if (GameObject.FindGameObjectWithTag("Player")){
            _player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void FixedUpdate() {

    void ChaseTarget(float spd, float range){
        // Direction to go towards to.
        Vector3 dir = (_player.transform.position - _rb2d.transform.position).normalized;
        // Chase condition.
        if (Vector3.Distance(_player.transform.position, _rb2d.transform.position) > range){
            _rb2d.MovePosition(_rb2d.transform.position + dir * spd * Time.fixedDeltaTime);
            OnTargetChase?.Invoke(this, EventArgs.Empty);
        }
        else{
            OnTargetCaught?.Invoke(this, EventArgs.Empty);
        }
    }

    void Fliper(){
        if (_player.transform.position.x - _rb2d.transform.position.x > 0 && _spriteRenderer.flipX){
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
        else if (_player.transform.position.x - _rb2d.transform.position.x < 0 && !_spriteRenderer.flipX){
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
    }

    ChaseTarget(_stats.Spd, _stats.Range);
    Fliper();

    }

}