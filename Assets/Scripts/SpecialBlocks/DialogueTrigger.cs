using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    [SerializeField] private Dialogue _dialogue;
    [Tooltip("Used to disable player movements")]
    private GameObject _player;
    private string _playerLayerName = "Player";

    private void Start() {
        _player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D col) {

        void TriggerDialogue(){
            FindObjectOfType<DialogueManager>().StartDialogue(_dialogue);
        }

        if (col.gameObject.layer == LayerMask.NameToLayer(_playerLayerName)){
            TriggerDialogue();
            // Destroying so it won't play again.
            Destroy(gameObject);
        }
        
    }

}