using System;
using UnityEngine;

public class PlayerDeathManager : MonoBehaviour
{

    private Animator _animator;
    private Stats _stats;

    private void Awake() {
        _animator = GetComponent<Animator>();
        _stats = GameObject.Find("Player").GetComponentInChildren<Stats>();
        _stats.OnEntityDeath += FadeToLevel;
    }

    private void FadeToLevel(object sender, EventArgs e){
        Time.timeScale = 0;
        _animator.SetBool("isFadeOut", true);
    }

    public void OnFadeComplete(){
        _stats.TeleportToSpawnPoint();
        _stats.SetHealthToMax();
        Time.timeScale = 1;
        _animator.SetBool("isFadeOut", false);
    }

}
