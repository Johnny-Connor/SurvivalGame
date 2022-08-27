using UnityEngine;

public class GameBgmPlayer : MonoBehaviour
{

    private GameObject _mainMenuBgmPlayer;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        if (_mainMenuBgmPlayer){

        }
    }

}