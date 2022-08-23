using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{

    [SerializeField] private int _teleportToSceneNumber;
    private string _playerLayerName = "Player";

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.layer == LayerMask.NameToLayer(_playerLayerName)){
            SceneManager.LoadScene(_teleportToSceneNumber);
        }
    }

}
