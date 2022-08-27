using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{

    [SerializeField] private int _loadToSceneIndex;

    public void StartGame(){
        SceneManager.LoadScene(_loadToSceneIndex);
    }

}
