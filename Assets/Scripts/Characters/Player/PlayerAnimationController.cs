using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    private Animator _animator;

    private void Awake() {
        _animator = GetComponentInParent<Animator>();
    }

    private void Update() {

        void AnimationTrigger(){
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

        AnimationTrigger();

    }

}