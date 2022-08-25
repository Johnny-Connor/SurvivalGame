using System;
using UnityEngine;

public class NpcChase : MonoBehaviour
{

    // Variables
    [SerializeField] private bool _canFloat;
    private bool _isMovementEnabled = true;

    // Components.
    private Stats _stats;
    private Rigidbody2D _rb2d;
    private SpriteRenderer _spriteRenderer;

    // Target (Player).
    private Transform _player;

    // Managers
    private DialogueManager _dialogueManager;

    // Events.
    public event EventHandler OnTargetChase;
    public event EventHandler OnTargetCaught;
    public event EventHandler OnTargetMovementDisabled;

    private void Awake() {
        _rb2d = GetComponent<Rigidbody2D>();
        _stats = GetComponent<Stats>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        if (GameObject.FindGameObjectWithTag("Player")){
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        _dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        _dialogueManager.OnDialogueStart += SwitchIsMovementEnabled;
        _dialogueManager.OnDialogueEnd += SwitchIsMovementEnabled;
    }

    private void FixedUpdate() {

    void ChaseTarget(float spd, float range){
        if (_player && _isMovementEnabled){
            // Direction to go towards to.
            Vector3 dir;
            if (_canFloat){
                dir = (_player.transform.position - _rb2d.transform.position).normalized;
            }
            else{
                dir = new Vector3(_player.transform.position.x - _rb2d.transform.position.x, 0f, 0f).normalized;                
            }
            // Chase condition.
            if (Vector3.Distance(_player.transform.position, _rb2d.transform.position) > range){
                _rb2d.MovePosition(_rb2d.transform.position + dir * spd * Time.fixedDeltaTime);
                OnTargetChase?.Invoke(this, EventArgs.Empty);
            }
            else{
                OnTargetCaught?.Invoke(this, EventArgs.Empty);
            }
        }
        else{
            OnTargetMovementDisabled?.Invoke(this, EventArgs.Empty);
        }
    }

    void Fliper(){
        if (_player){
            if (_player.transform.position.x - _rb2d.transform.position.x > 0 && transform.localScale.x == -1){
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            else if (_player.transform.position.x - _rb2d.transform.position.x < 0 && transform.localScale.x == 1){
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    ChaseTarget(_stats.Spd, _stats.Range);
    Fliper();

    }

    private void SwitchIsMovementEnabled(object sender, EventArgs e){
        _isMovementEnabled = !_isMovementEnabled;
    }

    public bool IsMovementEnabled{
        get { return _isMovementEnabled; }
    }

}