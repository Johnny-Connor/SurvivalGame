using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{

    [SerializeField] private int _teleportToSceneIndex;
    private Animator _animator;
    private string _playerLayerName = "Player";

    private void Awake() {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.layer == LayerMask.NameToLayer(_playerLayerName)){
            FadeToLevel();
        }
    }

    private void FadeToLevel(){
        Time.timeScale = 0;
        _animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete(int levelIndex){
        Time.timeScale = 1;
        SceneManager.LoadScene(_teleportToSceneIndex);
    }

}