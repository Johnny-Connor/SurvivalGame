using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    private CharacterController2D _controller;
    private float _horizontalMove;
    private float _spd = 40f;
    private float _runSpdBonus = 20f;
    private bool _jump;

    private void Awake() {
        _controller = GetComponent<CharacterController2D>();
    }

    private void Update() {

        void ReadInputs(){
            if (Input.GetButton("Fire3")){
                _horizontalMove = Input.GetAxisRaw("Horizontal") * (_spd + _runSpdBonus);
            }
            else{
                _horizontalMove = Input.GetAxisRaw("Horizontal") * _spd;
            }
            if (Input.GetButtonDown("Jump")){
                _jump = true;
            }
        }

        ReadInputs();

    }

    void FixedUpdate()
    {

        void ProcessInputs(){
            _controller.Move(_horizontalMove * Time.fixedDeltaTime, _jump);
            _jump = false;
        }

        ProcessInputs();

    }

}