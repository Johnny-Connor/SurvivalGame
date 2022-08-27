using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{

    [SerializeField] private int _loadToSceneIndex;

    public void StartGame(){
        PlayerPrefs.SetInt("isInGame", 1);
        SceneManager.LoadScene(_loadToSceneIndex);
    }

}