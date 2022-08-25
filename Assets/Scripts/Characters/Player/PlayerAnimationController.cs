using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    private Animator _animator;
    private PlayerMovements _playerMovements;

    private void Awake() {
        _animator = GetComponentInParent<Animator>();
        _playerMovements = GetComponent<PlayerMovements>();
    }

    private void Update() {

        void AttackAnimationTrigger(){
            if (_playerMovements.IsMovementEnabled){
                if (Input.GetButtonDown("Fire1")){
                _animator.SetTrigger("Swing");
                }
            }
        }

        void MovementAnimationsTrigger(){
            if (_playerMovements.IsMovementEnabled){
                if (Input.GetAxisRaw("Horizontal") == 0){
                    _animator.SetInteger("IdleWalkRun", 0);
                }
                else{
                    if (!Input.GetButton("Fire3")){
                        _animator.SetInteger("IdleWalkRun", 1);
                    }
                    else{
                        _animator.SetInteger("IdleWalkRun", 2);
                    }
                }
            }
            else{
                _animator.SetInteger("IdleWalkRun", 0);
            }
        }

        AttackAnimationTrigger();
        MovementAnimationsTrigger();

    }

}