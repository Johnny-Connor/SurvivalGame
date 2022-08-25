using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthMonitor : MonoBehaviour
{

    private Animator _animator;
    [SerializeField] private Stats _stats;

    private void Awake() {
        _animator = GetComponent<Animator>();
        _stats.OnEntityDeath += FadeToLevel;
    }

    private void FadeToLevel(object sender, EventArgs e){
        Time.timeScale = 0;
        _animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
