using System;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    // Variables
    private float _horizontalMove;
    private float _runSpdBonus = 20f;
    private bool _jump;
    private bool _isMovementEnabled = true;

    // Components
    private CharacterController2D _controller;
    private Stats _stats;

    // Managers
    private DialogueManager _dialogueManager;

    private void Awake() {
        _controller = GetComponent<CharacterController2D>();
        _stats = GetComponent<Stats>();
    }

    private void Start() {
        _dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        _dialogueManager.OnDialogueStart += SwitchIsMovementEnabled;
        _dialogueManager.OnDialogueEnd += SwitchIsMovementEnabled;
    }

    private void Update() {

        void ReadInputs(){
            if(_isMovementEnabled){
                if (Input.GetButton("Fire3")){
                    _horizontalMove = Input.GetAxisRaw("Horizontal") * (_stats.Spd + _runSpdBonus);
                }
                else{
                    _horizontalMove = Input.GetAxisRaw("Horizontal") * _stats.Spd;
                }
                if (Input.GetButtonDown("Jump")){
                    _jump = true;
                }
            }
        }

        ReadInputs();

    }

    void FixedUpdate()
    {

        void ProcessInputs(){
            if (_isMovementEnabled){
                _controller.Move(_horizontalMove * Time.fixedDeltaTime, _jump);
                _jump = false;
            }
            else{
                _controller.Move(0 * Time.fixedDeltaTime, false);                
            }
        }

        ProcessInputs();

    }

    private void SwitchIsMovementEnabled(object sender, EventArgs e){
        _isMovementEnabled = !_isMovementEnabled;
    }

    public bool IsMovementEnabled{
        get { return _isMovementEnabled; }
    }

}