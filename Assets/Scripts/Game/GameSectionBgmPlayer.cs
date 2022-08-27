using UnityEngine;

public class GameSectionBgmPlayer : MonoBehaviour
{

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if (PlayerPrefs.GetInt("isInGame", 0) == 0){
        Destroy(gameObject);
        }
    }

}