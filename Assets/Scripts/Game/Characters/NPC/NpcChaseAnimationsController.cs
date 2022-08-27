using System;
using UnityEngine;

public class NpcChaseAnimationsController : MonoBehaviour
{

    private NpcChase _npcChase;
    private Animator _animator;

    private void Awake() {
        _animator = GetComponentInParent<Animator>();
        _npcChase = GetComponent<NpcChase>();
        _npcChase.OnTargetMovementDisabled += SwitchToIdleAnim;
        _npcChase.OnTargetChase += SwitchToWalkAnim;
    }

    private void SwitchToIdleAnim(object sender, EventArgs e){
        _animator.SetBool("isChasing", false);
    }

    private void SwitchToWalkAnim(object sender, EventArgs e){
        _animator.SetBool("isChasing", true);
    }

}