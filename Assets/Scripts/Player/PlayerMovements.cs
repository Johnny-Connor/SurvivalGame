using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    private CharacterController2D _controller;

    private float _horizontalMove;
    private float _runSpd = 40f;
    private bool _jump;

    private void Awake() {
        _controller = GetComponent<CharacterController2D>();
    }

    private void Update() {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpd;

        if (Input.GetButtonDown("Jump")){
            _jump = true;
        }
    }

    void FixedUpdate()
    {
        _controller.Move(_horizontalMove * Time.fixedDeltaTime, false, _jump);
        _jump = false;
    }

}